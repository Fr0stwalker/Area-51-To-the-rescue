using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothing = 5f;
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
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}