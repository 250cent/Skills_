using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public int maxStageNum =3;
    public string rank;
    public int tireNum;
    public int engineNum;
    public int stageNum;
    public int sceneNum;
    public int maxToque;
    public int score;
    public int gold = 10000;

    public int[] tireCost =
    {
        0,10000,100000,1000000
    };

    public int[] engineCost =
    {
        0,2000000,20000000
    };

    public bool cheatStore = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        rank = PlayerPrefs.GetString("Rank", "");
    }

    public void InitData()
    {
        tireNum = 0;
        engineNum = 0;
        stageNum = 0;
        maxToque = 0;
        score = 0;
        gold = 10000;
    }

    public void SetRank(string score)
    {
        if (rank == "")
        {
            rank = score;
        }
        else
        {
            rank += "|" + score;
        }
    }

    public void ChangeScene(int num)
    {
        sceneNum = num;
        SceneManager.LoadScene(num);
        if (num > 1)
        {
            stageNum = num - 1;
        }
    }

    public void SetStop(int num)
    {
        if (num == 0)
        {
            Time.timeScale = 0;
        }
        else if (num == 1)
        {
            Time.timeScale = 1;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
