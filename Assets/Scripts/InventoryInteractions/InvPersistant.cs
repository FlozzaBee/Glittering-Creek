using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvPersistant : MonoBehaviour
{
    //Held item names and sprites
    public List<Sprite> invItemIcons;
    public List<string> invItemNames;

    //Current target recipe
    public string currentRecipe;
    public static InvPersistant Instance;
    private void Awake()
    {
        //Makes this class a singleton
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void RemoveItems(List<string> names)
    {
        for (int i = 0; i < names.Count; i++) //for each name in names
        {
            int index = invItemNames.IndexOf(names[i]); //find the position in the inventory list of that name
            //remove the item (name and icon) at that position
            if (index < invItemNames.Count) //checks for out of bounds, mostly to prevent errors when debuging/testing 
            {
                invItemNames.RemoveAt(index);
            }
            else { Debug.Log("Used item name not found in inventory"); }
            if (index < invItemIcons.Count)
            {
                invItemIcons.RemoveAt(index);
            }
            else { Debug.Log("Used item Icon not found in inventory"); }
        }
    }
    public void AddItem(string itemName, Sprite itemIcon)
    {
        if (invItemNames.Count < 9)
        {
            invItemNames.Add(itemName);
            invItemIcons.Add(itemIcon);
        }
        else { Debug.Log("Inventory Full!"); }
    }
}
