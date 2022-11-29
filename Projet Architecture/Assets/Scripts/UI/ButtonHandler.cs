using UnityEngine;
using UnityEngine.UIElements;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField]

    private UIDocument m_UIDocument;

    private Label m_Label;

    private int m_ButtonClickCount = 0;

    private Toggle m_Toggle;

    private Button buyButton;


    public void OnEnable()
    {
        var rootElement = m_UIDocument.rootVisualElement;

        buyButton = rootElement.Query<Button>("Buy");
        buyButton.clickable.clicked += OnButtonClicked;

        /*m_Toggle = rootElement.Query<Toggle>("ColorToggle");

        m_Toggle.RegisterValueChangedCallback(OnToggleValueChanged);

        m_Label = rootElement.Query<Label>("IncrementLabel");

        m_Label.text = m_ButtonClickCount.ToString();*/
    }


    private void OnDisable()
    {
        buyButton.clickable.clicked -= OnButtonClicked;

        //m_Toggle.UnregisterValueChangedCallback(OnToggleValueChanged);
    }


    private void OnButtonClicked()
    {
        Debug.Log("buying"); 
    }



    private void OnToggleValueChanged(ChangeEvent<bool> evt)
    {

        //
    }
}
