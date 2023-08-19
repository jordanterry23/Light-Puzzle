using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public int rows = 3;
    public int cols = 3;
    public LightGridBuilder builder;
    private LightController lightController;
    public bool win = false;
    public UIController uiController;
    public Color onColor;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void CheckForWin()
    {
        win = true;
        foreach(LightRow row in lightController.gameLights)
        {
            foreach (GameLight light in row.lights)
            {
                if (!light.on)
                {
                    win = false;
                }
            }
        }

        if (win)
        {
            lightController.disabled = true;
            uiController.Win();
            source.Play();
        }
    }

    public void StartGame(int difficulty, int colorSelect)
    {
        Color onColor = Color.green;

        if(lightController != null)
        {
            Destroy(lightController.gameObject);
        }

        if(difficulty == 0)
        { 
            rows = 3;
            cols = 3;
        }
        else if(difficulty == 1)
        {
            rows = 5;
            cols = 4;
        }
        else if (difficulty == 2)
        {
            rows = 5;
            cols = 6;
        }

        if(colorSelect == 0)
        {
            onColor = Color.red;
        }
        else if (colorSelect == 1)
        {
            onColor = Color.green;
        }
        else if (colorSelect == 2)
        {
            onColor = Color.blue;
        }

        lightController = builder.BuildGrid(rows, cols, onColor, this);
        lightController.StartRandom();
        win = false;
        source.Play();
    }

    public void Reset()
    {
        Destroy(lightController.gameObject);
    }

}
