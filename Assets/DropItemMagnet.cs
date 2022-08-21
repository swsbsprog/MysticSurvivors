using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemMagnet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var dropItem = other.GetComponent<DropItem>();
        if (dropItem == null)
            return;

        var moveToPlayer = dropItem.GetComponent<MoveToPlayer>();
        if(moveToPlayer != null)
            moveToPlayer.enabled = true;
    }
}
