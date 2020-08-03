using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToActualLandWorker : MonoBehaviour
{
    public GameObject player;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Click()
    {
        if(player.GetComponent<Statistics>().landWorkers[player.GetComponent<Statistics>().actualLand - 1].name != "")
        {
            player.GetComponent<Statistics>().actualLandWorker = player.GetComponent<Statistics>().actualLand - 1;
        }
    }
}
