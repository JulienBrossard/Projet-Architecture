using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor;
using System.Linq;
using System;

public class JukeboxManager : MonoBehaviour
{
    [SerializeField] private UIDocument document;
    [SerializeField] private Camera mainCam; // PLACEHOLDER for sound manager

    private const string m_ButtonPrefix = "Button_Music";

    [Space, SerializeField] private AudioClip[] clips = new AudioClip[3];
    private List<Button> musicButtons = new List<Button>();
    private AudioSource mainSource;
    VisualElement subRoot;

    private void Awake()
    {
        subRoot = document.rootVisualElement.Q<VisualElement>("JukeBox_Options");
        musicButtons = subRoot.Children().ToList().ConvertAll(x => x.Q<Button>());
        SetupButtonHandler();
    }

    private void Start()
    {
        mainSource = mainCam.GetComponent<AudioSource>();
    }

    private void Show()
    {
        document.enabled = true;
    }

    private void Hide()
    {
        document.enabled = false;
    }

    private void SetupButtonHandler()
    {
        musicButtons.ForEach(RegisterHandler);
    }

    private void RegisterHandler(Button button)
    {
        button.RegisterCallback<ClickEvent>(SetNewMusic);
    }

    private void SetNewMusic(ClickEvent evt)
    {
        Button button = evt.currentTarget as Button;
        int buttonNumber = int.Parse(button.name.Substring(m_ButtonPrefix.Length));

        mainSource.clip = clips[buttonNumber];
        mainSource.Play();
    }
}
