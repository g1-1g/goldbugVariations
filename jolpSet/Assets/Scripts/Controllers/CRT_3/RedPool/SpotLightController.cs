using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{
    [SerializeField]
    bool isLightMoving1=false;
    [SerializeField]
    bool isLightMoving2 = false;
    
    [SerializeField]
    bool isWhiteDetected=false;
    [SerializeField]
    bool isRedBallJumped = false;
    [SerializeField]
    float angleDistance;
    [SerializeField]
    GameObject sphere_3;
    [SerializeField]
    float timeElapsed;
    [SerializeField]
    Game3 game3;

    GameObject[] movingRedBalls4F;
    GameObject[] movingRedBalls3F;

    void Start()
    {
       game3 = transform.parent.GetComponent<Game3>();
    }

    void Update()
    {

        if (isLightMoving1)
        {
            timeElapsed += Time.deltaTime;
            transform.position += 0.1f * new Vector3(Mathf.Cos(timeElapsed*0.8f), 0, Mathf.Sin(timeElapsed*0.8f));
            if (timeElapsed > 4.5f)
            {
                isLightMoving1 = false;
                isLightMoving2 = true;
                timeElapsed = 0;
            }
        }
        else if (isLightMoving2)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > 2)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(sphere_3.transform.position - transform.position), 3f * Time.deltaTime);
                if (timeElapsed > 3.5f)
                {
                    isLightMoving2 = false;
                    isWhiteDetected = true; // 빨간 공들 잠식 시작  
                    timeElapsed = 0;
                }
            }

        }

        else if (isWhiteDetected)
        {
            if (sphere_3 != null)
            {
                transform.LookAt(sphere_3.transform.position);
            }

            movingRedBalls4F = GameObject.FindGameObjectsWithTag("4F");
            movingRedBalls3F = GameObject.FindGameObjectsWithTag("3.5F");

            for (int i = 0; i < movingRedBalls3F.Length; i++)
            {
                if (movingRedBalls3F[i].name == "3.5F_Left")
                {
                    movingRedBalls3F[i].GetComponent<JumpController_3F_L>().JumpStart(Random.Range(Random.Range(1f,2),3.0f));
                }
                else 
                {
                    movingRedBalls3F[i].GetComponent<JumpController_3F_R>().JumpStart(Random.Range(Random.Range(1f,2), 3.0f));
                }
                //JumpController_3F controller = movingRedBalls3F[i].GetComponent<JumpController_3F>();
                //if (controller != null) { controller.JumpStart(Random.Range(0.5f, 5.0f)); } else { Debug.Log("null3333"); }
            }

            for (int i = 0; i < movingRedBalls4F.Length; i++)
            {
                JumpController_4F controller2 = movingRedBalls4F[i].GetComponent<JumpController_4F>();
                if (controller2 != null) { controller2.JumpStart(Random.Range(Random.Range(0, 1), 5.0f)); } else { Debug.Log("null44444"); }
            }
            isWhiteDetected = false;
            isRedBallJumped = true;
        }
        else if (isRedBallJumped) 
        {
            if (sphere_3 != null) 
            {
                transform.LookAt(sphere_3.transform.position);
            }
            timeElapsed += Time.deltaTime;
            if (timeElapsed < 4f)
            {
                sphere_3.GetComponent<Rigidbody>().AddForce(new Vector3(0, -10000, 1000));
            }
            else if (timeElapsed < 12f)
            {
                sphere_3.GetComponent<Rigidbody>().AddForce(new Vector3(0, -16000, 1000));
            }
            else if (timeElapsed > 12f&&timeElapsed<16)
            {

                for (int i = 0; i < movingRedBalls3F.Length; i++)
                {
                    if (movingRedBalls3F[i].name == "3.5F_Left")
                    {
                        movingRedBalls3F[i].GetComponent<JumpController_3F_L>().JumpEnd();
                    }
                    else
                    {
                        movingRedBalls3F[i].GetComponent<JumpController_3F_R>().JumpEnd();
                    }
                    // JumpController_3F controller = movingRedBalls3F[i].GetComponent<JumpController_3F>();
                    // if (controller != null) { controller.JumpEnd(); } else { Debug.Log("null3333"); }
                }

                for (int i = 0; i < movingRedBalls4F.Length; i++)
                {
                    JumpController_4F controller2 = movingRedBalls4F[i].GetComponent<JumpController_4F>();
                    if (controller2 != null) { controller2.JumpEnd(); } else { Debug.Log("null44444"); }
                }
                
            }
            else if(timeElapsed<20) 
            {
                //timeElapsed += Time.deltaTime;
                if (sphere_3 != null)
                {
                    transform.LookAt(sphere_3.transform.position);
                }


                GetComponent<Light>().enabled = false;
                Object.Destroy(sphere_3);
                if (timeElapsed > 18) 
                {
                    for (int i = 0; i < movingRedBalls4F.Length; i++)
                    {
                        movingRedBalls4F[i].GetComponent<BallInit>().InitFirstPos();
                    }
                    for (int i = 0; i < movingRedBalls3F.Length; i++)
                    {
                        movingRedBalls3F[i].GetComponent<BallInit>().InitFirstPos();
                    }
                    game3.GameInit();
                    isRedBallJumped = false;
                    timeElapsed = 0;
                    game3.GameEnd();
                   
                
                    //movingRedBalls3F
                }

            }
        }

        }
        
        // if (isLightMoving1)
       // {
       //
       //
       //     transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(30, 30, 0)), 1f * Time.deltaTime);
       //     if (Quaternion.Angle(transform.rotation, Quaternion.Euler(new Vector3(30, 30, 0))) < 1.0f)
       //     {
       //         isLightMoving1 = false;
       //         isLightMoving2 = true;
       //     }
       // }
       // else if (isLightMoving2 && !isWhiteDetected) // detection 구역  
       // {
       //     Quaternion a = Quaternion.Euler(sphere_3.transform.position - transform.position);
       //     angleDistance = Quaternion.Angle(transform.rotation, a); // 각도 차이는 현재 조명의 각도와 조명에서 공 바라보는 각도의 차이 
       //
       //     transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(60, -30, 0)), 1f * Time.deltaTime);
       //     if (angleDistance < 3.0f)
       //     {
       //         isWhiteDetected = true; // 공들 뛰기 시작해야 함 
       //         isLightMoving2 = false;
       //         step3 = true;
       //     }
       // }
       // else if (step3)
       // {
       //     transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(sphere_3.transform.position - transform.position), 3f * Time.deltaTime);
       //     if (Quaternion.Angle(transform.rotation, Quaternion.Euler(sphere_3.transform.position - transform.position)) < 1.0f) 
       //     {
       //         step3 = true; // 완전 가까이 비추기 
       //     }
       // }

    

    public void LightMovingStart() 
    {
        isLightMoving1 = true;
        if (sphere_3 == null) 
        {
            sphere_3 = GameObject.FindWithTag("CollapseBall");
        }
    }
}
