﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";

    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Option()
    {
        sceneFader.FadeTo("Hints");
    }

    public void Quit()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }
}