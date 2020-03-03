using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeImage : MonoBehaviour
{
    private void Start()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.transform.localScale = new Vector2(0.5f, 0.5f);
    }
}