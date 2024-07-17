using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController_1 : MonoBehaviour
{
    [SerializeField]
    GameObject CRT_1;
    [SerializeField]
    Game1 gm1;
    void Start()
    {
       
;    }

    void Update()
    {
        if (gm1 == null) 
        {
            gm1=GameObject.Find("CRT_1").GetComponent<Game1>();
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Collider_1") 
        {
            gm1.GameEnd();
            Debug.Log("Ending Command");
        }
    }
}
