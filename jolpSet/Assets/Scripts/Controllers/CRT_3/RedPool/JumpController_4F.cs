using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController_4F : MonoBehaviour
{
    [SerializeField]
    bool isJumpStart=false;
    float timeElapsed;
    [SerializeField]
    float randomValue;
    [SerializeField]
    float randomValue2;
    void Start()
    {
        //  randomValue2 = Random.Range(Random.Range(-4f, -3f), Random.Range(3f, 4f));
        randomValue2 = Random.Range(3f, 5f);
    }

    void Update()
    {
        if (isJumpStart) 
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed > randomValue) 
            {
                randomValue2 = Random.Range(-4f, 4f);
                GetComponent<Rigidbody>().AddForce(new Vector3(randomValue2 * 5000, 3000, randomValue2 * 5000));
                // GetComponent<Rigidbody>().AddForce(new Vector3(randomValue2*10000, 80000, randomValue2 * 1000));
                timeElapsed = 0;
            }
        }
    }

    public void JumpStart(float random) 
    {
        isJumpStart = true;
        randomValue = random;
    }

    public void JumpEnd()
    {
        isJumpStart = false;
    }
}
