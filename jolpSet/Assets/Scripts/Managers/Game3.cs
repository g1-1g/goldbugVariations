using System.Collections;
using System.Collections.Generic;
using Uduino;
using UnityEngine;
using UnityEngine.Video;

public class Game3 : MonoBehaviour
{
    [SerializeField]
    int ErrorN = 0;

   

    GameObject sphere3B;
    GameObject ShootingBall;
    GameObject Room;

    GameObject Cam3ZO;
    Animator Cam3ZOAnim;

    //Game3 구성 요소 정리: 붕괴 레일, 시지프스 인간, 슬라이더, 카메라 버그 게임이 끝나고 난 뒤 일반 게임 상황으로 돌아가는 init 함수를 만들자 
    [SerializeField]
    GameObject collapseRail;
    [SerializeField]
    GameObject slider;
    [SerializeField]
    Camera camera_3;
    [SerializeField]
    GameObject blackPerson;

    GameObject ShootingBallSource;
    GameObject RoomSource;
    GameObject COCBall;
    public bool isFinish = false;

    GameObject LoadedSphere;
    GameObject CollapseBall;
    GameObject sphere3E;

    // bool isRotating = false;
    public float rotationSpeed = 1.0f; // 회전 속도
    public Quaternion targetRotation; // 목표 회전
    GameObject sphere3;

    int RandomN = 0;
    bool RandomSet; //������ �����Ǿ����� Ȯ��

    GameObject BallStart;
    GameObject ShootingPos;
    GameObject RoomPos;
    GameObject spotLight;

    void Start()
    {
   

        collapseRail = GameObject.Find("Rail2");
        slider = GameObject.Find("Slider");
        camera_3= GameObject.Find("Camera_3").GetComponent<Camera>();

        CollapseBall = Resources.Load<GameObject>("Prefabs/Sphere_3_Collapse");
        LoadedSphere = Resources.Load<GameObject>("Prefabs/Sphere_3");
        sphere3E = Resources.Load<GameObject>("Prefabs/SphereE_3");
        ShootingBallSource = Resources.Load<GameObject>("Prefabs/ShootingBall for MOM");
        RoomSource = Resources.Load<GameObject>("Prefabs/Interior");
        COCBall = Resources.Load<GameObject>("Prefabs/COCBall");

        BallStart = GameObject.Find("StartPos3");
        ShootingPos = GameObject.Find("ShootingPosition");
        RoomPos = GameObject.Find("RoomPos");
        spotLight = GameObject.Find("Spot Light");

        Cam3ZO = GameObject.Find("Camera_3-2");
        Cam3ZOAnim = Cam3ZO.GetComponent<Animator>();
        Cam3ZO.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown("3"))
        {
            Debug.Log("space pressed");
            GameStart();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameEnd();
        }

        //화면 안에 화면
        if (isFinish)
        {
            
            Cam3ZO.SetActive(false);
            isFinish = false;
            //Destroy(sphere3B);
            Destroy(Room);
            GameEnd(); // 본인 메서드임 

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameEnd();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameEnd(); ;
        }



    } 
      
    public void GameStart()
    {

        //   if (LoadedSphere == null)
        //   {
        //       Debug.Log("failed");
        //   }
        //   if (LoadedSphere != null)
        //   {
        //       Debug.Log("Success");
        //       sphere3 = GameObject.Instantiate(LoadedSphere, BallStart.transform);
        //       sphere3.GetComponent<Rigidbody>().AddForce(new Vector3(-10000f, 0, 0));
        //
        //   }
            if (!RandomSet)
            {
                RandomN = Random.Range(0, 4); //랜덤 결정
                //RandomN = ErrorN;
                RandomSet = true;
                Debug.Log(RandomN);
            }
            //랜덤시 지워야 할 거
            //RandomN = ErrorN;

            switch (RandomN)
            {
                case 0:
                    sphere3 = GameObject.Instantiate(sphere3E, BallStart.transform);
                    sphere3.GetComponent<Rigidbody>().AddForce(new Vector3(-10000f, 0, 0));
                    RandomSet = false;

                    break;
                case 1:
                    //화면 안에 화면
                    sphere3B = GameObject.Instantiate(COCBall, BallStart.transform);
                    sphere3B.GetComponent<Rigidbody>().AddForce(new Vector3(-10000f, 0, 0));

                    Room = GameObject.Instantiate(RoomSource, RoomPos.transform);
                    StartCoroutine(CameraOfCamera());
                    RandomSet = false;
                    break;
                case 2:
                     GameObject SB = Resources.Load<GameObject>("Prefabs/Sphere_3_Sisyphe");
                     if (LoadedSphere == null)
                     {
                         Debug.Log("failed");
                     }
                     if (LoadedSphere != null)
                     {
                         Debug.Log("시지프스 rock 생성!! ");
                         sphere3 = GameObject.Instantiate(SB, BallStart.transform.position, Quaternion.Euler(0, 0, 0), transform);
                         sphere3.GetComponent<Rigidbody>().AddForce(new Vector3(-10000f, 0, 0));
                     }
                    RandomSet = false;
                    break;
                case 3:
                    if (CollapseBall == null)
                    {
                        Debug.Log("failed");
                    }
                    if (CollapseBall != null)
                    {
                        Debug.Log("Success");
                        sphere3 = GameObject.Instantiate(CollapseBall, BallStart.transform.position, Quaternion.Euler(0, 0, 0), transform);
                        sphere3.GetComponent<Rigidbody>().AddForce(new Vector3(-100000f, 0, 0));

                    }
                    RandomSet = false;
                    break;
                
            }

    }
        

    public void GameInit() 
    {
        slider.transform.position = new Vector3(1647.09033f, -14.7507172f, -5.72717285f);
        collapseRail.transform.position = new Vector3(1662.53638f, -2.25071716f, 12.9571075f);
        collapseRail.transform.rotation = Quaternion.Euler(0,180,0);
        camera_3.transform.position = new Vector3(1644.23914f, 10.4733124f, -20.5831795f);
        camera_3.transform.rotation = Quaternion.Euler(35, 0, 0);
        spotLight.GetComponent<Light>().enabled = true;
        spotLight.transform.position = new Vector3(1642.45996f, -46.080719f, -33.6882286f);

    }

    public void GameEnd() // 일반 시나리오 종료될 때 호출되는, 일반 게임이 끝났을 
    {

        //UduinoDevice crt_2 = UduinoManager.Instance.GetBoard("CRT_2");
        //UduinoManager.Instance.sendCommand(crt_2, "Game2/Motor");

        UduinoDevice CRT3_M = UduinoManager.Instance.GetBoard("CRT3_M");
        UduinoManager.Instance.sendCommand(CRT3_M, "Motorex");
        Debug.Log("motor move");
        
        Debug.Log("Game3 End!!");


    }
    IEnumerator CameraOfCamera()
{
    yield return new WaitForSeconds(2f);
    Cam3ZO.SetActive(true);
    Cam3ZOAnim.Play("CameraOfCamera");
    yield return new WaitForSeconds(3f);
    ShootingBall = GameObject.Instantiate(ShootingBallSource, ShootingPos.transform.position, Quaternion.identity);
    ShootingBall.GetComponent<Rigidbody>().AddForce(((Vector3.forward) * 4 + Vector3.right + Vector3.up * 0.3f) * 1000);

}
}
