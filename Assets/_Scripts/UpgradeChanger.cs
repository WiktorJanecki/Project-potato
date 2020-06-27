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
        image.sprite = upgrade.image;
        text.text = upgrade.name;
        price.text = upgrade.price.ToString() + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
