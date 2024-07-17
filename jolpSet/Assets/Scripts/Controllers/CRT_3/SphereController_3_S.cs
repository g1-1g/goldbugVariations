using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController_3_S : MonoBehaviour
{
    [SerializeField]
    GameObject CRT_3;
    [SerializeField]
    Game3 gm3;
    [SerializeField]
    GameObject blackPerson;
    bool isBlackPersonGen=false;
    GameObject LoadedPerson;

    GameObject PersonOut;
    void Start()
    {
        CRT_3 = transform.parent.gameObject;
        LoadedPerson = Resources.Load<GameObject>("Prefabs/Small_Boy");
        PersonOut = GameObject.Find("PersonOutPos");
    }

    void Update()
    {
        if (gm3 == null)
        {
            gm3 = GameObject.Find("CRT_3").GetComponent<Game3>();
        }
        if (isBlackPersonGen)
        {
            if (blackPerson == null)
            {
                if (LoadedPerson == null)
                {
                    Debug.Log("failed");
                }
                if (LoadedPerson != null)
                {
                    Debug.Log("blackPerson »ý¼º! ");
                    blackPerson = GameObject.Instantiate(LoadedPerson, PersonOut.transform.position, Quaternion.Euler(0f, 90, 0),CRT_3.transform);
                    Debug.Log(blackPerson);
                    blackPerson.transform.GetComponent<BlackPersonController>().PersonMovingStart();
                    isBlackPersonGen = false;
                }
            }

        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Collider_3") 
    //    {
    //        gm3.IGameEnd();
    //        Debug.Log("Ending Command");
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SceneChanger")
        {
            isBlackPersonGen = true;
        }
        else if (other.tag == "GameEnding") 
        {
            Destroy(blackPerson);
            Destroy(gameObject);
            CRT_3.GetComponent<Game3>().GameEnd();
        }           
      
    }
    private void OnCollisionEnter(Collision collision)
    {
    }
}

