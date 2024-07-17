using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController_2 : MonoBehaviour
{
    [SerializeField]
    GameObject CRT_2;
    [SerializeField]
    Game2 gm2;
    void Start()
    {
       
;    }

    void Update()
    {
        if (gm2 == null) 
        {
            gm2=GameObject.Find("CRT_2").GetComponent<Game2>();
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Collider_2") 
        {
            gm2.GameEnd();
            Debug.Log("Ending Command");
        }
    }
}
