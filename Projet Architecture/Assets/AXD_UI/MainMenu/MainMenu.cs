using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] UIDocument uiDoc;
    private Button playButton;
    private Button quitButton;
    [SerializeField] private string playSceneName;

    private void Awake()
    {
        playButton = uiDoc.rootVisualElement.Q<Button>("playButton");
        quitButton = uiDoc.rootVisualElement.Q<Button>("quitButton");
        playButton.clicked += Play;
        quitButton.clicked += Quit;
    }

    private void Play()
    {
        SceneManager.LoadScene(playSceneName);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
