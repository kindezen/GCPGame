using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    private static ResultManager instance;
    public static ResultManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<ResultManager>();

            return instance;
        }
    }
    public GameResult result;

    public GameObject resultStartObject;
    public GameObject resultDescriptionObject;
    public GameObject resultEndObject;

    // -1 => ResultStart, failedTrashes.Count => ResultEnd
    private int currentPage = -1;
    private int maxPage{
        get{
            return result.failedTrashes.Count;
        }
    }
    private GameObject currentPageObject;

    public void Start(){
        currentPageObject = Instantiate(resultStartObject);
    }

    public void NextPage(){
        if(currentPage >= maxPage) return;
        currentPage++;

        UpdatePage();
    }

    public void PrevPage(){
        if(currentPage <= -1) return;
        currentPage--;

        UpdatePage();
    }

    public void UpdatePage(){
        Destroy(currentPageObject);
        
        if(currentPage == -1){
            currentPageObject = Instantiate(resultStartObject);
        }
        else if(currentPage == maxPage){
            currentPageObject = Instantiate(resultEndObject);
        }
        else{
            currentPageObject = Instantiate(resultDescriptionObject);
            currentPageObject.GetComponent<TrashDescription>().Set(result.failedTrashes[currentPage]);
        }
    }
}
