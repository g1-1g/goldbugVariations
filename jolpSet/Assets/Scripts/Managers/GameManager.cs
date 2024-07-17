using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject CRT_1;
    [SerializeField]
    GameObject CRT_2;
    [SerializeField]
    GameObject CRT_3;
    [SerializeField]
    GameObject Force;
    

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void Game1Start() { CRT_1.GetComponent<Game1>().GameStart();}
    public void Game2Start() { CRT_2.GetComponent<Game2>().GameStart(); }
    public void Game3Start() { CRT_3.GetComponent<Game3>().GameStart(); }

}
