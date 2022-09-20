using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class ShootController : MonoBehaviour
{

    public GameObject shootcam;
    public GameObject thirdPersonCam;
    public GameObject crossHair;
    public Animator playerAnimation;
    public bool isShoot = false;
    public GameObject gun;

    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem flash;

    public GameObject particleObject;
    public Transform spawnPoint;
    public GameObject bullet;
    public Rigidbody bulletRb;

   



    

    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        bulletRb = GetComponent<Rigidbody>();
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
            gun.SetActive(true);
            



            //shooting animation transition
            if(isShoot == true && Input.GetMouseButtonDown(0))
            {
                Debug.Log("true");
                playerAnimation.SetBool("isShoot", true);
                shoot();
                flash.Play();
               
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
            gun.SetActive(false);
        }
    }

    private void shoot()
    {
        RaycastHit hit;
        flash.Play();
        if (Physics.Raycast(shootcam.transform.position,shootcam.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            GameObject go =  Instantiate(particleObject, hit.point, Quaternion.identity);
           
            Destroy(go, 2f);
            if(target != null)
            {
                target.takeDamage(damage);

            }
        }

    }
    
}
