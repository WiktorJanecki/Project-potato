using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyLand : MonoBehaviour
{
    public GameObject player;
    public AudioSource source;

    void Start()
    {
         
    }

    void Update()
    {
        
    }
    public void Buy()
    {
        if(player.GetComponent<Statistics>().coins >= transform.parent.GetComponent<UpgradeChanger>().upgrade.price)
        {
            source.Play();
            player.GetComponent<Statistics>().coins -= transform.parent.GetComponent<UpgradeChanger>().upgrade.price;
            player.GetComponent<Statistics>().lands += 1;
            string[] array = player.GetComponent<Statistics>().landUpgrades;
            player.GetComponent<Statistics>().landUpgrades = new string[player.GetComponent<Statistics>().lands];
            for(int i=0;i < player.GetComponent<Statistics>().landUpgrades.Length; i++)
            {
                try
                {
                    player.GetComponent<Statistics>().landUpgrades[i] = array[i];
                }
                catch (Exception)
                {
                    player.GetComponent<Statistics>().landUpgrades[i] = "0000";
                }
            }
            int[,] arrayy = player.GetComponent<Statistics>().landColors;
            player.GetComponent<Statistics>().landColors = new int[player.GetComponent<Statistics>().lands, 3];
            for(int i = 0; i < player.GetComponent<Statistics>().lands-1; i++)
            {
                player.GetComponent<Statistics>().landColors[i, 0] = arrayy[i, 0];
                player.GetComponent<Statistics>().landColors[i, 1] = arrayy[i, 1];
                player.GetComponent<Statistics>().landColors[i, 2] = arrayy[i, 2];
            }
            for (int i = player.GetComponent<Statistics>().lands-1; i < player.GetComponent<Statistics>().lands; i++){
                player.GetComponent<Statistics>().landColors[i, 0] = UnityEngine.Random.Range(55, 254);
                player.GetComponent<Statistics>().landColors[i, 1] = UnityEngine.Random.Range(55, 254);
                player.GetComponent<Statistics>().landColors[i, 2] = UnityEngine.Random.Range(55, 254);
            }
        }
    }
}
