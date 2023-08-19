using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    public UIController ui;
    public VisualElement root;
    public Button startButton;
    public Button quitButton;
    public DropdownField difficultyDrop;
    public RadioButtonGroup colorSelector;
    public Color selectedColor;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("start_button");
        difficultyDrop = root.Q<DropdownField>("difficulty_dropdown");
        colorSelector = root.Q<RadioButtonGroup>("color_selector_group");
        difficultyDrop.index = ui.difficulty;
        startButton.clicked += () => ui.StartButtonPressed(difficultyDrop.index, colorSelector.value);        
    }
}
