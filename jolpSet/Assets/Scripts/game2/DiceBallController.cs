using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class DiceBallController : MonoBehaviour
{
    Rigidbody rb;
   
    float jumpP = 100;
    float ballSpeed;
    


    Transform target;

    Transform target2;
    int TargetN = 0;


    bool isDie;
    bool isJump = false;
    int i = 0;
    void Start()
    {
        target = GameObject.Find("Target").transform;
        target2 = GameObject.Find("Target2").transform;
        isDie = false;
        ballSpeed = Random.Range(4, 8);
        

    }

    void Update()
    {
        if (rb != null)
        {
  
            rb.AddForce(Vector3.down * 30f);
        }
        rb = GetComponent<Rigidbody>();
        if ( gameObject.GetComponent<Rigidbody>() != null)
        {
                       
        }
        
        if (isDie&& isJump && TargetN == 0)
        {
           
            transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, ballSpeed*0.01f);
            if (Vector3.Distance(target.position, gameObject.transform.position) < 0.5f)
            {
                TargetN = 1;
            }
        }else if ((isDie && isJump && TargetN == 1)){
            transform.position = Vector3.MoveTowards(gameObject.transform.position, target2.transform.position, ballSpeed * 0.01f);
        }
        if(Vector3.Distance(target.position, gameObject.transform.position) < 20)
        {
            ballSpeed = 10;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GroundG2"))
        {
            if (i == 0)
            {
                StartCoroutine(WaitingWakeup());

                rb = GetComponent<Rigidbody>();

                i++;
            }
        }

        if (isDie && Vector3.Distance(target.position, gameObject.transform.position) > 20)
        {
            isJump = false;
            jumpP = Random.Range(50, 150);
            rb.AddForce(Vector3.up * jumpP);
            //transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, 0.1f);
            isJump = true;
        }
       
    }
    IEnumerator WaitingWakeup()
    {
        yield return new WaitForSeconds(Random.Range(1, 4));
        isDie = true;
        isJump = true;
        


    }

        


}
