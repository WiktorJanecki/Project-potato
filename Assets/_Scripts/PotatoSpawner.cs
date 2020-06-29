
using System.Collections;
using UnityEngine;

public class PotatoSpawner : MonoBehaviour
{
    float size = 2.5f;
    public GameObject prefab;
    bool doing = false;
    public AudioSource source;
    public GameObject click;
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
            gm.transform.SetParent(transform);
           // gm.transform.position = gm.transform.position + new Vector3(0, 0, -1);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SpawnFood());
        }
        else
        {
            doing = false;
            click.SetActive(true);
        }
    }
    public void OnEnable()
    {
        StartCoroutine(SpawnFood());
    }
    public void OnDisable()
    {
        StopCoroutine(SpawnFood());
    }
    public void DeletePotato()
    {
        click.SetActive(false);
        if (transform.childCount != 0) {
            Destroy(GetComponent<Transform>().GetChild(0).gameObject);
            Camera.main.GetComponent<Statistics>().increasePotatoes();
            source.Play();
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
