using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f; //Change in inspector to adjust move speed
    [SerializeField] private float minBoundary=-45;
    [SerializeField] private float maxBoundary=45;
    float camRayLength = 100f;
    int floorMask;
    Rigidbody playerRigidbody;
    private Vector3 _forward, _right; // Keeps track of our relative forward and right vectors
    void Start()
    {
        _forward = Camera.main.transform.forward; // Set forward to equal the camera's forward vector
        _forward.y = 0; // make sure y is 0
    _forward = Vector3.Normalize(_forward); // make sure the length of vector is set to a max of 1.0
    _right = Quaternion.Euler(new Vector3(0, 90, 0)) * _forward; // set the right-facing vector to be facing right relative to the camera's forward vector
    playerRigidbody = GetComponent<Rigidbody>();
    floorMask = LayerMask.GetMask("Floor");
    }
    void Update()
    {
        Turning();
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) // only execute if a key is being pressed
        {
            Move();
        }
    }

    private void Turning()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Move()
    {
        Vector3 rightMovement = moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey") * _right; // Our right movement is based on the right vector, movement speed, and our GetAxis command. We multiply by Time.deltaTime to make the movement smooth.
        Vector3 upMovement = moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey") * _forward; // Up movement uses the forward vector, movement speed, and the vertical axis inputs.
        var transform1 = transform;
        var position = transform1.position;
        position += rightMovement; // move our transform's position right/left
        position += upMovement; // Move our transform's position up/down
        position.x = Mathf.Clamp(position.x, minBoundary, maxBoundary);
        position.z = Mathf.Clamp(position.z, minBoundary, maxBoundary);
        transform1.position = position;
    }
}