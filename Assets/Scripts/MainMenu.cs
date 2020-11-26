﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public Button startBtn;

    public void Start(){
        startBtn.onClick.AddListener(() => {
            SceneManager.LoadScene("Game");
        });
    }
}
