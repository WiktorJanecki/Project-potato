using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPrice : MonoBehaviour
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
        score = player.GetComponent<Statistics>().potatoPrice;
        if(score > 0.15)
        {
            textmeshPro.color = new Color(0f, 255, 0, 255);
        }
        else
        {
            textmeshPro.color = new Color(255, 0, 0, 255);
        }
        textmeshPro.text = score.ToString() + " $";
    }
}
