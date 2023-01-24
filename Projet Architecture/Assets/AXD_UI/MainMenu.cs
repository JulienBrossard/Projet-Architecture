using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument uiDoc;
    private VisualElement bleu;
    private Button button1;

    private void Awake()
    {
        bleu = uiDoc.rootVisualElement.Q<VisualElement>("Bleu");
        button1 = uiDoc.rootVisualElement.Q<Button>("button1");
        
    }
} 
