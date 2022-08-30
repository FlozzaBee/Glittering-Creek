using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sets the order in layer by the y coord so that objects further back in the scene are drawn above those in the foreground
public class OrderSorter : MonoBehaviour
{
    [Tooltip("Does this object move? if enabled z depth is only sorted on start")]
    public bool isStatic = true;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = -Mathf.RoundToInt(transform.position.y);
    }
    private void Update()
    {
        if (!isStatic)
        {
            spriteRenderer.sortingOrder = -Mathf.RoundToInt(transform.position.y);
        }
    }
    
}
