using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController_3 : MonoBehaviour
{
    [SerializeField]
    GameObject CRT_3;
    [SerializeField]
    Game3 gm3;
    void Start()
    {
       
;    }

    void Update()
    {
        if (gm3 == null) 
        {
            gm3=GameObject.Find("CRT_3").GetComponent<Game3>();
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Collider_3") 
        {
            gm3.GameEnd();
            Debug.Log("Ending Command");
        }
    }
}
