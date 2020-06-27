using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPotatoMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseMenu()
    {
        menu.SetActive(false);
    }
    public void ShowMenu()
    {
        player.GetComponent<Statistics>().potatoPrice = Mathf.Round(Random.Range(0.1f, 0.29f)*100)/100;
        menu.SetActive(true);
    }
}
