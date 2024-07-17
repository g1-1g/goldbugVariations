using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnityButtonChange : MonoBehaviour
{

    GameObject frameIN;
    [SerializeField]
    Material[] Umaterials;
    public GameObject Root;
    GameObject WindowCollider;
    void Start()
    {

        frameIN = GameObject.Find("frameIn");
        Root = GameObject.Find("UnityClosePivot");
        WindowCollider = GameObject.Find("WindowCollider");
        WindowCollider.SetActive (false);

    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("click");
        frameIN.GetComponent<MeshRenderer>().material = Umaterials[1];

    }
    private void OnCollisionExit(Collision collision)
    {
        frameIN.GetComponent<MeshRenderer>().material = Umaterials[0];
        Root.GetComponent<Animator>().SetBool("isClose", true);
        WindowCollider.SetActive(true);
        


    }
}
