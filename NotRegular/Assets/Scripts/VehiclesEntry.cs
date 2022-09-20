using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclesEntry : MonoBehaviour
{
    public GameObject player;
    public GameObject drivingCar;
    public GameObject carCAM;
    public bool isEnterCar = false;
    public GameObject carFollowCam;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //trigger and drive car.
        if(isEnterCar == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                carCAM.SetActive(true);
                player.SetActive(false);
                drivingCar.GetComponent<carsMovement>().enabled = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                carCAM.SetActive(false);
                carFollowCam.SetActive(true);
                
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                carCAM.SetActive(false);
                carFollowCam.SetActive(false);
                player.SetActive(true);
                isEnterCar = false;
                drivingCar.GetComponent<carsMovement>().enabled = false;
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
                player.transform.position = new Vector3(drivingCar.transform.position.x + 3, player.transform.position.y, drivingCar.transform.position.z);
                drivingCar.GetComponent<Rigidbody>().velocity = Vector3.zero;
                
            }
        }
        Vector3 carPos = drivingCar.transform.position;
        
    }

    //check if player try to enter car
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isEnterCar = true;
        }
    }

    //check player exit car
    private void OnTriggerExit(Collider other)
    {
        isEnterCar = false;
    }
}
