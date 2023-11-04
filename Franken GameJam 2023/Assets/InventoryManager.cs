using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public ItemAmountMapper[] inventory;
    public int maxItemsCum;
    public int currentCum;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public bool CollectItem(InventoryEntity item)
    {
        bool pickedUp = false;

        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = new ItemAmountMapper(item, 1);
                pickedUp = true;
                break;
            }
            else if(inventory[i].item == item)
            {
                inventory[i].amount++;
                pickedUp = false;
                break;
            }
        }

        if (pickedUp) { currentCum++; }

        if(currentCum >= maxItemsCum)
        {
            UIManager.instance.GameOver();
        }

        return pickedUp;
    }

    public void ActivateEffect(InventoryEntity item)
    {

    }

    public void ScaleEffect(ItemAmountMapper iam)
    {

    }

}
