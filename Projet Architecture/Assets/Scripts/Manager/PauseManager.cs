using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] UIDocument uiDocument;
    private VisualElement root;
    Button continueBtn;
    private Button restartBtn;
    private Button mainMenuBtn;
    private VisualElement menu;

    private bool isOpen;

    public static PauseManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
        
        root = uiDocument.rootVisualElement;
        continueBtn = root.Q<Button>("continue");
        restartBtn = root.Q<Button>("restart");
        mainMenuBtn = root.Q<Button>("mainMenu");
        menu = root.Q<VisualElement>("menu");
    }

    private void Start()
    {
        continueBtn.clicked += () => Continue();
        restartBtn.clicked += () => Restart();
        mainMenuBtn.clicked+= () => MainMenu();
    }

    private void Update()
    {
        if (InputManager.instance.menuInputs.Menu.Pause.WasPressedThisFrame())
        {
            if (!isOpen)
            {
                Pause();
            }
            else
            {
                Continue();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        InputManager.instance.playerInputs.Disable();
        menu.visible = true;
        isOpen = true;
    }

    public void Continue()
    {
        Time.timeScale = 1;
        InputManager.instance.playerInputs.Enable();
        menu.visible = false;
        isOpen = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void End()
    {
        Pause();
        continueBtn.visible = false;
    }
}
