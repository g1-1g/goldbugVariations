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
        // ���� ���� ���� üũ �� ����
        if (isGround) // KeyCode.Space ��ſ� ������ ���� Ű �Է� ������ ����ϼ���
        {
            rb.AddForce(Vector3.up * jumpPowerC, ForceMode.Impulse);
            isGround = false; // ���� ���� �� ��� ���� ���� ���¸� false�� ����
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true; // ���� ����� ���� ���� ���� ���·� ����
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false; // ������ ����� �� ���� �Ұ��� ���·� ����
        }
    }
    

   
    void anmimatorOff()
    {
        gameObject.GetComponent<Animator>().enabled = false;

    }
  
}
