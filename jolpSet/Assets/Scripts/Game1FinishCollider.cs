using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1FinishCollider : MonoBehaviour
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
            GameObject.FindObjectOfType<Game1>().GameEnd();
            Destroy(other.gameObject);
            
        } else if (other.gameObject.CompareTag("IgameFinishOK"))
        {
            GameObject.FindObjectOfType<Game1>().GameEnd();
            Destroy(other.gameObject);
        } else
        {
            Destroy(other.gameObject);
        }

    }
}
