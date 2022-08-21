using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private void Awake() => Instance = this;
    public int hp = 10;
    public void GetItem(ItemType itemType, int value)
    {
        switch(itemType)
        {
            case ItemType.AddScore:
                StageManager.instance.AddScore(value);
                break;
            case ItemType.AddHp:
                AddHp(value);
                break;
        }
    }

    private void AddHp(int addHp)
    {
        hp += addHp;
    }
}

public enum ItemType
{
    AddScore,
    AddHp,
}
