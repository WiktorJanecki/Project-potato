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
        }
    }
}
