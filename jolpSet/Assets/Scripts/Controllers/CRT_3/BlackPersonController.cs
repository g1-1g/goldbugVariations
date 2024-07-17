using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPersonController : MonoBehaviour
{
    [SerializeField]
    GameObject normalRedBall;
    [SerializeField]
    bool isPersonMoving=false;
    [SerializeField]
    float power;
    [SerializeField]
    float upPower;

    GameObject PersonOut;
    void Start()
    {
        normalRedBall = GameObject.FindWithTag("SisypheBall");
        power = 5000;
        upPower = 0.3f;

        PersonOut = GameObject.Find("PersonOutPos");
    }

    void FixedUpdate()
    {
        if (!isPersonMoving) 
        {
            transform.position = PersonOut.transform.position;
        }
       else if (isPersonMoving) 
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(power,0,0));
            transform.position += new Vector3(0,upPower*Time.deltaTime,0);
        }
    }
    public void PersonMovingStart() 
    {
        isPersonMoving = true;
    }
}
