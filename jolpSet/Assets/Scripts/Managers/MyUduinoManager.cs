using System.Collections;
using System.Collections.Generic;
using Uduino;
using UnityEngine;

public class MyUduinoManager : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    
    void Start()
    {
        UduinoManager.Instance.OnDataReceived -= DataParse; // Arduino�κ��� ���� Log�� �м��Ѵ�.  
        UduinoManager.Instance.OnDataReceived += DataParse; // Arduino�κ��� ���� Log�� �м��Ѵ�.  
        UduinoManager.Instance.alwaysRead = true;
    }

    void Update()
    {
       
    }

    void DataParse(string data, UduinoDevice device)
    {
        Debug.Log(data);
        string[] msg; // �Ѿ�� ���ڿ� �м� ����, ��κ��� log���� Game/x/ .. ������ ���/x/���� ������ ǥ��
        msg = data.Split('/');
        if (msg[0] == "Game") // Game�� ��� ����� �����̹Ƿ�, ���� ���� ���� �̾߱�, iBall pBall ���п� ���� ������ ���� ����    
        {
            switch (msg[1])
            {
                case "1":     // �αװ� Game/1 �϶� ������ ���۵� 
                    gameManager.Game1Start(); // �� ������ �߻���Ų ���� iBall����, pBall������ Game ���ο��� ó���� �� ������, �װͱ��� ������ �Ϻ�  
                    break;
                case "2":
                    gameManager.Game2Start();
                    break;
                case "3":
                    gameManager.Game3Start();
                    break;

            }
        }
    }
}
