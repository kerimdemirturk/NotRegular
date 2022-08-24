using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ShootController : MonoBehaviour
{

    public GameObject shootcam;
    public GameObject thirdPersonCam;
    public GameObject crossHair;
    public Animator playerAnimation;
    public bool isShoot = false;
    

    void Start()
    {
        playerAnimation = GetComponent<Animator>();
    }

  
    //if player click right mouse button camera make zoom and player ready to shoot
    void Update()
    {
        //aiming and shooting
        if(Input.GetMouseButton(1))
        {
            shootcam.SetActive(true);
            thirdPersonCam.SetActive(false);
            crossHair.SetActive(true);
            playerAnimation.SetBool("isAim", true);
            isShoot = true;

            //shooting animation transition
            if(isShoot == true && Input.GetMouseButton(0))
            {
                Debug.Log("true");
                playerAnimation.SetBool("isShoot", true);
            }
            else
            {
                playerAnimation.SetBool("isShoot", false);
            }
        }

        else
        {
            shootcam.SetActive(false);
            thirdPersonCam.SetActive(true);
            crossHair.SetActive(false);
            isShoot = false;
            playerAnimation.SetBool("isAim", false);
        }
    }
}
