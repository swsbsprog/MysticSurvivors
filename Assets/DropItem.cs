using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public int addScore = 1;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;

        //���� ����.
        StageManager.instance.AddScore(addScore);
        Destroy(gameObject);
    }
}
