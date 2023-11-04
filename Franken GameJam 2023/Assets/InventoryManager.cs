using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public ItemAmountMapper[] inventory;
    public int maxItemsCum;
    public int currentCum;

    public DamageHitbox axe;
    public DamageHitbox spear;
    public DamageHitbox hammer;
    public SlingshotController ssc;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            inventory = new ItemAmountMapper[4];
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

                ActivateEffect(item);

                break;
            }
            else if(inventory[i].item == item)
            {
                inventory[i].amount++;
                pickedUp = false;

                ScaleEffect(inventory[i]);

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
        switch (item.name)
        {
            case "Axe":
                GameManager.instance.player.axeController.SetActive(true);
                break;

            case "Spear":
                GameManager.instance.player.spearController.SetActive(true);
                break;

            case "Stone":
                GameManager.instance.player.slingShotController.SetActive(true);
                break;

            case "Hammer":
                GameManager.instance.player.clubController.SetActive(true);
                break;

            case "Bone":
                break;

            case "Egg":
                break;

        }
    }

    public void ScaleEffect(ItemAmountMapper iam)
    {
        switch (iam.item.name)
        {
            case "Axe":
                axe.ResetStats();

                axe.stats.IncreaseKbStrength(iam.amount * 0.1f);
                axe.stats.IncreaseKbLength(iam.amount * 0.05f);
                axe.stats.IncreaseStrength(iam.amount * 0.05f);
                break;

            case "Spear":
                spear.ResetStats();

                spear.stats.IncreaseStrength(iam.amount * 0.2f);
                break;

            case "Stone":
                ssc.ResetCooldown();
                ssc.DecreaseCooldown(iam.amount * 0.05f);
                break;

            case "Hammer":
                hammer.ResetStats();

                hammer.stats.IncreaseKbStrength(iam.amount * 0.135f);
                hammer.stats.IncreaseKbLength(iam.amount * 0.075f);
                break;

            case "Bone":
                GameManager.instance.player.ResetSpeed();
                GameManager.instance.player.speed *= 1 + (iam.amount * 0.1f);
                break;

            case "Egg":
                GameManager.instance.player.ResetInvincTime();
                GameManager.instance.player.invincibilityTime += (iam.amount * 0.1f);
                if(GameManager.instance.player.invincibilityTime > 5f)
                {
                    GameManager.instance.player.invincibilityTime = 5f;
                }
                break;

        }

    }

}
