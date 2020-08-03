using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrabCoinsBtn : MonoBehaviour
{
    public GameObject btn;
    public Statistics stats;
    public TextMeshProUGUI text;        
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Children actual = stats.landWorkers[stats.actualLand - 1];
        if(actual.potatoes > actual.capacity) { actual.potatoes = actual.capacity; }
        text.text = actual.potatoes.ToString() + "/" + actual.capacity.ToString();
        if (actual.potatoes > 0)
        {
            btn.SetActive(true);
        }
        else
        {
            btn.SetActive(false);
        }
        if (stats.landWorkers[stats.actualLand - 1].name != "") {
            if (actual.lastOpen + 5 < System.DateTime.Now.Ticks / 10000000)
            {
                if (actual.lastOpen == 0)
                {
                    actual.lastOpen = System.DateTime.Now.Ticks / 10000000;
                }
                int bonus = 0;

                string upgrades = stats.landUpgrades[stats.actualLand - 1];

                if (upgrades[0] == '1') { bonus += 1; }
                if (upgrades[1] == '1') { bonus += 2; }
                if (upgrades[2] == '1') { bonus += 3; }
                if (upgrades[3] == '1') { bonus += 5; }


                actual.potatoes += (int)Math.Floor((System.DateTime.Now.Ticks / 10000000 - actual.lastOpen) * ((actual.speed * 0.5f) + bonus));
                actual.lastOpen = System.DateTime.Now.Ticks / 10000000;
            }
        }
    }
}
