using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int currentLevel = 1;
    void Start()
    {
        LoadCurrentLevel();
        LoadCurrentScene();
    }

    static void LoadCurrentScene() {
        SceneManager.LoadScene(currentLevel);
    }

    public static void UpdateCurrentLevel(int buildIndex) {
        currentLevel = buildIndex;
        PlayerPrefs.SetInt("currentLevel", currentLevel);
    }

    void LoadCurrentLevel() {
        currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
    }

    public static int NextLevel() {
        if(currentLevel+1 < SceneManager.sceneCountInBuildSettings)
            currentLevel++;
            else
            currentLevel = 1;

        return currentLevel;
    }

    public static void GoToNextLevel() {
        UpdateCurrentLevel(NextLevel());
        LoadCurrentScene();
    }

    public static void RestartLevel() {
        SceneManager.LoadScene(currentLevel);
    }
}