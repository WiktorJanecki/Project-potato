using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowWorkerMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject Name;
    public GameObject Speed;
    public GameObject Capacity;

    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (player.GetComponent<Statistics>().actaulWorker >= 0)
            {
                transform.GetChild(0).transform.gameObject.SetActive(true);
                menu.SetActive(false);
                Children actual = player.GetComponent<Statistics>().workersObjects.Find(i => i.id == player.GetComponent<Statistics>().actaulWorker);
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
        player.GetComponent<Statistics>().actaulWorker = -1;
        menu.SetActive(true);
    }
}
