using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public ItemAmountMapper[] inventory;
    public int maxItemsCum;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void CollectItem(ItemAmountMapper item)
    {
        foreach(var items in inventory)
        {
            //if 
        }
    }


}
