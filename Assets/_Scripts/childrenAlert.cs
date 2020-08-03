using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class childrenAlert : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = Camera.main.transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Statistics>().children > 0 && player.GetComponent<Statistics>().landWorkers[player.GetComponent<Statistics>().actualLand - 1].name == "")
        {
            transform.GetComponent<TextMeshProUGUI>().text = "Nobody is working here";
        }
        if (player.GetComponent<Statistics>().children > 0 && player.GetComponent<Statistics>().workersObjects.Count <= 0)
        {
            transform.GetComponent<TextMeshProUGUI>().text = "Children must grow up";
        }
        if (player.GetComponent<Statistics>().children > 0 && player.GetComponent<Statistics>().landWorkers[player.GetComponent<Statistics>().actualLand-1].name != "")
        {
            transform.GetComponent<TextMeshProUGUI>().text = "";
            transform.GetComponent<Animator>().enabled = false;
            transform.GetComponent<RectTransform>().localScale = new Vector3(0, 0,0);
        }
        else
        {
            transform.GetComponent<Animator>().enabled = true;
            transform.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
}
