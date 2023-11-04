using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAmountMapper
{
    public InventoryEntity item;
    public int amount;

    public ItemAmountMapper(InventoryEntity item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}
