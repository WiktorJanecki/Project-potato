using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Children
{
    public int id = 0;
    public string name = "";
    public float speed = 1.0f;
    public int capacity = 5000;
    public float grow = 0.0f;
    public long obstain;
    public long fullGrow;
    public long lastOpen;
}
