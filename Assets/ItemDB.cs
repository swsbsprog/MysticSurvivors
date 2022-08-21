using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public static ItemDB Instance;
    private void Awake() => Instance = this;
    public List<DropRatio> dropItems;
    public int dropCountMin = 0;
    public int dropCountMax = 2;
}

[System.Serializable]
public class DropRatio
{
    public DropItem dropItem;
    public float ratio;
}