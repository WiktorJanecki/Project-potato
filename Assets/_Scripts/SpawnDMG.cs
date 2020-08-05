using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDMG : MonoBehaviour
{
    public GameObject spawner;
    public GameObject dmg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn()
    {
        GameObject gm = Instantiate(dmg);
        gm.transform.SetParent(spawner.transform);
        gm.GetComponent<RectTransform>().localScale = new Vector3(10f, 10f, 10f);
    }
}
