using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideArrow : MonoBehaviour
{
    public GameObject player;
    public bool left = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Statistics>().lands > 0)
        {
            transform.GetComponent<Image>().enabled = true;
            if (left)
            {
                if (player.GetComponent<Statistics>().actualLand == 0)
                {
                    transform.GetComponent<Image>().enabled = false;
                }
            }
            else
            {
                if (player.GetComponent<Statistics>().actualLand == player.GetComponent<Statistics>().lands)
                {
                    transform.GetComponent<Image>().enabled = false;
                }
            }
        }
        else
        {
            transform.GetComponent<Image>().enabled = false;
        }
    }
    public void Clicking()
    {
        if (left)
        {
            player.GetComponent<Statistics>().actualLand -= 1;
        }
        else
        {
            player.GetComponent<Statistics>().actualLand += 1;
        }
        if (player.GetComponent<Statistics>().actualLand < 0)
        {
            player.GetComponent<Statistics>().actualLand = 0;
        }
        if (player.GetComponent<Statistics>().actualLand > player.GetComponent<Statistics>().lands)
        {
            player.GetComponent<Statistics>().actualLand = player.GetComponent<Statistics>().lands;
        }
    }
}
