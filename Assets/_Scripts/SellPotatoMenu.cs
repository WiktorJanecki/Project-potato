using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPotatoMenu : MonoBehaviour
{
    public GameObject menu;
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
        menu.SetActive(true);
    }
}
