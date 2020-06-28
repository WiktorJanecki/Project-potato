using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public GameObject player;
    public AudioSource source;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BuyLandUpgrade()
    {
        if (player.GetComponent<Statistics>().coins >= transform.parent.GetComponent<UpgradeChanger>().upgrade.price)
        {
            player.GetComponent<Statistics>().coins -= transform.parent.GetComponent<UpgradeChanger>().upgrade.price;
            source.Play();
            string s = "";
            try
            {
                if(player.GetComponent<Statistics>().landUpgrades.Length == 0)
                {
                    throw new Exception();
                }
                string ss = player.GetComponent<Statistics>().landUpgrades[player.GetComponent<Statistics>().actualLand - 1];
                for (int i = 0; i < player.GetComponent<Statistics>().landUpgrades[0].Length; i++)
                {

                    if (i == transform.parent.GetComponent<UpgradeChanger>().upgrade.index || ss[i] == '1')
                    {
                        s += "1";
                    }
                    else
                    {
                        s += "0";
                    }
                }
                player.GetComponent<Statistics>().landUpgrades[player.GetComponent<Statistics>().actualLand - 1] = s;
                transform.gameObject.SetActive(false);
            }
            catch (Exception)
            {
                player.GetComponent<Statistics>().landUpgrades = new string[player.GetComponent<Statistics>().lands];
                for (int j = 0; j < player.GetComponent<Statistics>().landUpgrades.Length; j++)
                {
                    player.GetComponent<Statistics>().landUpgrades[j] = "0000";
                }
                string ss = player.GetComponent<Statistics>().landUpgrades[player.GetComponent<Statistics>().actualLand - 1];
                for (int i = 0; i < player.GetComponent<Statistics>().landUpgrades[0].Length; i++)
                {

                    if (i == transform.parent.GetComponent<UpgradeChanger>().upgrade.index || ss[i] == '1')
                    {
                        s += "1";
                    }
                    else
                    {
                        s += "0";
                    }
                }
                transform.gameObject.SetActive(false);
                player.GetComponent<Statistics>().landUpgrades[player.GetComponent<Statistics>().actualLand - 1] = s;
            }
        }
    }    
    public void GetLandUpgrade()
    {
        string s = "";
        string ss = player.GetComponent<Statistics>().landUpgrades[player.GetComponent<Statistics>().actualLand-1];
        for (int i = 0; i < player.GetComponent<Statistics>().landUpgrades[0].Length; i++)
        {

            if (i == transform.parent.GetComponent<UpgradeChanger>().upgrade.index || ss[i] == '1')
            {
                s += "1";
            }
            else
            {
                s += "0";
            }
        }
        transform.gameObject.SetActive(false);
        player.GetComponent<Statistics>().landUpgrades[player.GetComponent<Statistics>().actualLand - 1] = s;
    }

    public void BuyUpgrade()
    {
        if (player.GetComponent<Statistics>().coins >= transform.parent.GetComponent<UpgradeChanger>().upgrade.price) {
            player.GetComponent<Statistics>().coins -= transform.parent.GetComponent<UpgradeChanger>().upgrade.price;
            player.GetComponent<Statistics>().bonus += transform.parent.GetComponent<UpgradeChanger>().upgrade.value;
            source.Play();
            string s = "";
            string ss = player.GetComponent<Statistics>().upgrades;
            for (int i = 0;i < player.GetComponent<Statistics>().upgrades.Length; i++)
            {
                
                if (i == transform.parent.GetComponent<UpgradeChanger>().upgrade.index || ss[i] == '1')
                {
                    s += "1";
                }
                else
                {
                    s += "0";
                }
            }
            player.GetComponent<Statistics>().upgrades = s;
            transform.GetComponent<Image>().enabled = false;
            Destroy(transform.GetChild(0).transform.gameObject);
            Destroy(transform.gameObject,3f);
        }
    }
    public void GetUpgrade()
    {
        string s = "";
        string ss = player.GetComponent<Statistics>().upgrades;
        for (int i = 0; i < player.GetComponent<Statistics>().upgrades.Length; i++)
        {

            if (i == transform.parent.GetComponent<UpgradeChanger>().upgrade.index || ss[i] == '1')
            {
                s += "1";
            }
            else
            {
                s += "0";
            }
        }
        player.GetComponent<Statistics>().upgrades = s;
        player.GetComponent<Statistics>().bonus += transform.parent.GetComponent<UpgradeChanger>().upgrade.value;
        Destroy(transform.gameObject);
    }
}
