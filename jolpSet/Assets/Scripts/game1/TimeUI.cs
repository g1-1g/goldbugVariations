using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        gameObject.GetComponent<Text>().text = DateTime.Now.ToString(("tt HH:mm\nyyyy-MM-dd"));

    }
}
