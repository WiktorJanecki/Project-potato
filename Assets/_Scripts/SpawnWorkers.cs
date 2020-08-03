using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWorkers : MonoBehaviour
{
    public GameObject player;
    public GameObject children;
    public GameObject parent;
    void Start()
    {
        doo();
    }

    void Update()
    {
        
    }
    private void OnEnable()
    {
        doo();
    }

    public void doo()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < player.GetComponent<Statistics>().workersObjects.Count; i++)
        {
            GameObject gm = Instantiate(children);
            gm.transform.SetParent(parent.transform);
            //gm.GetComponent<RectTransform>().position = new Vector(0);
            gm.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
}
