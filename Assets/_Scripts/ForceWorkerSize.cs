using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceWorkerSize : MonoBehaviour
{
    public GameObject child;
    private int screenWidth;

    void Start()
    {
        screenWidth = Screen.width;
        child.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(screenWidth / 2, child.transform.GetComponent<RectTransform>().sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
