using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public InventoryEntity item;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            if(InventoryManager.instance.CollectItem(item))
            {
                Destroy(this.gameObject);
            }
        }
    }

}
