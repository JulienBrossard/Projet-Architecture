using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental; 

public class MainMenuVar : MonoBehaviour
{
    [SerializeField] UIDocument UIDocument;
    [SerializeField] UIDocument defaultImg;
    [SerializeField] UIDocument hoverImg;
    [SerializeField] UIDocument selectedImg;

    private Button buttonPlay;

    private void Awake()
    {
        buttonPlay = UIDocument.rootVisualElement.Q<Button>("Button_Play");
        buttonPlay.clicked += ChangeColorOnClick;
    }

    private void Start()
    {

    }

    private void OnDisable()
    {
        buttonPlay.clicked -= ChangeColorOnClick;
    } 

    private void ChangeColorOnClick()
    {
        Debug.Log("clicked");
    }
}
