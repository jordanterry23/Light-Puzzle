using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]



public class LightController : MonoBehaviour
{
    public List<LightRow> gameLights;
    public GameManager gameManager;

    public bool disabled = false;

    void Switch(GameLight currentLight)
    {
        if (!disabled)
        {
            List<GameLight> lights = GetNearbyLights(currentLight);

            foreach (GameLight light in lights)
            {
                light.on = !light.on;
            }

            currentLight.PlaySound();

            gameManager.CheckForWin();
        }
    }

    List<GameLight> GetNearbyLights(GameLight light)
    {

        int currentRow = light.GetComponentInParent<LightRow>().transform.GetSiblingIndex();
        int currentCol = light.transform.GetSiblingIndex();

        List<GameLight> list = new List<GameLight>();
        GameLight top;
        GameLight bottom;
        GameLight left;
        GameLight right;

        list.Add(light);

        if (currentRow > 0)
        {
            top = gameLights[currentRow - 1].lights[currentCol];
            list.Add(top);
        }

        if (currentRow < gameLights.Count - 1)
        {
            bottom = gameLights[currentRow + 1].lights[currentCol];
            list.Add(bottom);
        }

        if (currentCol > 0)
        {
            left = gameLights[currentRow].lights[currentCol - 1];
            list.Add(left);
        }

        if (currentCol < gameLights[currentRow].lights.Count - 1)
        {
            right = gameLights[currentRow].lights[currentCol + 1];
            list.Add(right);
        }

        return list;

    }

    public void StartRandom()
    {
        foreach (LightRow row in gameLights)
        {
            foreach (GameLight light in row.lights)
            {
                light.on = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
            }
        }
    }
}
