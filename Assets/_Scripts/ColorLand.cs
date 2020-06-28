using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorLand : MonoBehaviour
{
    public GameObject player;
    public GameObject landObj;
    private int[,] colors;

    void Start()
    {
        colors = player.GetComponent<Statistics>().landColors;
        Color();
    }

    private void Update()
    {
        
    }
    public void Color()
    {
        int actual = player.GetComponent<Statistics>().actualLand -1;
        if (actual == -1)
        {

        }
        else
        {
            try
            {
                if (colors[actual, 0] == 0)
                {
                    player.GetComponent<Statistics>().landColors[actual, 0] = UnityEngine.Random.Range(55, 254);
                    player.GetComponent<Statistics>().landColors[actual, 1] = UnityEngine.Random.Range(55, 254);
                    player.GetComponent<Statistics>().landColors[actual, 2] = UnityEngine.Random.Range(55, 254);
                    colors = player.GetComponent<Statistics>().landColors;
                }
                landObj.GetComponent<Image>().color = new Color32((byte)colors[actual, 0], (byte)colors[actual, 1], (byte)colors[actual, 2], 255);
            }
            catch (Exception)
            {
                player.GetComponent<Statistics>().landColors = new int[player.GetComponent<Statistics>().lands, 3];
                player.GetComponent<Statistics>().landColors[actual, 0] = UnityEngine.Random.Range(55, 254);
                player.GetComponent<Statistics>().landColors[actual, 1] = UnityEngine.Random.Range(55, 254);
                player.GetComponent<Statistics>().landColors[actual, 2] = UnityEngine.Random.Range(55, 254);
                colors = player.GetComponent<Statistics>().landColors;
                landObj.GetComponent<Image>().color = new Color32((byte)colors[actual, 0], (byte)colors[actual, 1], (byte)colors[actual, 2], 255);
            }
        }
    }
}
