using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_3 : MonoBehaviour
{
    [SerializeField]
    bool _isCameraChasingBall=false;

    [SerializeField]
    GameObject sphere3_C;

    float yDistance=0;
    
    void Start()
    {
       
    }

    void LateUpdate()
    {
        
        
        if (_isCameraChasingBall) 
        {
            //           transform.position.y=sphere3_C.transform.position.y;
            // transform.position += new Vector3(0, , 0);

            if (yDistance == 0) 
            {
                yDistance = transform.position.y - sphere3_C.transform.position.y;
            }

            transform.position=new Vector3(transform.position.x,sphere3_C.transform.position.y+yDistance,transform.position.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(45f, 0, 0)), 4f * Time.deltaTime);


        }    
      
    }

    public void CameraChaseStart() 
    {
        _isCameraChasingBall = true;
        sphere3_C = GameObject.FindWithTag("CollapseBall");
    }
    public void CameraChaseEnd()
    {
        _isCameraChasingBall = false;
    }
}
