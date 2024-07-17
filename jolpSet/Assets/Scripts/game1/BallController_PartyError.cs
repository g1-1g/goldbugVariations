using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class BallController_PartyError : MonoBehaviour
{
    Material[] mat;
    Animation Anim;
    bool played = false;
    GameObject RoomLight;
    Rigidbody rb;
    AudioSource[] audioSources;
    SphereCollider SphereCollider;
    GameObject SpotLight;
    GameObject targetPosition;
        

    [SerializeField]
    float PlayTIme = 5.0f;
    void Start()
    {
        targetPosition = GameObject.Find("Target1M");
        mat = new Material[2];
        mat[0] = Resources.Load<Material>("Materials/Red");
        mat[1] = Resources.Load<Material>("Materials/MirrorBall");
        gameObject.GetComponent<MeshRenderer>().material = mat[0];
        rb = gameObject.GetComponent<Rigidbody>();
        Anim = gameObject.GetComponent<Animation>();
        RoomLight = GameObject.Find("Point Light_1");
        audioSources = gameObject.GetComponents<AudioSource>();
        //audioSources[0].clip = Resources.Load<AudioClip>("06 버튼선택음");
        //audioSources[1].clip = Resources.Load<AudioClip>("Abba - Dancing Queen (Official Music Video Remastered)");
        SphereCollider = gameObject.GetComponent<SphereCollider>();
        SpotLight = gameObject.GetComponentInChildren<Light>().gameObject;
        SpotLight.SetActive(false);
        audioSources[0].clip = Resources.Load<AudioClip>("06 버튼선택음");
        audioSources[1].clip = Resources.Load<AudioClip>("Abba - Dancing Queen (Official Music Video Remastered)");

        Anim.Play();
    }

    void Update()
    {
     
        if (!played)
        {
            //Rigidbody.AddForce(new Vector3(0, -3000.0f, 0));
               
          
        }

        
    }

    private void FixedUpdate()
    {
        if (!played)
            rb.AddForce(new Vector3(0, -8000.0f, 0)*Time.deltaTime);
    }

    IEnumerator PartyStart()
    {
           
             played = true;
            //rb.AddForce(new Vector3(0, 9000f, 0));
               
            //yield return new WaitForSeconds(1f);
            

            rb.isKinematic = true;
            SphereCollider.material.bounciness = 0;
            //yield return new WaitForSeconds(1f);

            audioSources[1].Play();
            yield return new WaitForSeconds(1f);
            gameObject.transform.rotation = new Quaternion(0,0,0, 0);

            gameObject.GetComponent<MeshRenderer>().material = mat[1];
            gameObject.GetComponent<MirrorBallBlink>().enabled = true;
            SpotLight.SetActive(true);



        yield return new WaitForSeconds(1f);

             yield return new WaitForSeconds(PlayTIme);
            audioSources[1].Stop();
            gameObject.GetComponent<MeshRenderer>().material = mat[0];
            gameObject.GetComponent<MirrorBallBlink>().enabled = false;
            SpotLight.SetActive(false);
            RoomLight.GetComponent<Light>().intensity = 1.0f;
            yield return new WaitForSeconds(1f);
            rb.isKinematic = false;
      


    }
        


   
    private void OnTriggerEnter(Collider other)
    {
        /*if(other.CompareTag("startParty") && !played)
            StartCoroutine(PartyStart());
            rb.AddForce((targetPosition.transform.position - transform.position).normalized * 3000);*/
        //if (other.CompareTag("PartyReady") && !played)
            //rb.AddForce(new Vector3(1000,8000, 3000));
                    
    }

    void trunOff()
    {
        RoomLight.GetComponent<Light>().intensity = 0.2f;
        audioSources[0].Play();
        StartCoroutine(PartyStart());
    }
}
