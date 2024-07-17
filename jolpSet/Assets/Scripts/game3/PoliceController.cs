using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PoliceController : MonoBehaviour
{
    Rigidbody rb;
    private CharacterController controller;
    GameObject Target;
    Light Lt;
    float ballSpeed = 15;
    int count;
    bool isRed;
    Color Red;
    Color Blue;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Red = new Color(255, 0, 0);
        Blue = new Color(0, 0, 255);
        controller = GetComponent<CharacterController>();
        Target = GameObject.FindObjectOfType<BallController_CameraOfCamera>().gameObject;
        Lt = gameObject.GetComponentInChildren<Light>();
        isRed = false;
    }

    void Update()
    {
        count++;
        if (count % 10 == 0)
        {
            if (isRed)
            {
                Lt.color = Red;
                isRed = false;
            }
            else
            {
                Lt.color = Blue;
                isRed = true;
            }
        }
        gameObject.transform.LookAt(Target.transform);
        Vector3 moveDirection = (Target.transform.position - gameObject.transform.position).normalized;
        controller.Move(moveDirection * ballSpeed * Time.deltaTime);

    }
}
