using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_1 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) { transform.position += Vector3.left * Time.deltaTime * 10; }
        if (Input.GetKey(KeyCode.D)) { transform.position += Vector3.right * Time.deltaTime * 10; }
        if (Input.GetKey(KeyCode.S)) { transform.position += Vector3.back * Time.deltaTime * 10; }
        if (Input.GetKey(KeyCode.W)) { transform.position += Vector3.forward * Time.deltaTime * 10; }
        if (Input.GetKey(KeyCode.Q)) { transform.position += Vector3.up * Time.deltaTime * 10; }
        if (Input.GetKey(KeyCode.E)) { transform.position += Vector3.down * Time.deltaTime * 10; }
        if (Input.GetKey(KeyCode.T)) { transform.Rotate(new Vector3(0, 1, 0), -0.3f); }
        if (Input.GetKey(KeyCode.Y)) { transform.Rotate(new Vector3(0, 1, 0), 0.3f); }





        //if (Input.GetKeyDown(KeyCode.Space)) 
        //{ transform.position = new Vector3(16.01f, 17.72f, -23.2f);
        //{ transform.position = new Vector3(0.05f, 12.62f, -27.81f); 이게 3번 모니터 수치 
          //      transform.rotation = Quaternion.Euler(14.59f, 336.74f, 356.5f);
            
        //}
      
    }
}
