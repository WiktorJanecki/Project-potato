using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Upgrade", order = 1)]
public class Upgrade : ScriptableObject
{
    public new string name = "";
    public string description = "";
    public int price = 0;
    public int value = 0;
    public Sprite image;
}
