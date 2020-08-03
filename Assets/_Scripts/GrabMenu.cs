using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrabMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject Name;
    public GameObject Speed;
    public GameObject Capacity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Statistics>().actualLandWorker >= 0)
        {
            transform.GetChild(0).transform.gameObject.SetActive(true);
            Children actual = player.GetComponent<Statistics>().landWorkers[player.GetComponent<Statistics>().actualLandWorker];
            try
            {
                Name.GetComponent<TextMeshProUGUI>().text = "Name: " + actual.name;
            }
            catch (System.Exception)
            {

            }
            Speed.GetComponent<TextMeshProUGUI>().text = "Speed: " + Math.Floor(actual.speed * 100).ToString();
            Capacity.GetComponent<TextMeshProUGUI>().text = "Capacity: " + actual.capacity.ToString();
        }
        else
        {
            transform.GetChild(0).transform.gameObject.SetActive(false);
        }
    }
    public void Back()
    {
        player.GetComponent<Statistics>().actualLandWorker = -1;
    }
    public void Grab()
    {
        Children actual = player.GetComponent<Statistics>().landWorkers[player.GetComponent<Statistics>().actualLandWorker];
        player.GetComponent<Statistics>().landWorkers[player.GetComponent<Statistics>().actualLandWorker] = new Children();
        player.GetComponent<Statistics>().workersObjects.Add(actual);

        player.GetComponent<Statistics>().actualLandWorker = -1;
        player.GetComponent<Warper>().warpNormal();
    }
    public void GrabCoins()
    {
        Children actual = player.GetComponent<Statistics>().landWorkers[player.GetComponent<Statistics>().actualLand-1];
        player.GetComponent<Statistics>().potatoes += actual.potatoes;
        actual.potatoes = 0;
        actual.lastOpen = DateTime.Now.Ticks / 10000000;
        Back();
    }
}
