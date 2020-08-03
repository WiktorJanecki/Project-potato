using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveNLoad : MonoBehaviour
{
    public GameObject player;
    public GameObject[] upgrades;
    public GameObject[] landUpgrades;

    [System.Serializable]
    class Player
    {
        public int potatoes;
        public float coins;
        public string upgrades;
        public int lands;
        public int[,] landColors;
        public string[] landUpgrades;
        public int children;
        public int childProgress;
        public List<Children> childrenObj;
        public List<Children> workersObj;
        public List<Children> landWorkers;

        public Player(Statistics stats)
        {
            potatoes = stats.potatoes;
            coins = stats.coins;
            upgrades = stats.upgrades;
            lands = stats.lands;
            landColors = stats.landColors;
            landUpgrades = stats.landUpgrades;
            children = stats.children;
            childProgress = stats.childrenProgress;
            childrenObj = stats.childrenObjects;
            workersObj = stats.workersObjects;
            landWorkers = stats.landWorkers;
        }
    }

    IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(3);
        Save();
        StartCoroutine(AutoSave());
    }

    public void Load()
    {
        string path = Path.Combine(Application.persistentDataPath, "player.save");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Player data = formatter.Deserialize(stream) as Player;

            stream.Close();
            player.GetComponent<Statistics>().potatoes = data.potatoes;
            player.GetComponent<Statistics>().coins = data.coins;
            player.GetComponent<Statistics>().upgrades = data.upgrades;
            player.GetComponent<Statistics>().lands = data.lands;
            player.GetComponent<Statistics>().landColors = data.landColors;
            player.GetComponent<Statistics>().landUpgrades = new string[data.lands];
            for (int j = 0; j < player.GetComponent<Statistics>().landUpgrades.Length; j++)
            {
                player.GetComponent<Statistics>().landUpgrades[j] = data.landUpgrades[j];
            }
            player.GetComponent<Statistics>().children = data.children;
            player.GetComponent<Statistics>().childrenProgress = data.childProgress;
            player.GetComponent<Statistics>().childrenObjects = data.childrenObj;
            player.GetComponent<Statistics>().workersObjects = data.workersObj;
            player.GetComponent<Statistics>().landWorkers = data.landWorkers;

            while(player.GetComponent<Statistics>().landWorkers.Count < player.GetComponent<Statistics>().lands)
            {
                player.GetComponent<Statistics>().landWorkers.Add(null);
            }
        }
        
    }
    private void Start()
    {
        Load();
        StartCoroutine(AutoSave());

        for (int i = 0; i < upgrades.Length; i++)
        {
            if (player.GetComponent<Statistics>().upgrades[i] == '1')
            {
                upgrades[i].GetComponent<Buy>().GetUpgrade();
            }
        }
        for (int j = 0; j < landUpgrades.Length;j++) {

            for (int i = 0; i < player.GetComponent<Statistics>().landUpgrades[0].Length; i++)
            {
                if (player.GetComponent<Statistics>().landUpgrades[j][i] == '1')
                {
                    landUpgrades[i].GetComponent<Buy>().GetLandUpgrade();
                }
            }
        }
    }
    public void UpdateLandButtons()
    {
        if (player.GetComponent<Statistics>().actualLand > 0)
        {
            for(int i = 0; i < landUpgrades.Length; i++)
            {
                if(player.GetComponent<Statistics>().landUpgrades[player.GetComponent<Statistics>().actualLand-1][i] == '1')
                {
                    landUpgrades[i].SetActive(false);
                }
                else if(player.GetComponent<Statistics>().landUpgrades[player.GetComponent<Statistics>().actualLand-1][i] == '0')
                {
                    landUpgrades[i].SetActive(true);
                }
            }
        }
    }

    void Update()
    {
        if(player.GetComponent<Statistics>().actualLand == 1)
        {
            UpdateLandButtons();
        }
    }
    private void OnApplicationQuit()
    {
        Save();
    }
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "player.save");
        FileStream stream = new FileStream(path, FileMode.Create);

        Player playerobj = new Player(player.GetComponent<Statistics>());

        formatter.Serialize(stream, playerobj);
        stream.Close();
    }
}
