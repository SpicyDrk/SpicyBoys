using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    public Rigidbody rb;
    
    Camera cam;
    
    // The player's movement speed
    public Vector3 _velocity;
    public Vector3 _acceleartion;
    
    [SerializeField] 
    private float turnSpeed = 5f;
    
    [SerializeField]
    private float maxSpeed = 5f;

    [SerializeField] 
    private float groundFriction = 0.9f;
    
    public Vector3 mousePosition;
    

    void Awake()
    {
        // get the main camera
        cam = Camera.main;
        // get this components rigidbody
        rb = GetComponent<Rigidbody>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //Face player to mouse p
        FaceMouse();
        CheckInput();
        DebugUpdate();
    }
    
    void FixedUpdate()
    {

    }
    
    void DebugUpdate()
    {
    }
    
    void CheckInput()
    {
        
        //add velocity to the player in direction of player
        if (Keyboard.current.wKey.isPressed)
        {
            _acceleartion += transform.forward * 5f;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            _acceleartion += -transform.forward * 5f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            _acceleartion += -transform.right * 5f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            _acceleartion += transform.right * 5f;
        }
        MovePlayer();
    }
    
    void MovePlayer()
    {
        
        _velocity += _acceleartion;
        // limit velocity to max speed
        _velocity = Vector3.ClampMagnitude(_velocity, maxSpeed);
        // apply friction to the player
        _velocity *= groundFriction;
       transform.position += _velocity * Time.deltaTime;
        _acceleartion = Vector3.zero;
    }

    void FaceMouse()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, newRotation, turnSpeed);
            transform.rotation = smoothedrotation;
            rb.MoveRotation(newRotation);
        }
    }
}
