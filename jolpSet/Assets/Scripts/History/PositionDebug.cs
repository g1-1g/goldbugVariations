using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionDebug : MonoBehaviour
{
    [SerializeField]
    Text TempPosition;
    [SerializeField]
    GameObject tempCamera;
    [SerializeField]
    GameObject monitor;
    string add;
    void Start()
    {
        TempPosition=transform.GetChild(0).GetComponent<Text>();
       
        
    }

    void Update()
    {
        add = tempCamera.transform.rotation.eulerAngles.ToString();
        TempPosition.text = tempCamera.transform.position.ToString()+add;
    }
}
