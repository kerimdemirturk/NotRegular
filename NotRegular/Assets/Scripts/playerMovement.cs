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
    [SerializeField]private float rotateSpeed = 5;
    [SerializeField] private LayerMask aimColliderMask=new LayerMask();

    private float horizontalInput;
    private float verticalInput;

    public Animator playerAnim;
    public Rigidbody playerRb;

    private Vector3 movement = Vector3.zero;
    public GameObject bullet;

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
            playerAnim.SetFloat("Move", 0.2f);
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

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit raycastHit,999f,aimColliderMask))
        {
            bullet.transform.position = raycastHit.point;
        }
    }
}
