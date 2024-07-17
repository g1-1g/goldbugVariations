using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBallBlink : MonoBehaviour
{

    // 색상을 조절할 머티리얼
    public MeshRenderer targetMaterial;

    // RGB 값의 범위
    float minValue = 58f;
    float maxValue = 200f;

    // 각 RGB 값의 현재 상태
    float currentR = 58f;
    float currentG = 58f;
    float currentB = 58f;

    // 변경할 RGB 값의 증가량
    float changeSpeed = 200;

    // 현재 변경 중인 색상 인덱스
    //int currentColorIndex = 0;

    // 색상 증가 여부 플래그
    bool increasingR = true;
    bool increasingG = false;
    bool increasingB = false;
    int i = 0;

    void Start()
    {
        targetMaterial = GetComponent<MeshRenderer>();

    }

    void Update()
    {
        if (i == 0)
        {
            UpdateColor(ref currentR, ref increasingR);
        }
        else if (i == 1)
        {
            UpdateColor(ref currentG, ref increasingG);

        }
        else
        {
            UpdateColor(ref currentB, ref increasingB);
        }



        // 색상 적용
        Color newColor = new Color(currentR / 255f, currentG / 255f, currentB / 255f);
        targetMaterial.material.color = newColor;




    }

    void UpdateColor(ref float currentColor, ref bool increasing)
    {
        if (increasing)
        {
            if (currentColor < maxValue)
            {
                currentColor += changeSpeed * Time.deltaTime;
            }
            else
            {
                increasing = false;
                if (i < 2)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
        }
        else
        {
            if (currentColor > minValue)
            {
                currentColor -= changeSpeed * Time.deltaTime;
            }
            else
            {
                increasing = true;
                if (i < 2)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
        }
    }
}
