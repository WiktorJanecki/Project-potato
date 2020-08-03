using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWorker : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = Camera.main.transform.gameObject;
    }

    void Update()
    {
        
    }
    public void Swap()
    {
        Statistics stats = player.GetComponent<Statistics>();
        stats.actualLand -=1;
        int index = transform.parent.transform.GetSiblingIndex();
        Children actual = stats.workersObjects[index];
        actual.lastOpen = DateTime.Now.Ticks / 10000000;
        if (stats.landWorkers[stats.actualLand].name == "")
        {
            player.GetComponent<Statistics>().landWorkers[stats.actualLand] = actual;
            player.GetComponent<Statistics>().workersObjects.Remove(actual);
            player.GetComponent<Statistics>().hideWorkerList();
        }
        else{
            player.GetComponent<Statistics>().workersObjects.Add(stats.landWorkers[stats.actualLand]);
            player.GetComponent<Statistics>().workersObjects.Remove(actual);
            player.GetComponent<Statistics>().landWorkers[stats.actualLand] = actual;
            player.GetComponent<Statistics>().hideWorkerList();
        }
        player.GetComponent<Warper>().warpNormal();
    }
}
