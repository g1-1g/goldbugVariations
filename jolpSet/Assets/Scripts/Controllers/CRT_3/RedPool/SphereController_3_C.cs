using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController_3_C : MonoBehaviour
{
    [SerializeField]
    GameObject CRT_3;
    [SerializeField]
    Game3 gm3;
    [SerializeField]
    GameObject collapseRail;
    [SerializeField]
    Camera camera_3;
    [SerializeField]
    GameObject slider;
    [SerializeField]
    GameObject spotlight;

    bool isRotating = false;
    bool shaking = false;
    public float rotationSpeed = 1.0f; // 회전 속도
    public Quaternion targetRotation1; // 목표 회전
    public Quaternion targetRotation2; // 목표 회전
    void Start()
    {
       camera_3 = GameObject.Find("Camera_3").GetComponent<Camera>();
        slider = GameObject.Find("Slider");
        spotlight = GameObject.Find("Spot Light");    
    }

    void Update()
    {
        if (gm3 == null) 
        {
            gm3=GameObject.Find("CRT_3").GetComponent<Game3>();
            collapseRail = GameObject.Find("Rail2");        }

        if (isRotating)
        {
            if (shaking)
            {
                Quaternion newRotation1 = Quaternion.Slerp(collapseRail.transform.rotation, targetRotation1, 20f*Time.deltaTime);
                collapseRail.transform.rotation = newRotation1;
                if (Quaternion.Angle(newRotation1, targetRotation1) < 1f)
                {
                    shaking = false;
                }
            }
            else 
            {
                Quaternion newRotation2 = Quaternion.Slerp(collapseRail.transform.rotation, targetRotation2, 0.15f);
                collapseRail.transform.rotation = newRotation2;
                if (Quaternion.Angle(newRotation2, targetRotation2) < 1f)
                {
                    isRotating = false;
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
        if (other.gameObject.tag=="Collapse") 
        {
            shaking=true;
            isRotating = true;
            Quaternion currentRotation = transform.rotation;
            targetRotation1=Quaternion.Euler(0, 183, 3);
            targetRotation2 = Quaternion.Euler(0, 210, -20);
        }
        if (other.gameObject.tag == "SceneChanger")
        {
            //camera_3.transform.position = new Vector3(102.25f, -9.296265f, -49.82389f);
            camera_3.GetComponent<CameraController_3>().CameraChaseStart(); // 부딪히면 카메라 추적 시작
            slider.GetComponent<SliderController>().moveOn();
            spotlight.GetComponent<SpotLightController>().LightMovingStart();
        }
        if (other.gameObject.tag == "bounce") 
        {
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(200000, 0, -80000));
        }
    //  if (other.gameObject.tag == "BallPool")
    //  {
    //      camera_3.GetComponent<CameraController_3>().CameraChaseEnd();
    //  }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "3.5F" )
        {
            camera_3.GetComponent<CameraController_3>().CameraChaseEnd();
        }
    }
}

