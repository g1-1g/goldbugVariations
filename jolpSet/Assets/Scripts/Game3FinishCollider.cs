using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3FinishCollider : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PgameFinishOK"))
        {
            GameObject.FindObjectOfType<Game3>().GameEnd();
            Destroy(other.gameObject);
            
        } else if (other.gameObject.CompareTag("IgameFinishOK"))
        {
            GameObject.FindObjectOfType<Game3>().GameEnd();
            Destroy(other.gameObject);
        }else if(other.gameObject.CompareTag("Player"))
        {
           
        }else
        {
            Destroy(other.gameObject);
        }

    }
}
