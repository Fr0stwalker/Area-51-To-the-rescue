using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothing = 5f;
    [SerializeField] private float minBoundary = -40f;
    [SerializeField] private float maxBoundary = 12;
    private Vector3 _offset;

    // Use this for initialization
    void Start()
    {
        _offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetCamPos = target.position + _offset;
        targetCamPos.x = Mathf.Clamp(targetCamPos.x,minBoundary, maxBoundary);
        targetCamPos.z = Mathf.Clamp(targetCamPos.z, minBoundary, maxBoundary);
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}