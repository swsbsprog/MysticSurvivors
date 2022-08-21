using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour, IMover
{
    float IMover.DirectionX => moveDirection.x;
    public float speed = 2;
    public float acceleration = 0.1f;
    Vector3 moveDirection;
    void Update()
    {
        moveDirection = Player.Instance.transform.position - transform.position;
        moveDirection.Normalize();
        speed += acceleration * Time.deltaTime;
        transform.Translate(speed * Time.deltaTime * moveDirection);
    }
}
