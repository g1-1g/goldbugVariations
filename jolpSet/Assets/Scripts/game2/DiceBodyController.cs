using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class DiceBodyController : MonoBehaviour
{
    Rigidbody rb;
    bool isDie = false;
    GameObject[] ball;
    GameObject camera2;

    void Start()
    {
        ball = new GameObject[21];
        rb = gameObject.GetComponent<Rigidbody>();
        for (int i = 0; i < ball.Length; i++)
        {
            ball[i] = transform.GetChild(i).gameObject;
        }
        camera2 = GameObject.Find("Camera_2");
        
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!isDie)
        {
            rb.AddForce(Vector3.right * 20);

        }
        rb.AddForce(Vector3.down * 30f);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("diceDie"))
        {
            if (!isDie)
            {
                isDie = true;
                foreach (GameObject go in ball)
                {
                    go.AddComponent<Rigidbody>();
                    go.GetComponent<Rigidbody>().useGravity = false;
                    
                }
                //GameObject.FindObjectOfType<DiceErrorEnd>().dropBall++;
                StartCoroutine(goCave());
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("diceDieReady"))
        {
            rb.constraints = RigidbodyConstraints.None;

        }
    }
    IEnumerator goCave()
    {
        yield return new WaitForSeconds(2);
        camera2.GetComponent<Animator>().Play("Camera2DiceError");

        GameObject.FindObjectOfType<caveBlinkle>().enabled = true;
    }
}