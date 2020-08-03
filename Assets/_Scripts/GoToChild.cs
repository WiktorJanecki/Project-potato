using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToChild : MonoBehaviour
{
    private GameObject player;
    public GameObject button;
    void Start()
    {
        player = Camera.main.transform.gameObject;
        transform.parent.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3, transform.parent.transform.GetComponent<RectTransform>().sizeDelta.y);

    }

    void Update()
    {
    }
    public void Click()
    {
        int index = transform.parent.transform.GetSiblingIndex();
        player.GetComponent<Statistics>().actualBabyID = player.GetComponent<Statistics>().childrenObjects[index].id;
    }
}
