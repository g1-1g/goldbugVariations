using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    Vector3 targetPosition;
    bool ismoving=false;
    void Start()
    {
        targetPosition = transform.position - new Vector3(0, 0, 100);
    }

    void Update()
    {
        if (ismoving) 
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition,3*Time.deltaTime);
        }
        
        if (transform.position.z-targetPosition.z  < 0.1f) 
        {
            ismoving = false;
        }
    }

    public void moveOn() 
    {
        ismoving = true;
    }
}
