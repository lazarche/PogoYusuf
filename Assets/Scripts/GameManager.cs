using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    bool started = false;
    bool win = false;

    void Awake()
    {
        instance = this;
    }

    void Start() {
        Application.targetFrameRate = 60;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false;
    }

    public bool isStarted() {
        return started;
    }
    public void StartLevel() {
        started = true;
        UiManager.instance.StartLevel();
    }

    public void WinLevel() {
        win = true;
        UiManager.instance.WinLevel(); 
    }

    public bool isWin() {
        return win;
    }

    public void NextLevel() {
        LevelManager.GoToNextLevel();
    }

    public void RestartLevel() {
        LevelManager.RestartLevel();
    }

}