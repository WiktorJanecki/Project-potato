using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpgradePosition : MonoBehaviour
{
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            float width = transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x;
            transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector2(i * width, transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.y);
        }       
    }
    void Update()
    {
        
    }
}
