
using System.Collections;
using System.Collections.Generic;
using Uduino;
using Unity.VisualScripting;
//using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.Video;

public class Game1 : MonoBehaviour
{
    [SerializeField]
    int ErrorN = 0;

    GameObject sphere1;
    GameObject sphere1E;
    GameObject LoadedSphere;
    GameObject UnityErrorBall;
    GameObject RoadErrorBall;
    int RandomN = 0;
    bool RandomSet; //������ �����Ǿ����� Ȯ��

    public GameObject BallStart;
    GameObject BallStartM;

    [SerializeField]
    RenderTexture RT; //���������� ��� �����ؽ���
    [SerializeField]
    GameObject videoOn;
    [SerializeField]
    GameObject videoCollider;

    public GameObject TimeTextUI;

    [SerializeField]
    GameObject BlakOut; //blackout UI

    void Start()
    {

        UnityErrorBall = Resources.Load<GameObject>("Prefabs/Sphere1ForUnityEditor");
        RoadErrorBall = Resources.Load<GameObject>("Prefabs/Sphere1ForRoadError");
        LoadedSphere = Resources.Load<GameObject>("Prefabs/Sphere_1");
        sphere1E = Resources.Load<GameObject>("Prefabs/SphereE_1");
        BallStartM = GameObject.Find("BallStartM");
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Debug.Log("1 pressed");
            GameStart();

            //IGameEnd();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameEnd();
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
       //       StartCoroutine(casep());
       //   }
        {
            if (!RandomSet)
            {
                RandomN = Random.Range(0, 4); //랜덤 설정
                //RandomN = ErrorN;
                RandomSet = true;
                Debug.Log(RandomN);
            }
            //랜덤시 지워야 할 거
            //RandomN = ErrorN;

            switch (RandomN)
            {
                case 0:
                    //일반공
                    StartCoroutine(case0());
                    /*GameObject.Instantiate(sphere1E, BallStart.transform);
                    RandomSet = false;*/
                break;
                case 1:
                    //로드에러
                    StartCoroutine(case1());
                    /*sphere1 = GameObject.Instantiate(RoadErrorBall, BallStart.transform);
                    StartCoroutine(videoPlay());
                    RandomSet = false;*/
                    break;
                case 2:
                    //유니티 에디터
                    StartCoroutine(case2());
                    /*sphere1 = GameObject.Instantiate(UnityErrorBall, BallStart.transform);
                    StartCoroutine(ErrorRoad());
                    RandomSet = false;*/
                    break;
                case 3:
                    //Red Only
                    StartCoroutine(case3());
                    /*sphere1 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Sphere1ForRedOnly"), BallStart.transform);
                    RandomSet = false;*/
                    break;
            }
        }
    }

    public void GameEnd() // 일반 시나리오 종료될 때 호출되는, 일반 게임이 끝났을 
    {
        UduinoDevice crt_1 = UduinoManager.Instance.GetBoard("CRT_1");
        UduinoManager.Instance.sendCommand(crt_1, "Game1/Motor");
        Debug.Log("Game1 End!!");
    }

    IEnumerator videoPlay()
    {
        yield return new WaitForSeconds(1f);
        videoOn.SetActive(true);
        videoCollider.SetActive(true);
        RT.Release();
        videoOn.transform.GetComponentInChildren<VideoPlayer>().Play();
        yield return new WaitForSeconds(4f);
        //2�� �� ��� ����
        videoOn.SetActive(false);
        videoCollider.SetActive(false);
        //PGameEnd();


    }

    IEnumerator ErrorRoad()
    {
        yield return new WaitForSeconds(4.5f);
        sphere1.GetComponent<Rigidbody>().isKinematic = true; //������ٵ� ��� ����
        GameObject.Find("UnityEditorError").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        BlakOut.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        BlakOut.SetActive(false);
        sphere1.GetComponent<Rigidbody>().isKinematic = false;

        GameObject.Find("Stage1EditorErrorCamera").GetComponent<Camera>().enabled = true;//Editor ī�޶�
        TimeTextUI.SetActive(true);
        yield return new WaitForSeconds(3f);
        Debug.Log("yes");

        GameObject.Find("Sphere1ForUnityEditor").GetComponent<Animator>().Play("New Animation", -1, 0f);
        GameObject.Find("Sphere1ForUnityEditor").GetComponent<Animator>().enabled = true;
        GameObject.Find("Sphere1ForUnityEditor").GetComponent<Rigidbody>().isKinematic = false;



    }
    IEnumerator casep()
    {
        yield return new WaitForSeconds(0.5f);
        sphere1 = GameObject.Instantiate(LoadedSphere, BallStart.transform);
    }
    IEnumerator case0()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Instantiate(sphere1E, BallStart.transform);
        RandomSet = false;
    }
    IEnumerator case1()
    {
        yield return new WaitForSeconds(0.5f);
        sphere1 = GameObject.Instantiate(RoadErrorBall, BallStart.transform);
        StartCoroutine(videoPlay());
        RandomSet = false;

    }
    IEnumerator case2()
    {
        yield return new WaitForSeconds(0.5f);
        sphere1 = GameObject.Instantiate(UnityErrorBall, BallStart.transform);
        StartCoroutine(ErrorRoad());
        RandomSet = false;
    }
    IEnumerator case3()
    {
        yield return new WaitForSeconds(0.5f);
        sphere1 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Sphere1ForRedOnly"), BallStart.transform);
        RandomSet = false;
    }
}