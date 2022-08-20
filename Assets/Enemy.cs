using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 2;
    Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    internal void SetDamage(int power)
    {
        hp -= power;

        if (hp <= 0)
            StartCoroutine(Die());
        else
            animator.SetTrigger("Attacked");
    }

    public float dieAnimationTime = 1f;
    private IEnumerator Die()
    {
        GetComponent<MoveToPlayer>().enabled = false;   
        GetComponent<Collider>().enabled = false;
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(dieAnimationTime);
        Destroy(gameObject);
    }
}
