using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipByDirection : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    IMover mover;
    void Start()
    {
        if(spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        mover = gameObject.GetComponent<IMover>();
    }
    void Update()
    {
        if(mover.DirectionX < 0)
            spriteRenderer.flipX = true;
        else if (mover.DirectionX > 0)
            spriteRenderer.flipX = false;
    }
}

interface IMover
{
    float DirectionX { get; }
}
