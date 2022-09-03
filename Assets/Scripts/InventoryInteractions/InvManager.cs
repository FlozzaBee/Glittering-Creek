using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Inventory Manager
// Handles picking up items, storing them, displaying them in teh hotbar, and the hot bar selector.
public class InvManager : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> invItemIcons;
    
    public List<string> invItemNames;

    [Header("Hotbar Variables")]
    [Tooltip("The canvas the hot bar is attached to")]
    public GameObject hotbarCanvas;
    [Tooltip("The parent object all the hotbar icons are attached to")]
    public GameObject hotbarIconParent;

    [Header("Hotbar Selector Variables")]
    public Image hotbarSelector;

    private Image[] hotbarImages;

    private int SelectorPosition = 1;

    public static InvManager Instance;

    //Brewing inventory 

    private void Awake()
    {
        ////Makes this class a singleton
        //if (Instance != null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        //Instance = this;
        //DontDestroyOnLoad(gameObject);

        //gets each hotbar image and assigns them to an array
        if (hotbarIconParent != null)
        {
            hotbarImages = new Image[hotbarIconParent.transform.childCount];
            for (int i = 0; i < hotbarIconParent.transform.childCount; i++)
            {
                hotbarImages[i] = hotbarIconParent.transform.GetChild(i).GetComponent<Image>();
            }
            UpdateHotbar();
        }
        else { Debug.Log("no hotbarIconParent found"); }
    }

    public void InventoryInteract(GameObject obj) // Gets data from the object interacted with and adds it to inventory list
    {
        InvInteractData data = obj.GetComponent<InvInteractData>();
        if (data.objectName == null || data.objectIcon == null)
        { Debug.Log("Inventory Interact Data not assigned"); }
        else
        {
            if (InvPersistant.Instance.invItemIcons.Count < 9)
            {
                InvPersistant.Instance.invItemIcons.Add(data.objectIcon);
                InvPersistant.Instance.invItemNames.Add(data.objectName);
                if (data.isSingleUse)
                {
                    data.DisableObject(); //just realised this could have just been a data.gameobject.setactive 
                }
            }
            else
            {
                Debug.Log("inventory full!");
            }
        }
        UpdateHotbar();
        
    }

    //sets each sprite in the hotbar to that stored in the collected object sprite list
    private void UpdateHotbar()
    {
        foreach(Image image in hotbarImages) //removes and hides each image slot in the hotbar
        {
            image.sprite = null;
            image.color = new Color(1, 1, 1, 0);
        }

        for(int i = 0; i < InvPersistant.Instance.invItemIcons.Count; i++) //sets and unhides hotbar images for each item in the persistant inventory
        {
            hotbarImages[i].sprite = InvPersistant.Instance.invItemIcons[i];
            //sets the alpha to 1. 
            Color color = hotbarImages[i].color;
            color.a = 1;
            hotbarImages[i].color = color;
        }
    }

    //shows or hides the hotbar, used to hide hotbar during dialogue
    public void ShowHotbar(bool show)
    {
        hotbarCanvas.SetActive(show);
    }

    //Hotbar selector 
    
    public void SetHotbarSelector(int slot) //Sets hotbar selector position from num keys
    {
        SelectorPosition = slot;
        UpdateHotbarSelector();
    }
    
    public void MoveHotbarSelector(int moveBy) //sets hotbar selector position from scroll
    {
        SelectorPosition += moveBy;
        if(SelectorPosition > 9)
        { SelectorPosition = 1; }
        if(SelectorPosition < 1)
        { SelectorPosition = 9; }
        UpdateHotbarSelector();
    }

    private void UpdateHotbarSelector() //Moves the hotbar selector to the relevent hotbar slots position, to show the player what they have selected
    {
        Debug.Log("hotbar selector at " + SelectorPosition);
        hotbarSelector.rectTransform.position = hotbarImages[SelectorPosition - 1].rectTransform.position;
    }

    public void RemoveItems(List<string> names)
    {
        for (int i = 0; i < names.Count; i++) //for each name in names
        {
            int index = InvPersistant.Instance.invItemNames.IndexOf(names[i]); //find the position in the inventory list of that name
            //remove the item (name and icon) at that position
            if (index < InvPersistant.Instance.invItemNames.Count) //checks for out of bounds, mostly to prevent errors when debuging/testing 
            {
                InvPersistant.Instance.invItemNames.RemoveAt(index); 
            }
            else { Debug.Log("Used item name not found in inventory"); }
            if (index < InvPersistant.Instance.invItemIcons.Count)
            {
                InvPersistant.Instance.invItemIcons.RemoveAt(index);
            }
            else { Debug.Log("Used item Icon not found in inventory"); }
        }
    }
    public void AddItem(string itemName, Sprite itemIcon)
    {
        InvPersistant.Instance.invItemNames.Add(itemName);
        InvPersistant.Instance.invItemIcons.Add(itemIcon);
    }

    public void DeliverItem(InteractionData data) //Removes the required item from inventory. Works similarly to the RemoveItems method but for only one item. 
    {
        int index = InvPersistant.Instance.invItemNames.IndexOf(data.requiredItem); //find the position in the inventory list of that name
                                                                           //remove the item (name and icon) at that position
        if (index < InvPersistant.Instance.invItemNames.Count) //checks for out of bounds, mostly to prevent errors when debuging/testing 
        {
            InvPersistant.Instance.invItemNames.RemoveAt(index);
        }
        else { Debug.Log("Used item name not found in inventory"); }
        if (index < InvPersistant.Instance.invItemIcons.Count)
        {
            InvPersistant.Instance.invItemIcons.RemoveAt(index);
        }
        else { Debug.Log("Used item Icon not found in inventory"); }
        UpdateHotbar();
    }
}
