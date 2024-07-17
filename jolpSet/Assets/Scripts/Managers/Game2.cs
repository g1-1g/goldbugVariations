using System.Collections;
using System.Collections.Generic;
using Uduino;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Game2 : MonoBehaviour
{

    [SerializeField]
    int ErrorN = 0;



    [SerializeField]
    GameObject Bm;
    GameObject sphere2;
    GameObject sphere2B;
    GameObject sphere2E;



    GameObject Dice;
    GameObject LoadedSphere;
    GameObject gegooriBall;

    [SerializeField]
    GameObject CircleVideo;
    VideoPlayer CircleVP;

    [SerializeField]
    GameObject BlakOut; //blackout UI



    int RandomN = 0;
    bool RandomSet; //������ �����Ǿ����� Ȯ��

    public GameObject BallStart;

    void Start()
    {
        Dice = Resources.Load<GameObject>("Prefabs/Monitor2_Dice");
        LoadedSphere = Resources.Load<GameObject>("Prefabs/Sphere_2");
        gegooriBall = Resources.Load<GameObject>("Prefabs/FrogBall");
        CircleVP = CircleVideo.transform.GetComponentInChildren<VideoPlayer>();
        sphere2E = Resources.Load<GameObject>("Prefabs/SphereE_2");


    }

    void Update()
    {
        if (Input.GetKeyDown("2"))
        {
            Debug.Log("2 pressed");
            GameStart();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameEnd();
        }
    }
    public void GameStart()
    {
      //  if (LoadedSphere == null)
      //  {
      //      Debug.Log("failed");
      //  }
      //  if (LoadedSphere != null)
      //  {
      //      Debug.Log("Success");
      //      sphere2 = GameObject.Instantiate(LoadedSphere, BallStart.transform);
      //      sphere2.GetComponentInChildren<Rigidbody>().AddForce(new Vector3(10000f, 0, 0));
      //  }
        if (!RandomSet)
        {
            RandomN = Random.Range(0, 3); //랜덤 결정
                                          // RandomN = ErrorN;
            RandomSet = true;
            Debug.Log(RandomN);
        }
        //랜덤시 지워야 할 거
        // RandomN = ErrorN;

        switch (RandomN)
        {
            case 0:
                sphere2B = GameObject.Instantiate(sphere2E, BallStart.transform);
                sphere2B.GetComponentInChildren<Rigidbody>().AddForce(new Vector3(10000f, 0, 0));
                RandomSet = false;
                break;
            case 1:
                //�ֻ���
                sphere2B = GameObject.Instantiate(Dice, BallStart.transform);
                sphere2B.GetComponentInChildren<Rigidbody>().AddForce(new Vector3(10000f, 0, 0));

                RandomSet = false;
                break;
            case 2:
                //������
                sphere2B = GameObject.Instantiate(gegooriBall, BallStart.transform);
                StartCoroutine(videoPlay());
                RandomSet = false;
                break;


        }



    }

    public void GameEnd()
    {
        UduinoDevice crt_2 = UduinoManager.Instance.GetBoard("CRT_2");
        UduinoManager.Instance.sendCommand(crt_2, "Game2/Motor");
        Debug.Log("Game2 End!!");
    }

    IEnumerator videoPlay()
    {
        //yield return new WaitForSeconds(2f);
        BlakOut.SetActive(true);
        Destroy(sphere2B);
        yield return new WaitForSeconds(2f);
        CircleVideo.SetActive(true);

        CircleVP.targetTexture.Release();
        CircleVP.Play();

        yield return new WaitForSeconds(19f);
        //2�� �� ��� ����
        CircleVideo.SetActive(false);
        yield return new WaitForSeconds(1f);
        BlakOut.GetComponent<BlackDissolve>().StartDissolve();
        GameObject.Instantiate(gegooriBall, BallStart.transform);

    }

}