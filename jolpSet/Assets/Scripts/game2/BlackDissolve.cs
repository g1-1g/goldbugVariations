using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackDissolve : MonoBehaviour
{
    Image img;
    float dissolveAmount = 50; // 디졸브 속도

    float BlackA = 255; // 디졸브 효과의 경과 시간
    private bool isDissolving = false; // 디졸브가 진행 중인지 여부

    private void Start()
    {
        img = gameObject.GetComponent<Image>();
    }
    void Update()
    {
        if (isDissolving)
        {
            // 디졸브 효과가 진행 중일 때 투명도를 조정하여 디졸브 효과를 만듭니다.
            BlackA -= (dissolveAmount * Time.deltaTime);
            Color newColor = img.color;
            newColor.a = BlackA/255f;
            img.color = newColor;

            // 디졸브 효과가 완료되면 디졸브를 중지합니다.
            if (BlackA <= 0)
            {
                isDissolving = false;
                
                gameObject.SetActive(false);
                img.color = new Color(0, 0, 0, 1);
                BlackA = 255;

            }
        }
    }

    // 외부에서 호출하여 디졸브 효과를 시작합니다.
    public void StartDissolve()
    {
        isDissolving = true;
       
    }
}
