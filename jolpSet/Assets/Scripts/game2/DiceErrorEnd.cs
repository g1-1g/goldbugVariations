using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class DiceErrorEnd : MonoBehaviour
{
    int BallCount;
    GameObject camera2;
    Vector3 camera2Pos;
    Quaternion camera2Ro;
    //Scrollbar roading;

    //bool LightBump;
    Light lt;
    //bool increase = true;
    //public int dropBall = 0;


    void Start()
    {
        BallCount = 0;
        camera2 = GameObject.Find("Camera_2");
        //LightBump = false;
        lt = GameObject.FindObjectOfType<caveBlinkle>().gameObject.GetComponent<Light>();
        camera2Pos = camera2.transform.position;
        camera2Ro = camera2.transform.rotation;
        //roading = GameObject.FindObjectOfType<Scrollbar>();
        //roading.gameObject.SetActive(false);

    }

    void Update()
    {
        if (BallCount >= 21)
        {
           
            BallCount = 0;
            StartCoroutine(goBack());
        }
        /*else if (LightBump)
        {
            
            if (lt.intensity > 2.0f)
            {
                increase = false;

            }
            if (increase)
            {
                
                lt.intensity += 0.7f * Time.deltaTime;
            }
            else
            {
                lt.intensity -= 2f * Time.deltaTime;
            }

            Debug.Log(lt.intensity);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        BallCount++;
        //roading.gameObject.SetActive(true);
        //roading.size = BallCount / 21f;

        Debug.Log(BallCount);
    }
    IEnumerator goBack()
    {
        //LightBump = true;
        //camera2.GetComponent<Animator>().enabled = false; ;


        GameObject.FindObjectOfType<Game2>().GameEnd();

        yield return new WaitForSeconds(3f);
        camera2.GetComponent<Animator>().Play("Camera2DiceErrorStart");
        GameObject.FindObjectOfType<caveBlinkle>().enabled = false;
        Destroy(GameObject.FindObjectOfType<DiceBodyController>().gameObject);
        //LightBump = false;
        lt.intensity = 0;
        //dropBall = 0;


        camera2.transform.position = camera2Pos;
        camera2.transform.rotation = camera2Ro;
    }
}
