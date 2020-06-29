using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeChanger : MonoBehaviour
{   
    public Upgrade upgrade;
    public Image image;
    public TextMeshProUGUI price;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            image.sprite = upgrade.image;
            text.text = upgrade.name;
            price.text = upgrade.price.ToString() + "$";
        }
        catch (System.Exception)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
