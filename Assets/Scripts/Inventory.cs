using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Equipment> items = new List<Equipment>();
    public Equipment mainHand;
    private int scrollIndex = 0;

    public Inventory()
    {
        items.Add(null);
    }

    public void Add(Equipment item)
    {
        items.Add(item);
    }

    public void Remove(Equipment item)
    {
        items.Remove(item);
    }

    public void EquipMainHand()
    {
        if (items.Count > 1)
        {
            mainHand = items[1];
            scrollIndex = 1;
            Debug.Log("Equipped: " + mainHand.Name);
        }
    }

    public void RemoveFromMainHand()
    {
        mainHand = null;
        scrollIndex = 0;
    }

    public void Scroll(int direction)
    {
        if (items.Count > 1)
        {
            scrollIndex += direction;
            if (scrollIndex < 1)
                scrollIndex = items.Count - 1;
            else if (scrollIndex > items.Count - 1)
                scrollIndex = 1;

            mainHand = items[scrollIndex];
            Debug.Log("Equipped: " + mainHand.Name);
        }
    }
}