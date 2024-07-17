using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInit : MonoBehaviour
{
    Vector3 InitPos;
    void Start()
    {
        InitPos = transform.position;
    }

    void Update()
    {
          
    }

    public void InitFirstPos() 
    {
        transform.position = InitPos;
    }
}
