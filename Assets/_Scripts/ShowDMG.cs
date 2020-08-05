using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ShowDMG : MonoBehaviour
{
    public Statistics stats;
    public TextMeshProUGUI text;
    void Start()
    {
        stats = Camera.main.GetComponent<Statistics>();
    }

    // Update is called once per frame
    void Update()
    {
            text.text = "+" + (stats.bonus + 1);
    }

}
