using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFactor : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T)) { transform.localScale += new Vector3(1, 0, 0); }
        if (Input.GetKey(KeyCode.Y)) { transform.localScale += new Vector3(-1, 0, 0); }
        if (Input.GetKey(KeyCode.Z)) { transform.localScale += new Vector3(1, 1, 1); }
        if (Input.GetKey(KeyCode.X)) { transform.localScale += new Vector3(-1, -1, -1); }
        if (Input.GetKeyDown(KeyCode.Space)) {
            transform.localScale = new Vector3(50, 50, 50);
        }
    }
}
