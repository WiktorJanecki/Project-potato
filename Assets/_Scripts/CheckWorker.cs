using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWorker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        GameObject player = Camera.main.transform.gameObject;
        int index = transform.parent.transform.GetSiblingIndex();
        player.GetComponent<Statistics>().actaulWorker = player.GetComponent<Statistics>().workersObjects[index].id;
    }
}
