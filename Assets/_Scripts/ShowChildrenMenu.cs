using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShowChildrenMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject Name;
    public GameObject Speed;
    public GameObject Capacity;
    public GameObject Timeleft;
    public GameObject grownBtn;
    bool doing = false;
    void Start()
    {
        
    }

    IEnumerator count()
    {
        doing = true;

        yield return new WaitForEndOfFrame();
        StartCoroutine(count());
    }

    void Update()
    {
        if(player.GetComponent<Statistics>().actualBabyID >= 0)
        {
            transform.GetChild(0).transform.gameObject.SetActive(true);
            Children actual = player.GetComponent<Statistics>().childrenObjects.Find(i => i.id == player.GetComponent<Statistics>().actualBabyID);
            try
            {
                Name.GetComponent<TextMeshProUGUI>().text = "Name: " + actual.name;
            }
            catch (System.Exception)
            {

            }
            Speed.GetComponent<TextMeshProUGUI>().text = "Speed: " + Math.Floor(actual.speed * 100).ToString();
            Capacity.GetComponent<TextMeshProUGUI>().text = "Capacity: " + actual.capacity.ToString();
            actual.grow = (actual.obstain - (DateTime.Now.Ticks / 10000000)) / (actual.obstain - actual.fullGrow);
            long timeleft = actual.fullGrow - (DateTime.Now.Ticks / 10000000);
            if (actual.grow < 1f)
            {
                if (timeleft < 60)
                {
                    Timeleft.GetComponent<TextMeshProUGUI>().text = "Time left to grow : " + timeleft.ToString();
                }
                if (timeleft < 3600)
                {
                    int minutes = (int)Math.Floor((float)((timeleft * 1.0f) / 60.0f));
                    int seconds = (int)(timeleft - (minutes * 60));

                    string minutess = minutes.ToString();
                    if (minutes < 10)
                    {
                        minutess = "0" + minutes;
                    }
                    string secondss = seconds.ToString();
                    if (seconds < 10)
                    {
                        secondss = "0" + seconds;
                    }

                    Timeleft.GetComponent<TextMeshProUGUI>().text = "Time left to grow : " + minutess + ":" + secondss;
                }
                if (timeleft >= 3600)
                {
                    int hours = (int)(Math.Floor((float)((timeleft * 1.0f) / 3600.0f)));
                    int minutes = (int)(Math.Floor((float)(((timeleft * 1.0f) - (hours * 3600.0f)) / 60)));
                    int seconds = (int)(timeleft - ((minutes * 60) + (hours * 3600)));

                    string minutess = minutes.ToString();
                    if (minutes < 10)
                    {
                        minutess = "0" + minutes;
                    }
                    string secondss = seconds.ToString();
                    if (seconds < 10)
                    {
                        secondss = "0" + seconds;
                    }
                    string hourss = hours.ToString();
                    if (hours < 10)
                    {
                        hourss = "0" + hours;
                    }

                    Timeleft.GetComponent<TextMeshProUGUI>().text = "Time left to grow: " + hourss + ":" + minutess + ":" + secondss;

                }
            }
            if (actual.grow >= 1f)
            {
                actual.grow = 1;
                Timeleft.GetComponent<TextMeshProUGUI>().text = "fully grow";
                Timeleft.SetActive(false);
                grownBtn.SetActive(true);

            }
        }
        else
        {
            transform.GetChild(0).transform.gameObject.SetActive(false);
        }

    }
    public void Back()
    {
        player.GetComponent<Statistics>().actualBabyID = -1;
        doing = false;
        StopCoroutine(count());
    }
    public void GetWorker()
    {
        Children actual = player.GetComponent<Statistics>().childrenObjects.Find(i => i.id == player.GetComponent<Statistics>().actualBabyID);
        player.GetComponent<Statistics>().childrenObjects.Remove(actual);
        player.GetComponent<Statistics>().workersObjects.Add(actual);
        player.GetComponent<Statistics>().actualBabyID = -1;
        player.GetComponent<Warper>().warpNormal();
    }
}
