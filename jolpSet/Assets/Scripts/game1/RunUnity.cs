using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RunUnity : MonoBehaviour
{

    MeshRenderer frameInMat;
    [SerializeField]
    Material[] Wmaterials;
    int clickCount = 0;

    [SerializeField]
    GameObject video;
    GameObject videoOn;

    Vector3 BallReturnPos;
    GameObject Ball;

    [SerializeField]
    RenderTexture RT;

    GameObject UnityErrorBall;

    void Start()
    {
        frameInMat = gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>();
        BallReturnPos = GameObject.Find("Sphere1ForUnityEditor").transform.position;
        UnityErrorBall = Resources.Load<GameObject>("Prefabs/Sphere1ForUnityEditor2");
    }

    void Update()
    {
        //video 재생 후 카운트 초기화
        if (clickCount >= 2)
        {
           
            clickCount = 0;
            GameObject.FindObjectOfType<Game1>().TimeTextUI.SetActive(false);
            StartCoroutine(videoPlay());

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        frameInMat.material = Wmaterials[1];
        Ball = collision.gameObject;
        clickCount++;

    }
    IEnumerator videoPlay()
    {
        
        RT.Release();
        video.SetActive(true);

        yield return new WaitForSeconds(2f);
        //2초 후 재생 중지
        video.SetActive(false);

        
        GameObject.Find("Stage1EditorErrorCamera").GetComponent<Camera>().enabled = false;
        
        frameInMat.material = Wmaterials[0];
        Ball.GetComponent<Animator>().enabled = false;
        Ball.transform.position = BallReturnPos;
        clickCount = 0;
        GameObject.FindObjectOfType<UnityButtonChange>().Root.GetComponent<Animator>().SetBool("isClose", false);
        Ball.GetComponent<Rigidbody>().isKinematic = true;
       
        GameObject.Find("WindowCollider").SetActive(false);

        yield return new WaitForSeconds(0.5f);
        GameObject.Instantiate(UnityErrorBall, GameObject.FindObjectOfType<Game1>().BallStart.transform);
    }
}
