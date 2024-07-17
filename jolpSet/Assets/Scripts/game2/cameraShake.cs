using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public Transform cameraTransform; // 카메라의 Transform 컴포넌트
    public float shakeAmount = 0.1f; // 흔들림의 강도
    public float shakeSpeed = 0.1f; // 흔들림의 속도

    private Vector3 originalPosition; // 초기 위치

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent<Transform>();
        }
        originalPosition = cameraTransform.localPosition; // 초기 위치 저장
    }

    void Update()
    {
        // 랜덤한 상하 흔들림을 생성합니다.
        float shakeY = Mathf.PerlinNoise(Time.time * shakeSpeed, 0) * shakeAmount;
        
        // 랜덤한 좌우 흔들림을 생성합니다.
        float shakeX = Mathf.PerlinNoise(0, Time.time * shakeSpeed) * shakeAmount;
        shakeSpeed += 1f * Time.deltaTime;
        shakeAmount +=1f * Time.deltaTime;
        // 카메라의 위치를 흔들린 만큼 이동시킵니다.
        cameraTransform.localPosition = originalPosition + new Vector3(shakeX, shakeY, 0f);
    }
}
