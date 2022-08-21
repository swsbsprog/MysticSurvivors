using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public ItemType itemType;
    public int value = 1;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;

        player.GetItem(itemType, value);
        Destroy(gameObject);
    }
}
