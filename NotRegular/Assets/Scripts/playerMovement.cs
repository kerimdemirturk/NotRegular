using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private bool idIdle = true;
    private bool isWalking = false;
    private bool isRunning = false;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotateSpeed = 5;

    public static bool isEnterPlane = false;
    public static bool isEnterCar = false;
 
    private float horizontalInput;
    private float verticalInput;

    public Animator playerAnim;
    public Rigidbody playerRb;

    private Vector3 movement = Vector3.zero;

    void Start()
    {
        playerAnim  = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movement = new Vector3(horizontalInput,0, verticalInput);
        float rotationY = transform.rotation.y;
       
       
        
        //walk and turn codes
        if(movement != Vector3.zero)
        {
           
            playerRb.velocity =  transform.forward* verticalInput * Time.fixedDeltaTime * walkSpeed; //always walk to forward by facing direction. 
           

            if (movement.x >0.1f)
            {
                transform.Rotate(0, horizontalInput * rotateSpeed * Time.fixedDeltaTime, 0);
            }
            if(movement.x<0.1f)
            {
                transform.Rotate(0, horizontalInput * rotateSpeed * Time.fixedDeltaTime, 0);
            }
            playerAnim.SetFloat("Move",0.2f);
        }
        else
        {
            playerRb.velocity = Vector3.zero;
            playerAnim.SetFloat("Move", 0.0f);
        }

        //Running codes
       

        if(Input.GetKey(KeyCode.LeftShift) && movement != Vector3.zero)
        {
            playerRb.velocity = transform.forward* verticalInput * Time.fixedDeltaTime*runSpeed;
            playerAnim.SetFloat("Move", 1);

        }

        
        
    }

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            float forwardx = transform.forward.x;
            forwardx = Input.mousePosition.x;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "plane")
        {
            isEnterPlane = true;
        }
        if(other.gameObject.tag == "car")
        {
            isEnterCar = true;
        }
    }

    



}
