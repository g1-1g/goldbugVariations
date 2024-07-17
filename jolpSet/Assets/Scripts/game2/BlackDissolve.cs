using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackDissolve : MonoBehaviour
{
    Image img;
    float dissolveAmount = 50; // ������ �ӵ�

    float BlackA = 255; // ������ ȿ���� ��� �ð�
    private bool isDissolving = false; // �����갡 ���� ������ ����

    private void Start()
    {
        img = gameObject.GetComponent<Image>();
    }
    void Update()
    {
        if (isDissolving)
        {
            // ������ ȿ���� ���� ���� �� ������ �����Ͽ� ������ ȿ���� ����ϴ�.
            BlackA -= (dissolveAmount * Time.deltaTime);
            Color newColor = img.color;
            newColor.a = BlackA/255f;
            img.color = newColor;

            // ������ ȿ���� �Ϸ�Ǹ� �����긦 �����մϴ�.
            if (BlackA <= 0)
            {
                isDissolving = false;
                
                gameObject.SetActive(false);
                img.color = new Color(0, 0, 0, 1);
                BlackA = 255;

            }
        }
    }

    // �ܺο��� ȣ���Ͽ� ������ ȿ���� �����մϴ�.
    public void StartDissolve()
    {
        isDissolving = true;
       
    }
}
