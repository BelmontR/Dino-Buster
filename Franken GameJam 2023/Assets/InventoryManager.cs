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

                UIManager.instance.CollectItem(inventory[i]);
                break;
            }
            else if(inventory[i].item == item)
            {
                inventory[i].amount++;
                pickedUp = true;

                ScaleEffect(inventory[i]);

                UIManager.instance.CollectItem(inventory[i]);
                break;
            }
        }

        if (pickedUp) { currentCum++; }

        if(currentCum >= maxItemsCum || !pickedUp)
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
        int temp = (iam.amount < 20) ? iam.amount : 20;

        switch (iam.item.name)
        {
            case "Axe":
                axe.ResetStats();

                axe.stats.IncreaseKbStrength(temp * 0.1f);
                axe.stats.IncreaseKbLength(temp * 0.05f);
                axe.stats.IncreaseStrength(temp * 0.05f);
                break;

            case "Spear":
                spear.ResetStats();

                spear.stats.IncreaseStrength(temp * 0.2f);
                break;

            case "Stone":
                ssc.ResetCooldown();
                ssc.DecreaseCooldown(temp * 0.05f);
                break;

            case "Hammer":
                hammer.ResetStats();

                hammer.stats.IncreaseKbStrength(temp * 0.125f);
                hammer.stats.IncreaseKbLength(temp * 0.075f);
                break;

            case "Bone":
                GameManager.instance.player.ResetSpeed();
                GameManager.instance.player.speed *= (1 + (temp * 0.1f));
                break;

            case "Egg":
                GameManager.instance.player.ResetInvincTime();
                GameManager.instance.player.invincibilityTime += (temp * 0.2f);
                if(GameManager.instance.player.invincibilityTime > 5f)
                {
                    GameManager.instance.player.invincibilityTime = 5f;
                }
                break;

        }

    }

    public void KillInventory()
    {
        Debug.Log("InvKill 1");

        //Reset all Effects
        axe.gameObject.SetActive(true);
        axe.ResetStats();
        axe.gameObject.SetActive(false);

        //spear.ResetStats();

        ssc.gameObject.SetActive(true);
        ssc.ResetCooldown();
        ssc.gameObject.SetActive(false);

        hammer.gameObject.SetActive(true);
        hammer.ResetStats();
        hammer.gameObject.SetActive(false);

        GameManager.instance.player.ResetSpeed();
        GameManager.instance.player.ResetInvincTime();

        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = null;
        }

        UIManager.instance.ClearUIInventory();

        GameManager.instance.KillAllEnemies();
        GameManager.instance.ScaleEnemies(currentCum / maxItemsCum);

        Debug.Log("InvKill 2");


    }

    public bool InventoryKillable()
    {
        return currentCum >= (maxItemsCum / 2);
    }

}
