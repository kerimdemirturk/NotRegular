using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public Rigidbody rb;

    public float engineThrust = 10000f;
    public float pitchSpeed = 30f;
    public float rollSpeed = 45f;
    public float yawSpeed = 25f;

    private float thrust;
    private float pitch;
    private float roll;
    private float yaw;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if(rb==null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        if(rb.mass == 1)
        {
            rb.mass = 20000;
            rb.drag = 0.007f;
            rb.angularDrag = 0.05f; 
        }
    }


    void Start()
    {
        
    }

   
    void Update()
    {
        pitch = 0f;
        roll = 0f;
        yaw = 0f;

        //controlling plane vectors
        if (Input.GetKey(KeyCode.Q))
        { 
            yaw = -1f; 
        }

        if(Input.GetKey(KeyCode.E))
        {
            yaw = 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            roll = 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            roll = -1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            pitch = 1f;
        }


        if (Input.GetKey(KeyCode.S))
        {
            pitch = -1f;
        }

        UpdateThrottle();


    }

    //control throttle
    private void UpdateThrottle()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            thrust = 30f;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            thrust = 60f;
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            thrust = 100f;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            thrust = 0f;
        }

        if(Input.GetKey(KeyCode.KeypadPlus))
        {
            thrust += 10;
        }
        if(Input.GetKey(KeyCode.KeypadMinus))
        {
            thrust -= 10;
        }

        thrust = Mathf.Clamp(thrust, 0f, 100f);

    }
    private void FixedUpdate()
    {
        rb.AddForce((thrust * engineThrust) * transform.forward);
        var localVelocity = transform.InverseTransformDirection(rb.velocity);
        var localSpeed = Mathf.Max(0, localVelocity.z);


        transform.RotateAround(transform.position, transform.up, yaw * Time.fixedDeltaTime * yawSpeed); //yaw control
        transform.RotateAround(transform.position, transform.forward, roll * Time.fixedDeltaTime * rollSpeed); //roll control
        transform.RotateAround(transform.position, transform.right, pitch  * Time.fixedDeltaTime * pitchSpeed); //pitch




    }
}
