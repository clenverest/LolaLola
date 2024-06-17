using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    private bool inventoryOn;

    void Start()
    {
        inventoryOn = false;
    }

    public void Chest()
    {
        if (!inventoryOn)
        {
            inventoryOn = true;
            inventory.SetActive(true);
        }
        else
        {
            inventoryOn = false;
            inventory.SetActive(false);
        }
    }

    public List<Slot> slots = new List<Slot>();

    public void AddItem(GameObject item)
    {
        foreach (var slot in slots)
        {
            if (slot.ItemPrefab == item)
            {
                slot.Amount++;
                if (slot.Amount < 2)
                {
                    slot.ItemAmountText.text = "";
                }
                else
                {
                    slot.ItemAmountText.text = slot.Amount.ToString();
                }
                return;
            }
        }
        foreach (var slot in slots)
        {
            if (slot.IsEmpty == true)
            {
                slot.ItemPrefab = item;
                slot.Amount++;
                slot.IsEmpty = false;
                slot.SetItem(item, slot.transform);
                slot.ItemAmountText.text = "";
                break;
            }
        }
    }

    public void DropItem(GameObject item)
    {
        foreach (var slot in slots)
        {
            if (slot.ItemPrefab == item)
            {
                if(slot.Amount > 2)
                {
                    slot.Amount--;
                    slot.ItemAmountText.text = slot.Amount.ToString();
                }
                else if(slot.Amount == 2)
                {
                    slot.Amount--;
                    slot.ItemAmountText.text = "";
                }
                else
                {
                    slot.ItemPrefab = null;
                    slot.DestroyItem(item);
                    slot.Amount = 0;
                    slot.ItemAmountText.text = "";
                    slot.IsEmpty = true;
                }
                return;
            }
        }
    }

    public bool Contains(GameObject item)
    {
        foreach (var slot in slots)
        {
            if (slot.ItemPrefab == item)
            {
                return true;
            }
        }

        return false;
    }

    public bool CheckAmount(GameObject item, int amount)
    {
        foreach (var slot in slots)
        {
            if (slot.ItemPrefab == item)
            {
                return slot.Amount == amount;
            }
        }

        return false;
    }
}
