using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public GameData gameData;

    public Text textRank;
    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.FindGameObjectWithTag("Data").GetComponent<GameData>();
        SetRank();
    }

    void SetRank()
    {
        if (gameData.rank == "")
        {
            textRank.text = "랭킹정보가 없습니다";
        }
        else
        {
            string[] temp = gameData.rank.Split("|");
            List<string> rankData = new List<string>();
            for (int i = 0; i < temp.Length; i++)
            {
                rankData.Add(temp[i]);
            }

            rankData.Sort();
            textRank.text = "";
        }
    }

    public void BtnStart()
    {
        gameData.ChangeScene(gameData.sceneNum+1);
    }

    public void BtnExit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
