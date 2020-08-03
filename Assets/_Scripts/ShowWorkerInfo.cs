using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowWorkerInfo : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI text;
    void Start()
    {
        player = Camera.main.transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        int index = transform.parent.transform.GetSiblingIndex();
        text.text = player.GetComponent<Statistics>().workersObjects[index].name;
    }
}
