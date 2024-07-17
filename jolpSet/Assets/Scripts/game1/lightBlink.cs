using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBlink : MonoBehaviour
{
    public float fadeOutDuration = 1.0f;  // 꺼지는 데 걸리는 시간 (초)
    public float fadeInDuration = 3.0f;   // 켜지는 데 걸리는 시간 (초)
    private Light lightSource;            // Light 컴포넌트의 참조
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
    float time = 0;


    void Start()
    {
        lightSource = GetComponent<Light>();  // Light 컴포넌트를 가져온다
        StartCoroutine(FlickerLight());       // Coroutine 시작
    }

    private void Update()
    {
       if (lightSource != null)
        {
            // 색상 업데이트

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
            while (true)  // 무한 루프로 반복
            {
                time = 0;
                // 라이트를 서서히 켠다

                while (time < fadeInDuration)
                {
                    lightSource.intensity = Mathf.SmoothStep(0.5f, 1.5f, time / fadeInDuration);
                    time += Time.deltaTime;
                    yield return null;
                }

                // 켜진 상태를 유지한다
                //lightSource.intensity = 1;
                //yield return new WaitForSeconds(1.0f);  // 1초간 기다린다
                // 라이트를 서서히 꺼진다
                time = 0;
                while (time < fadeOutDuration)
                {
                    lightSource.intensity = Mathf.SmoothStep(1.5f, 0.5f, time / fadeOutDuration);
                    time += Time.deltaTime;
                    yield return null;
                }

                // 꺼진 상태를 유지한다
                //lightSource.intensity = 0;
                // return new WaitForSeconds(1.0f);  // 1초간 기다린다

            }
           
    }
    
}
