using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class YouWinUI : MonoBehaviour
{
    public UIController ui;
    public VisualElement root;
    public Button restartButton;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        restartButton = root.Q<Button>("restart_button");
        restartButton.clicked += ui.RestartButtonPressed;
    }
}
