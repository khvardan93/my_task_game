using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CardController : MonoBehaviour
{
    private SpriteRenderer CardRenderer;
    
    private void Start()
    {
        CardRenderer = GetComponent<SpriteRenderer>();
    }
}
