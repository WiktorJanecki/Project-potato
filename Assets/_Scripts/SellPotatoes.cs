using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPotatoes : MonoBehaviour
{
    public GameObject player;
    private Statistics stats;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Sell()
    {
        stats = player.GetComponent<Statistics>();
        stats.coins += stats.potatoes * stats.potatoPrice;
        stats.potatoes = 0;
    }
}
