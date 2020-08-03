using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWorkerImage : MonoBehaviour
{
    public GameObject player;
    public Sprite image;
    public Sprite imagewith;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Statistics>().landWorkers[player.GetComponent<Statistics>().actualLand - 1].name != "")
        {
            transform.GetComponent<Image>().sprite = imagewith;
        }
        else
        {
            transform.GetComponent<Image>().sprite = image;
        }
    }
}
