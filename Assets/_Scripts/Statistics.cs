using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public int potatoes = 0;
    public float coins = 0;
    public float potatoPrice = 0.1f;
    public int bonus = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void increasePotatoes()
    {
        potatoes += 1+bonus;
    }
}
