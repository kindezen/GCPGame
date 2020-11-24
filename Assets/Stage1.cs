using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IStage
{
    void InitStage();
}

public class Stage1 : MonoBehaviour, IStage
{

    public Button baechulBtn;
    public Button changeBtn;
    public int answerCount;
    
    private int currentCount;

    public void InitStage()
    {
        currentCount = 0;

        baechulBtn.onClick.AddListener(() =>
        {
            if (currentCount == answerCount)
                StageClear();
            else
                StageFail();
        });

        changeBtn.onClick.AddListener(() =>
        {
            ChangeState();
        });
    }

    public void ChangeState()
    {
        currentCount++;

        if(currentCount > answerCount)
        {
            StageFail();
        }

        //TODO: 이미지 변경
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
