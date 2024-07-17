using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBallBlink : MonoBehaviour
{

    // ������ ������ ��Ƽ����
    public MeshRenderer targetMaterial;

    // RGB ���� ����
    float minValue = 58f;
    float maxValue = 200f;

    // �� RGB ���� ���� ����
    float currentR = 58f;
    float currentG = 58f;
    float currentB = 58f;

    // ������ RGB ���� ������
    float changeSpeed = 200;

    // ���� ���� ���� ���� �ε���
    //int currentColorIndex = 0;

    // ���� ���� ���� �÷���
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



        // ���� ����
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
