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
        UduinoManager.Instance.OnDataReceived -= DataParse; // Arduino로부터 오는 Log를 분석한다.  
        UduinoManager.Instance.OnDataReceived += DataParse; // Arduino로부터 오는 Log를 분석한다.  
        UduinoManager.Instance.alwaysRead = true;
    }

    void Update()
    {
       
    }

    void DataParse(string data, UduinoDevice device)
    {
        Debug.Log(data);
        string[] msg; // 넘어온 문자열 분석 시작, 대부분의 log들은 Game/x/ .. 식으로 명사/x/서술 식으로 표현
        msg = data.Split('/');
        if (msg[0] == "Game") // Game일 경우 모니터 센서이므로, 게임 시작 관련 이야기, iBall pBall 구분에 따른 데이터 관리 시작    
        {
            switch (msg[1])
            {
                case "1":     // 로그가 Game/1 일때 게임이 시작됨 
                    gameManager.Game1Start(); // 각 센서가 발생시킨 공이 iBall인지, pBall인지는 Game 내부에서 처리할 수 있을듯, 그것까지 게임의 일부  
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
