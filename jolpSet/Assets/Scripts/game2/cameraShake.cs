using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public Transform cameraTransform; // ī�޶��� Transform ������Ʈ
    public float shakeAmount = 0.1f; // ��鸲�� ����
    public float shakeSpeed = 0.1f; // ��鸲�� �ӵ�

    private Vector3 originalPosition; // �ʱ� ��ġ

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent<Transform>();
        }
        originalPosition = cameraTransform.localPosition; // �ʱ� ��ġ ����
    }

    void Update()
    {
        // ������ ���� ��鸲�� �����մϴ�.
        float shakeY = Mathf.PerlinNoise(Time.time * shakeSpeed, 0) * shakeAmount;
        
        // ������ �¿� ��鸲�� �����մϴ�.
        float shakeX = Mathf.PerlinNoise(0, Time.time * shakeSpeed) * shakeAmount;
        shakeSpeed += 1f * Time.deltaTime;
        shakeAmount +=1f * Time.deltaTime;
        // ī�޶��� ��ġ�� ��鸰 ��ŭ �̵���ŵ�ϴ�.
        cameraTransform.localPosition = originalPosition + new Vector3(shakeX, shakeY, 0f);
    }
}
