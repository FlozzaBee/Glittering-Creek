using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//applies a zdepth dependent on the y hight in the screen, allowing for dynamic sorting of sprites
public class OrderSorter : MonoBehaviour
{
    [Tooltip("Does this object move? if enabled z depth is only sorted on start")]
    public bool isStatic = true;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sortingOrder = -Mathf.RoundToInt(transform.position.y);
    }
    private void Update()
    {
        if (!isStatic)
        {
            spriteRenderer.sortingOrder = -Mathf.RoundToInt(transform.position.y) + 1;
        }
    }
    
}
