using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MirrorBallMove : MonoBehaviour
{

    public GameObject[] targetPosition;
    int count = 0;
    public float moveSpeed = 5000.0f;
    Rigidbody rb; 
    
    void Start()
    {
        targetPosition = new GameObject[1];
        targetPosition[0] = GameObject.Find("Target1M");
        //targetPosition[1] = GameObject.Find("Target2M");
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.AddForce((targetPosition[count].transform.position - transform.position) * moveSpeed);
        if (Vector3.Distance(targetPosition[count].transform.position, gameObject.transform.position) < 5f){
            if (count < targetPosition.Length-1)
            {
                count++;
                
            }
        }
    }
    

}
