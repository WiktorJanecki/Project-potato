
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using UnityEngine;

public class PotatoSpawner : MonoBehaviour
{
    float size = 2.5f;
    public GameObject prefab;
    bool doing = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFood());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnFood()
    {
        if (transform.childCount < 20)
        {
            doing = true;
            Vector3 pos = transform.position + new Vector3(Random.Range((-size / 2)+0.1f, (size / 2)-0.1f), Random.Range((-size / 2) + 1f, (size / 2)));
            GameObject gm = Instantiate(prefab, pos, Quaternion.identity);
            gm.transform.parent = transform;
           // gm.transform.position = gm.transform.position + new Vector3(0, 0, -1);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SpawnFood());
        }
        else
        {
            doing = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(new Vector3(transform.position.x,transform.position.y+0.5f,transform.position.z), new Vector3(1*size, 1*size, 1*size));
    }
    public void DeletePotato()
    {
        if (transform.childCount != 0) {
            Destroy(GetComponent<Transform>().GetChild(0).gameObject);
            Camera.main.GetComponent<Statistics>().increasePotatoes();
            if (!doing)
            {
                StartCoroutine(SpawnFood());
            }
        }
        else
        {
            if (!doing)
            {
                StartCoroutine(SpawnFood());
            }
        }
    }
}
