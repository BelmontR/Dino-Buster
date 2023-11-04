using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public UIHeart[] hearts;

    public GameObject gameOverScreen;

    public UIInventorySlot[] UIInventory;


    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public void RemoveHeart()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if (!hearts[i].grey)
            {
                hearts[i].BecomeGrey();
                i += 100;   //Beendet den Loop
            }
        }
    }

    public void GameOver()
    {
        //Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void CollectItem(ItemAmountMapper iam)
    {
        for(int i = 0; i < UIInventory.Length; i++)
        {
            if (UIInventory[i].item == null)
            {
                UIInventory[i].count.SetText(iam.amount.ToString());
                UIInventory[i].image.sprite = iam.item.image;
                UIInventory[i].item = iam.item;

                return;
            }
            else if (UIInventory[i].item == iam.item)
            {
                UIInventory[i].count.SetText(iam.amount.ToString());

                return;

            }
            else
            {
                Debug.Log("Jo, Bruder, was ne Scheiße, wie konnte das passieren?");
            }
        }
    }

}
