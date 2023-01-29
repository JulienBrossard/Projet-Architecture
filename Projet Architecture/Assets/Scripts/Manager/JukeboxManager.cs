using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor;
using System.Linq;
using UnityEngine.SceneManagement;

public class JukeboxManager : MonoBehaviour
{
    [SerializeField] private UIDocument document;
    [SerializeField] private AudioSource mainSource;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject music;

    private const string m_ButtonPrefix = "Button_Music";

    [Space, SerializeField] private AudioClip[] clips = new AudioClip[3];
    private List<Button> musicButtons = new List<Button>();
    VisualElement subRoot;
    private bool show = true;

    private void Awake()
    {
        subRoot = document.rootVisualElement.Q<VisualElement>("JukeBox_Options");
        musicButtons = subRoot.Children().ToList().ConvertAll(x => x.Q<Button>());
        SetupButtonHandler();
        DontDestroyOnLoad(music);

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            this.transform.root.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        Debug.Log("start");
    }

    private void OnEnable()
    {
        Debug.Log("enable");
    }

    public void Show()
    {
        document.enabled = show;

        mainMenu.SetActive(!show);

        show = !show;
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

        Debug.Log("button number: " + buttonNumber);
        mainSource.clip = clips[buttonNumber];
        mainSource.Play();
    }
}
