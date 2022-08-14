using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipByKey : MonoBehaviour
{
    public KeyCode flipXKey = KeyCode.A;
    public KeyCode unflipXKey = KeyCode.D;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(Input.GetKeyDown(flipXKey))
            spriteRenderer.flipX = true;
        else if (Input.GetKeyDown(unflipXKey))
            spriteRenderer.flipX = false;
    }
}
