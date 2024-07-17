using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController_3F_L : MonoBehaviour
{
    [SerializeField]
    bool isJumpStart=false;
    float timeElapsed;
    [SerializeField]
    float randomValue;
    [SerializeField]
    float randomValue2;
    [SerializeField]
    GameObject sphere_3;
    void Start()
    {
        //  randomValue2 = Random.Range(Random.Range(-4f, -3f), Random.Range(3f, 4f));
        randomValue2 = Random.Range(10f, 15f);
    }

    void Update()
    {

        if (isJumpStart)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > randomValue)
            {
                randomValue2 = Random.Range(0f, 4f);
                //  GetComponent<Rigidbody>().AddForce(new Vector3(randomValue2* 2000, 10000, randomValue2 * 2000));
                Vector3 dir = sphere_3.transform.position - transform.position;  // 현 공의 위치 -> 흰 공의 위치 
                dir = dir.normalized * 30000;
                GetComponent<Rigidbody>().AddForce(dir.x * randomValue2,20000, dir.z *randomValue2);
                timeElapsed = 0;
            }
        }

    }

    public void JumpStart(float random) 
    {
        isJumpStart = true;
        randomValue = random;
        sphere_3 = GameObject.FindWithTag("CollapseBall");
    }

    public void JumpEnd() 
    {
        isJumpStart=false;
    }
}
