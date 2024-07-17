using System.Collections;
using System.Collections.Generic;
using UnityEditor;

using UnityEngine;
//using UnityEditor.Animations;

public class BallController : MonoBehaviour
{
    Vector3 inputVec;

    bool isGround = false;


    float movePower = 30;

    [SerializeField]
    float jumpPowerC = 30;
    float jumpPower;
    Rigidbody rb;


    [SerializeField]
    //GameObject targetToUnity;
    //GameObject[] ForMoveToUnity;

    /*public AnimationClip clip;
    private GameObjectRecorder m_Recorder;
*/

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //ForMoveToUnity = GameObject.FindGameObjectsWithTag("ForMoveToUnity");

      /*  m_Recorder = new GameObjectRecorder(gameObject);
        m_Recorder.BindComponentsOfType<Transform>(gameObject, true);*/

    }

    void Update()
    {
        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.z = Input.GetAxis("Vertical");







        /*if (Input.GetButton("M"))
        {
            OnDisable();

        }*/






    }

    /*void LateUpdate()
    {
        if (clip == null)
            return;

        // Take a snapshot and record all the bindings values for this frame.
        m_Recorder.TakeSnapshot(Time.deltaTime);
    }
    void OnDisable()
    {
        if (clip == null)
            return;

        if (m_Recorder.isRecording)
        {
            // Save the recorded session to the clip.
            m_Recorder.SaveToClip(clip);
        }
    }*/
    private void FixedUpdate()
    {
        rb.AddForce(inputVec * movePower);
        // 점프 실행 조건 체크 및 실행
        if (isGround) // KeyCode.Space 대신에 적절한 점프 키 입력 조건을 사용하세요
        {
            rb.AddForce(Vector3.up * jumpPowerC, ForceMode.Impulse);
            isGround = false; // 점프 실행 후 즉시 점프 가능 상태를 false로 설정
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true; // 땅에 닿았을 때만 점프 가능 상태로 변경
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false; // 땅에서 벗어났을 때 점프 불가능 상태로 설정
        }
    }
    

   
    void anmimatorOff()
    {
        gameObject.GetComponent<Animator>().enabled = false;

    }
  
}
