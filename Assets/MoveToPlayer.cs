using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour, IMover
{
    float IMover.DirectionX => moveDirection.x;
    public float speed = 2;

    Vector3 moveDirection;
    void Update()
    {
        moveDirection = Player.Instance.transform.position - transform.position;
        moveDirection.Normalize();
        transform.Translate(speed * Time.deltaTime * moveDirection);
    }
}
