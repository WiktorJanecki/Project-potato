using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowProgress : MonoBehaviour
{
    public TextMeshProUGUI textmeshPro;
    private int score;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        score = player.GetComponent<Statistics>().childrenProgress;
        if (player.GetComponent<Statistics>().children == 0) {
            textmeshPro.text = score.ToString() + "/5000 potatoes";
        }
        else
        {
            textmeshPro.text = score.ToString() + "/" + player.GetComponent<Statistics>().children * 2 * 5000 + " potatoes";
        }
    }
}
