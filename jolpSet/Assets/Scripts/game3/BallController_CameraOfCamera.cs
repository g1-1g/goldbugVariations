using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BallController_CameraOfCamera : MonoBehaviour
{


    private addForce[] tower; // ž�� ��� Rigidbody �迭


    Transform[] target;
    GameObject Police;


    int TargetN = 0;
    int Count = 0;
    int CountJump = 0;

    //float jumpP = 100;
    float ballSpeed = 10;
    bool isDone = false; //���ʶ߷ȴ��� ����
    bool isJump = true;

    Rigidbody rb;
    private CharacterController controller;

    private void Start()
    {
        target = new Transform[6];

        rb = GetComponent<Rigidbody>();
        target[0] = GameObject.Find("Target3-1").transform;
        target[1] = GameObject.Find("Target3-2").transform;
        target[2] = GameObject.Find("Target3-3").transform;
        target[3] = GameObject.Find("Target3-4").transform;
        target[4] = GameObject.Find("Target3-5").transform;
        target[5] = GameObject.Find("Target3-6").transform;
        controller = GetComponent<CharacterController>();
        controller.enabled = false;
        // ž�� ��� �ڽ� ������Ʈ���� Rigidbody ������Ʈ�� �����ɴϴ�.
        tower = GameObject.FindObjectsOfType<addForce>();

        // ��� ž�� Rigidbody�� IsKinematic���� �����Ͽ� �������� �ʵ��� �մϴ�.
        foreach (addForce tw in tower)
        {
            if (tw.gameObject.GetComponent<Rigidbody>() != null)
                tw.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void Update()
    {
        ApplyGravity();


        if (isDone && isJump)
        {
            CountJump++;
            Vector3 moveDirection = (target[TargetN].position - gameObject.transform.position).normalized;
            controller.Move(moveDirection * ballSpeed * Time.deltaTime);
            //transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, ballSpeed * 0.01f);
            
            // ��¦ ��¦ ���� ����
            if (CountJump % 20 == 0 && TargetN >= 2) // �Ź� �� ��° �̵� �ÿ��� ����
            {
                //Jump();
            }
            if (Vector3.Distance(target[TargetN].position, gameObject.transform.position) < 5f)
            {
                if (target.Length - 1 > TargetN)
                    TargetN++;
                Count++;
                if (TargetN == 2)
                {
                    ballSpeed = 30;
                    gameObject.GetComponentInChildren<Animator>().enabled = true;
                    gameObject.transform.rotation = Quaternion.identity;
                    rb.freezeRotation = true;
                }
                else if (TargetN == 3)
                {
                    Police = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Police for MoM"), target[1]);
                }
                if (Count == target.Length && Vector3.Distance(Police.transform.position, gameObject.transform.position) < 50f)
                {
                    Destroy(Police);
                    GameObject.FindObjectOfType<Game3>().isFinish = true;
                    Destroy(gameObject);
                }



            }
        }


    }
    private void ApplyGravity()
    {
        // �Ʒ� �������� �߷��� �����ݴϴ�.
        float gravity = 9.81f; // �߷��� ����
        Vector3 gravityVector = Vector3.down * gravity;
        if(controller.enabled == true)
            controller.Move(gravityVector * Time.deltaTime);
    }
    private void Jump()
    {
        // ĳ���� ��Ʈ�ѷ��� ���� ���� �������� ���� ���� �����մϴ�.
        float jumpForce = 200; // ������ ������ ���� ũ��
        Vector3 jumpVector = Vector3.up * jumpForce;
        controller.Move(jumpVector * Time.deltaTime);
    }





    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<addForce>() != null)
        {

            foreach (addForce tw in tower)
            {
                if (tw.gameObject.GetComponent<Rigidbody>() != null)
                    tw.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                //tw.gameObject.tag = "Ground";
            }
            if(!isDone)
                controller.enabled = true;
            isDone = true;

        }



    }
   
    
}