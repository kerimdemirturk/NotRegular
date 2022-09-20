using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclesEntry : MonoBehaviour
{
    public GameObject player;
    public GameObject drivingCar;
    public GameObject plane;
    public GameObject carCocpitCAM;
    public bool isEntervehicle = false;
    public GameObject vehicleFollowCam;
    public GameObject planeCam;


   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //trigger and drive car.
        if(isEntervehicle == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                carCocpitCAM.SetActive(true);
                player.SetActive(false);
                drivingCar.GetComponent<carsMovement>().enabled = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;

            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                carCocpitCAM.SetActive(false);
                vehicleFollowCam.SetActive(true);
                
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                carCocpitCAM.SetActive(false);
                vehicleFollowCam.SetActive(false);
                player.SetActive(true);
                isEntervehicle = false;
                drivingCar.GetComponent<carsMovement>().enabled = false;
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
                player.transform.position = new Vector3(drivingCar.transform.position.x + 3, player.transform.position.y, drivingCar.transform.position.z);
                drivingCar.GetComponent<Rigidbody>().velocity = Vector3.zero;
                
            }
        }
        Vector3 carPos = drivingCar.transform.position;

        if(playerMovement.isEnterPlane == true)
        {
            planeCam.SetActive(true);
            player.SetActive(false);
        }
        
    }

    //check if player try to enter car
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isEntervehicle = true;
            Debug.Log("plane");
        }
    }

    //check player exit car
    private void OnTriggerExit(Collider other)
    {
        isEntervehicle = false;
    }
}
