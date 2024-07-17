using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BallController_CameraOfCamera : MonoBehaviour
{


    private addForce[] tower; // 탑의 모든 Rigidbody 배열


    Transform[] target;
    GameObject Police;


    int TargetN = 0;
    int Count = 0;
    int CountJump = 0;

    //float jumpP = 100;
    float ballSpeed = 10;
    bool isDone = false; //무너뜨렸는지 여부
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
        // 탑의 모든 자식 오브젝트에서 Rigidbody 컴포넌트를 가져옵니다.
        tower = GameObject.FindObjectsOfType<addForce>();

        // 모든 탑의 Rigidbody를 IsKinematic으로 설정하여 움직이지 않도록 합니다.
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
            
            // 폴짝 폴짝 점프 구현
            if (CountJump % 20 == 0 && TargetN >= 2) // 매번 두 번째 이동 시에만 점프
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
        // 아래 방향으로 중력을 가해줍니다.
        float gravity = 9.81f; // 중력의 세기
        Vector3 gravityVector = Vector3.down * gravity;
        if(controller.enabled == true)
            controller.Move(gravityVector * Time.deltaTime);
    }
    private void Jump()
    {
        // 캐릭터 컨트롤러를 통해 수직 방향으로 힘을 가해 점프합니다.
        float jumpForce = 200; // 점프에 적용할 힘의 크기
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