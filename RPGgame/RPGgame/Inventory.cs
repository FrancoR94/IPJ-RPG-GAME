using System;
using System.Collections.Generic;
using System.Text;

class Inventory
{
    private List<InventorySlot> inventory;
    private int size;
    public Inventory(int size)
    {
        this.size = size;
    }
    public void AddItem(Item item, int amount)
    {
        bool alreadyContained = false;
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].item.name == item.name)
            {
                alreadyContained = true;
            }
        }
        if(alreadyContained)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if(inventory[i].item.name == item.name)
                {
                    inventory[i].amount += amount;
                }
            }
        }
        else
        {
            if (inventory.Count < size)
            {
                inventory.Add(new InventorySlot(item, amount));
            }
        }
    }
}

class InventorySlot
{
    public Item item;
    public int amount;
    public InventorySlot(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}
public class Item
{
    public string name;
    public int prize;
    public string description;

    public Item(string name, int prize, string description)
    {
        this.name = name;
        this.prize = prize;
        this.description = description;
    }

}
