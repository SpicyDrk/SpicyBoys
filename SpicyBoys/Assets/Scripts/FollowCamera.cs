using System;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] GameObject player;
    public Transform target;
    public float smoothSpeed = 0.01f;
    public Vector3 locationOffset;
    
    public Vector3 mousePosition;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        mousePosition = new Vector3();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
        }
        
        
        Vector3 desiredPosition = target.position + locationOffset;
        //change desired position to move the camera in the direction of the mouse
        Vector3 mouseOffset = (mousePosition - desiredPosition).normalized * 5f;
        
        desiredPosition += mouseOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
