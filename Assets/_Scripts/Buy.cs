using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public GameObject player;
    public AudioSource source;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyUpgrade()
    {
        if (player.GetComponent<Statistics>().coins >= transform.parent.GetComponent<UpgradeChanger>().upgrade.price) {
            player.GetComponent<Statistics>().coins -= transform.parent.GetComponent<UpgradeChanger>().upgrade.price;
            player.GetComponent<Statistics>().bonus += transform.parent.GetComponent<UpgradeChanger>().upgrade.value;
            source.Play();
            transform.GetComponent<Image>().enabled = false;
            Destroy(transform.GetChild(0).transform.gameObject);
            Destroy(transform.gameObject,3f);
        }
    }
}
