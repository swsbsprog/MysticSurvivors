using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int hp = 2;
    Animator animator;
    SpriteRenderer sr;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    internal void SetDamage(int power)
    {
        hp -= power;

        if (hp <= 0)
            StartCoroutine(Die());
        else
            StartCoroutine(AttackedCo());
    }

    public float blinkTime = 0.1f;
    private IEnumerator AttackedCo()
    {
        animator.SetTrigger("Attacked");
        sr.color = Color.red;
        yield return new WaitForSeconds(blinkTime);
        sr.color = Color.white;
    }

    public float dieAnimationTime = 1f;

    public List<DropItem> dropItems;
    public float dropRange = 0.1f;
    private IEnumerator Die()
    {
        GetComponent<MoveToPlayer>().enabled = false;   
        GetComponent<Collider>().enabled = false;
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(dieAnimationTime);
        Destroy(gameObject);

        float count = dropItems.Count * dropRange;
        dropItems.ForEach(x =>
        {
            var dropItem = Instantiate(x);
            dropItem.transform.position = transform.position
            + new Vector3(Random.Range(-count, count), 0, Random.Range(-count, count));
        });
    }
}
