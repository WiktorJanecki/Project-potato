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
        if(player.GetComponent<Statistics>().children > 0)
        {
            transform.GetComponent<TextMeshProUGUI>().text = "Not implemented yet";
        }
    }
}
