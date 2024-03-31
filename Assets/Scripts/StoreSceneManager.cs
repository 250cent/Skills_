using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSceneManager : MonoBehaviour
{
    public GameObject StartPopup;
    
    public string[] tireInfo =
    {
        "평범한 타이어, $0",
        "사막용 타이어, $10000",
        "산악용 타이어, $100000",
        "좋은 타이어, $1000000"
    };

    public int num = 0;
    public Text textTire;
    public Text gold;
    public GameObject Message;
    public GameObject[] tireMesh;
    public GameObject[] engineBuy;
    public GameData gameData;
    
    
    void Start()
    {
        textTire.text = tireInfo[num];
        gameData = GameObject.FindGameObjectWithTag("Data").GetComponent<GameData>();
        gold.text = "$" + gameData.gold.ToString();
        Settire(gameData.tireNum);
        for (int i = 0; i < gameData.engineNum; i++)
        {
            engineBuy[i].SetActive(false);
        }

    }

    void Settire(int num)
    {
        for (int i = 0; i < tireMesh.Length; i++)
        {
            if (num == i)
            {
                tireMesh[i].SetActive(true);
            }
            else
            {
                tireMesh[i].SetActive(false);
            }
        }
    }

    public void BtnLeft()
    {
        num--;
        if (num < 0)
        {
            num = tireInfo.Length - 1;
        }

        textTire.text = tireInfo[num];
        Settire(num);
    }
    public void BtnRight()
    {
        num++;
        if (num >= tireInfo.Length)
        {
            num = 0;
        }

        textTire.text = tireInfo[num];
        Settire(num);
    }

    public void BtnBuy()
    {
        if (gameData.gold < gameData.tireCost[num] && !gameData.cheatStore)
        {
            Message.transform.GetComponent<Text>().text = "골드가 부족합니다";
            Message.SetActive(true);
            Invoke("Hide",1f);
        }
        else
        {
            Message.transform.GetComponent<Text>().text = "타이어가 변경되었습니다";
            Message.SetActive(true);
            gameData.tireNum = num;
            if (!gameData.cheatStore)
            {
                gameData.gold -= gameData.tireCost[num];
            }
            Settire(num);
            Invoke("Hide",1f);
        }
    }

    void Hide()
    {
        Message.SetActive(false);
    }

    public void Btn6()
    {
        if (gameData.gold < gameData.engineCost[1] && !gameData.cheatStore)
        {
            Message.transform.GetComponent<Text>().text = "골드가 부족합니다";
            Message.SetActive(true);
            Invoke("Hide",1f);
        }
        else
        {
            Message.transform.GetComponent<Text>().text = "엔진이 변경되었습니다";
            Message.SetActive(true);
            gameData.engineNum = 1;
            if (!gameData.cheatStore)
            {
                gameData.gold -= gameData.engineCost[1];
            }
            Invoke("Hide",1f);
        }
    }
    public void Btn8()
    {
        if (gameData.gold < gameData.engineCost[2] && !gameData.cheatStore)
        {
            Message.transform.GetComponent<Text>().text = "골드가 부족합니다";
            Message.SetActive(true);
            Invoke("Hide",1f);
        }
        else
        {
            Message.transform.GetComponent<Text>().text = "엔진이 변경되었습니다";
            Message.SetActive(true);
            gameData.engineNum = 2;
            if (!gameData.cheatStore)
            {
                gameData.gold -= gameData.engineCost[2];
            }
            Invoke("Hide",1f);
        }
    }

    public void BtnStart()
    {
        gameData.ChangeScene(gameData.stageNum + 1);
    }

    

    void Update()
    {
        
    }
}
