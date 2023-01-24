using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] UIDocument uiDocument;
    public static UIManager instance;
    public Label speedBonus, damageBonus, fireRateBonus, playerHealth;
    private VisualElement root;
    public VisualElement reload;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        Init();
    }

    void Init()
    {
        root = uiDocument.rootVisualElement;
        speedBonus = root.Q<Label>("speed");
        fireRateBonus = root.Q<Label>("fireRate");
        damageBonus = root.Q<Label>("damage");
        playerHealth = root.Q<Label>("health");
        reload = root.Q<VisualElement>("reload");
    }
    
    
}
