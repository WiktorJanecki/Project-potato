using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public int potatoes = 0;
    public float coins = 0;

    public float potatoPrice = 0.1f;
    public int bonus = 0;
    public string upgrades = "0000";

    public int lands = 0;
    public int actualLand = 0;
    public string[] landUpgrades;
    public int[,] landColors;

    public bool baby = false;
    public int children = 0;
    public int childrenProgress = 0;
    public List<Children> childrenObjects = new List<Children>();
    private string[] names = { 
        "Emma","Olivia","Ava","Isabella","Sophia","Charlotte","Mia","Amelia","Harper","Evelyn","Abigail","Emily","Elizabeth","Mila","Ella",
        "Liam","Noah","Wiliam","James","Oliver","Benjamin","Elijah","Lucas","Mason","Logan","Alexander","Ethan","Jacob","Michael","Daniel",
        "wiktor","Victor","wiktor","wiktor","wiktor"
    };
    public int actualBabyID = -1;


    void Start()
    {
    }
    void Update()
    {
        
    }
    public void increasePotatoes()
    {
        potatoes += 1+bonus;
    }
    public void switchBaby()
    {
        baby = !baby;
    }
    #region BabyBorn
    [SerializeField]
    private GameObject stomach;
    [SerializeField]
    private AudioSource cry;
    [SerializeField]
    private GameObject childObjCreator;
    public void addPotatoesToProgress()
    {
        if(potatoes >= 100)
        {
            potatoes -= 100;
            childrenProgress += 100;
            int maxProgress;
            if(children == 0)
            {
                maxProgress = 5000;
                if(childrenProgress >= maxProgress)
                {
                    childrenProgress -= maxProgress;
                    Born();
                    cry.Play();
                }
            }
            else
            {
                maxProgress = children * 5000 * 2;
                if (childrenProgress >= maxProgress)
                {
                    childrenProgress -= maxProgress;
                    Born();
                    cry.Play();
                }
            }
            if((childrenProgress*1.0f) / (maxProgress*1.0f) >= 0.25f)
            {
                stomach.SetActive(true);
            }
            if ((childrenProgress * 1.0f) / (maxProgress * 1.0f) >= 0.50f)
            {
                stomach.GetComponent<RectTransform>().localScale = new Vector3(1.2f,1.2f,1.2f);
            }
            if ((childrenProgress * 1.0f) / (maxProgress * 1.0f) >= 0.75f)
            {
                stomach.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            if ((childrenProgress * 1.0f) / (maxProgress * 1.0f) >= 0.90f)
            {
                stomach.GetComponent<RectTransform>().localScale = new Vector3(2f, 2f, 2);
            }
            if ((childrenProgress * 1.0f) / (maxProgress * 1.0f) <0.25f)
            {
                stomach.SetActive(false);
                stomach.GetComponent<RectTransform>().localScale = new Vector3(0f, 0f, 0f);
            }
        }
    }
    private void Born()
    {
        Children child = new Children();
        child.id = children;
        child.name = names[UnityEngine.Random.Range(0, names.Length)];
        child.speed = UnityEngine.Random.Range(0.5f, 1f);
        int rarity = UnityEngine.Random.Range(0, 100);
        if(rarity < 50)
        {
            child.capacity = UnityEngine.Random.Range(1000, 5000);
        }
        if(rarity >= 50)
        {
            child.capacity = UnityEngine.Random.Range(5000, 8000);
        }
        if(rarity >= 90)
        {
            child.capacity = UnityEngine.Random.Range(10000, 20000);
        }
        child.grow = 0.0f;
        child.obstain = DateTime.Now.Ticks / 10000000;
        child.fullGrow = child.obstain + UnityEngine.Random.Range(2 * 3600, 24 * 3600);
        child.lastOpen = child.obstain;

        childrenObjects.Add(child);

        childObjCreator.GetComponent<SpawnChildrenButtons>().doo();
        children += 1;
    }
    #endregion BabyBorn
}
