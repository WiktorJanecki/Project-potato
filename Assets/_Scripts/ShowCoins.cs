using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowCoins : MonoBehaviour
{
    public TextMeshProUGUI textmeshPro;
    private float score;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        score = player.GetComponent<Statistics>().coins;
        textmeshPro.text = score.ToString() + " coins";
    }
}
