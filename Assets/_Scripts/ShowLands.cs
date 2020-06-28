using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLands : MonoBehaviour
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
        score = player.GetComponent<Statistics>().lands;
        textmeshPro.text = score.ToString() + " lands";
    }
}
