using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class LightGridBuilder : MonoBehaviour
{

    public GameObject lightGridPrefab;
    public GameObject lightRowPrefab;
    public GameObject gameLightPrefab;

    public LightController BuildGrid(int rows, int cols, Color color, GameManager gameManager)
    {
        
        // Build Grid
        LightController lightController = Instantiate<GameObject>(lightGridPrefab).GetComponent<LightController>();
        lightController.name = "Light Controller";
        lightController.gameManager = gameManager;        
        
        // Build Rows

        for(int i = 0; i < rows; i++)
        {
            LightRow lightRow = Instantiate<GameObject>(lightRowPrefab).GetComponent<LightRow>();
            lightRow.name = "Light Row " + i;
            lightRow.transform.parent = lightController.transform;
            lightController.gameLights.Add(lightRow);

            for (int j = 0; j < cols; j++)
            {
                GameLight gameLight = Instantiate<GameObject>(gameLightPrefab).GetComponent<GameLight>();
                gameLight.name = "Game Light " + i + "," + j;
                gameLight.transform.parent = lightRow.transform;
                gameLight.onColor = color;

                lightRow.lights.Add(gameLight);
                
                gameLight.transform.position = new Vector2(j*2,-i*2);
            }
        }

        lightController.transform.position = new Vector2(-(cols-1), rows-1);

        return lightController;
    }
}
