using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForce : MonoBehaviour
{
    Rigidbody rb;
    float force = 9.81f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
        }

    }

    void Update()
    {
        if (rb != null)
        {
            rb.AddForce(Vector3.down * force);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
