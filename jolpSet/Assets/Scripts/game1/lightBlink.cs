using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBlink : MonoBehaviour
{
    public float fadeOutDuration = 1.0f;  // ������ �� �ɸ��� �ð� (��)
    public float fadeInDuration = 3.0f;   // ������ �� �ɸ��� �ð� (��)
    private Light lightSource;            // Light ������Ʈ�� ����
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
    float time = 0;


    void Start()
    {
        lightSource = GetComponent<Light>();  // Light ������Ʈ�� �����´�
        StartCoroutine(FlickerLight());       // Coroutine ����
    }

    private void Update()
    {
       if (lightSource != null)
        {
            // ���� ������Ʈ

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
            lightSource.color = newColor;



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
        

    IEnumerator FlickerLight()
    {
            while (true)  // ���� ������ �ݺ�
            {
                time = 0;
                // ����Ʈ�� ������ �Ҵ�

                while (time < fadeInDuration)
                {
                    lightSource.intensity = Mathf.SmoothStep(0.5f, 1.5f, time / fadeInDuration);
                    time += Time.deltaTime;
                    yield return null;
                }

                // ���� ���¸� �����Ѵ�
                //lightSource.intensity = 1;
                //yield return new WaitForSeconds(1.0f);  // 1�ʰ� ��ٸ���
                // ����Ʈ�� ������ ������
                time = 0;
                while (time < fadeOutDuration)
                {
                    lightSource.intensity = Mathf.SmoothStep(1.5f, 0.5f, time / fadeOutDuration);
                    time += Time.deltaTime;
                    yield return null;
                }

                // ���� ���¸� �����Ѵ�
                //lightSource.intensity = 0;
                // return new WaitForSeconds(1.0f);  // 1�ʰ� ��ٸ���

            }
           
    }
    
}
