using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ShootController : MonoBehaviour
{

    public GameObject shootcam;
    public GameObject thirdPersonCam;


    void Start()
    {
      
    }

  
    //if player click right mouse button camera make zoom and player ready to shoot
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            shootcam.SetActive(true);
            thirdPersonCam.SetActive(false);
        }
        else
        {
            shootcam.SetActive(false);
            thirdPersonCam.SetActive(true);
        }
    }
}
