using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warper : MonoBehaviour
{
    public GameObject Normal;
    public GameObject Land;
    public GameObject Baby;
    // Start is called before the first frame update
    void Start()
    {
        warpNormal();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.GetComponent<Statistics>().actualLand > 0 && !transform.GetComponent<Statistics>().baby)
        {
            warpLand();
        }
        else if(transform.GetComponent<Statistics>().actualLand == 0 && !transform.GetComponent<Statistics>().baby)
        {
            warpNormal();
        }
        else
        {
            warpBaby();
        }
    }
    public void warpNormal()
    {
        Normal.SetActive(true);
        Land.SetActive(false);
        Baby.SetActive(false);
        transform.GetComponent<Statistics>().actualLand = 0;
        transform.GetComponent<Statistics>().actualBabyID = -1;
        transform.GetComponent<Statistics>().baby = false;
    }
    public void warpLand()
    {
        Normal.SetActive(false);
        Land.SetActive(true);
        Baby.SetActive(false);
    }
    public void warpBaby()
    {
        Normal.SetActive(false);
        Land.SetActive(false);
        Baby.SetActive(true);
    }
}
