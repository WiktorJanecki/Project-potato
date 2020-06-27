using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    public GameObject player;
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
            Destroy(transform.gameObject);
        }
    }
}
