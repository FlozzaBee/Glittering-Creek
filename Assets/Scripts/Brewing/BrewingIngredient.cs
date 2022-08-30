using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Holds data on an ingredient so that it can be passed to the BrewingManager via a button OnClick
public class BrewingIngredient : MonoBehaviour
{
    [Header("Ingredient properties")]
    public string ingredientName;
    public Color ingredientColor = Color.white;
    public bool isLiquid = false;    
}
