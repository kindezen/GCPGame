using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject[] stageUIObjects;
    public GameObject[] resultUIObjects;

    public Trash[] trashes;

    public GameResult gameResult;

    private int maxScore
    {
        get
        {
            return trashes.Length;
        }
    }

    private int currentStageIndex;
    private Stage currentStage;
    private Stage lastStage;
    private GameObject resultUI;

    void Start()
    {
        InitGame();

        SetStage(0);
    }

    void InitGame()
    {
        gameResult.Init();
        gameResult.maxScore = maxScore;
    }

    public void GoToNextStage(Stage stage, bool isSuccess)
    {
        if (isSuccess){
            gameResult.score++;

            resultUI = Instantiate(resultUIObjects[0]);
        }
        else{
            gameResult.failedTrashes.Add(trashes[currentStageIndex]);

            resultUI = Instantiate(resultUIObjects[1]);
        }

        StartCoroutine(
            WaitForSeconds(1.5f, () => SetStage(currentStageIndex + 1))
        );
    }

    IEnumerator WaitForSeconds(float time, Action action){
        yield return new WaitForSeconds(time);
        action();
    }

    // TODO: Animated UI Transition
    void SetStage(int _stage)
    {
        currentStageIndex = _stage;

        lastStage = currentStage;

        if(currentStage != null){
            Destroy(currentStage.gameObject);
            Destroy(resultUI);
        }

        if (_stage >= maxScore)
        {
            SceneManager.LoadScene("Result");
            return;
        }

        Trash trash = trashes[currentStageIndex];

        currentStage = Instantiate(GetUIObject(trash)).GetComponent<Stage>();
        currentStage.Init(trash);
    }

    private GameObject GetUIObject(Trash trash){
        if(trash is TrashA) return stageUIObjects[0];
        if(trash is TrashB) return stageUIObjects[1];
        if(trash is TrashC) return stageUIObjects[2];
        return null;
    }
}
