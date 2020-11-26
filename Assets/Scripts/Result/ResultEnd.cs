using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultEnd : MonoBehaviour
{
    public Button prevBtn;
    public Button mainBtn;

    void Start(){
        prevBtn.onClick.AddListener(() => {
            ResultManager.Instance.PrevPage();
        });

        mainBtn.onClick.AddListener(() => {
            SceneManager.LoadScene("Main");
        });
    }
}
