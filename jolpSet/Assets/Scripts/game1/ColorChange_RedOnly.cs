using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorChange_RedOnly : MonoBehaviour
{
    Material[] BallColors; 
    void Start()
    {
        BallColors = new Material[7];

        BallColors[0] = Resources.Load<Material>("Materials/Red");
        BallColors[1] = Resources.Load<Material>("Materials/Orange");
        BallColors[2] = Resources.Load<Material>("Materials/Yellow");
        BallColors[3] = Resources.Load<Material>("Materials/Green");
        BallColors[4] = Resources.Load<Material>("Materials/Blue");
        BallColors[5] = Resources.Load<Material>("Materials/Indigo");
        BallColors[6] = Resources.Load<Material>("Materials/Purple");

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("change!");
        gameObject.GetComponent<MeshRenderer>().material = BallColors[Random.Range(0, 6)];
    }
}
