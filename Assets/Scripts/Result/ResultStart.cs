using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultStart : MonoBehaviour
{
    public Text scoreText;
    public Text descText;
    public Button nextBtn;
    public GameResult result;

    void Start(){
        scoreText.text = result.score + "/" + result.maxScore;
        
        if(result.failedTrashes.Count == 0){
            descText.text = "훌륭해요!";
        }

        nextBtn.onClick.AddListener(() =>
        {
            ResultManager.Instance.NextPage();
        });
    }
}
