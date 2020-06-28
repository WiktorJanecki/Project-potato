using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public int potatoes = 0;
    public float coins = 0;

    public float potatoPrice = 0.1f;
    public int bonus = 0;
    public string upgrades = "0000";

    public int lands = 0;
    public int actualLand = 0;
    public string[] landUpgrades;
    public int[,] landColors;


    void Start()
    {
    }
    void Update()
    {
        
    }
    public void increasePotatoes()
    {
        potatoes += 1+bonus;
    }
}
