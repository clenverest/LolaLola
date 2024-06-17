using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Inventory inventory;
    [SerializeField] GameObject money;
    [SerializeField] GameObject note;
    [SerializeField] GameObject knife;

    private void Start()
    {
        inventory = player.GetComponent<Inventory>();
    }

    public void AddMoney()
    {
        inventory.AddItem(money);
    }

    public void AddNote()
    {
        inventory.AddItem(note);
    }

    public void AddKnife()
    {
        inventory.AddItem(knife);
    }

    public void DropMoney()
    {
        inventory.DropItem(money);
    }

    public void DropNote()
    {
        inventory.DropItem(note);
    }

    public void DropKnife()
    {
        inventory.DropItem(knife);
    }
}
