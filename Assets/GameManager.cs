using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<GameManager>();

            return instance;
        }
    }

    public GameObject startPage;
    public GameObject[] stages;
    public GameObject endPage;

    private int maxScore
    {
        get
        {
            return stages.Length;
        }
    }
    private int totScore;

    private int nowStage;

    void InitGame()
    {
        totScore = 0;
    }

    public void StartGame()
    {
        InitGame();

        startPage.SetActive(false);
        SetStage(0);
    }

    public void GoToNextStage(bool isSuccess)
    {
        if (isSuccess)
            totScore++;

        SetStage(nowStage + 1);
    }

    void SetStage(int _stage)
    {
        nowStage = _stage;

        foreach(var item in stages)
            item.SetActive(false);

        if (_stage >= maxScore)
        {
            SetEndPage();
            return;
        }

        stages[nowStage].SetActive(true);
        stages[nowStage].GetComponent<IStage>().InitStage();
    }

    void SetEndPage()
    {
        endPage.SetActive(true);

        endPage.transform.Find("Text_Score").GetComponent<Text>().text = totScore.ToString() + "/" + maxScore.ToString();
    }

}
