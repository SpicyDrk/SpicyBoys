using System;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //print secript loaded
        Debug.Log("PlayerController script loaded");
        // get this components rigidbody
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        //Face player to mouse p
        FaceMouse();
    }

    void FaceMouse()
    {
        //make rigidbody face mouse in the zx plane
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookPos = mousePos - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
        Debug.Log("Mouse Position: " + mousePos);
    }
}
