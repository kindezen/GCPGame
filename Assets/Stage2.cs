using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2 : MonoBehaviour, IStage
{

    public string answer; //left or right
    public Button leftBtn;
    public Button rightBtn;

    public void InitStage()
    {
        if(answer.Equals("left"))
        {
            leftBtn.onClick.AddListener(() =>
            {
                StageClear();
            });

            rightBtn.onClick.AddListener(() =>
            {
                StageFail();
            });
        }
        else
        {
            leftBtn.onClick.AddListener(() =>
            {
                StageFail();
            });

            rightBtn.onClick.AddListener(() =>
            {
                StageClear();
            });
        }
    }

    void StageFail()
    {
        GameManager.Instance.GoToNextStage(false);
    }

    void StageClear()
    {
        GameManager.Instance.GoToNextStage(true);
    }

}
