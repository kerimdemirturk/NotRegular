using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRb;
    public float bulletSpeed = 10.0f;



    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();

    }

    
    void Update()
    {
        bulletRb.velocity = transform.forward * bulletSpeed;  
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
