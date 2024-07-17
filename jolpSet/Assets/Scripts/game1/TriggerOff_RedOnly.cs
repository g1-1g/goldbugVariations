using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOff_RedOnly : MonoBehaviour
{
    Material redMaterial;
    GameObject ErrorUI;
    List<GameObject> ErrorUIs;
    int i = 0;
    void Start()
    {
        redMaterial = Resources.Load<Material>("Materials/Red");
        ErrorUI = Resources.Load<GameObject>("Prefabs/RedOnly");
        ErrorUIs = new List<GameObject>();  // 리스트 초기화

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name =="Sphere1ForRedOnly(Clone)" && other.gameObject.GetComponent<MeshRenderer>().material.name != redMaterial.name + " (Instance)")
        {
           
            Debug.Log(other.gameObject.GetComponent<MeshRenderer>().material); 
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 3000); //뒤로 바운싱
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            ErrorUIs.Add(Instantiate(ErrorUI, GameObject.Find("Canvas_1").transform));
            ErrorUIs[i].transform.position += new Vector3(20*i, -20*i, 0);
            Debug.Log(ErrorUIs);
            i++;


        }
        else
        {
            i = 0;
            foreach (GameObject ErrorUI in ErrorUIs)
            {
                Destroy(ErrorUI);

            }
            ErrorUIs.Clear();

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Sphere1ForRedOnly(Clone)")
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = true; // 콜라이더 트리거로 복귀
        }
    }
}
