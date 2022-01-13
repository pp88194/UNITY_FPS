using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public ItemData data;
    public int count;

    public Item(ItemData _data, int _count)
    {
        data = _data;
        count = _count;
    }
}

public class Inventory : MonoBehaviour
{
    InventoryUI inventoryUI;

    public int inventoryLength;
    public Item[] itemInventory;

    [SerializeField] ItemData a;
    [SerializeField] int __count;

    private void Awake()
    {
        itemInventory = new Item[inventoryLength];
        GetComponent<GameManager>().inventory = this;
        inventoryUI = GetComponent<InventoryUI>();
    }

    public void GetItem(ItemData itemData, int count)
    {
        for (int i = 0; i < itemInventory.Length; i++)
        {
            if (itemInventory[i].data != null)
            {
                if (itemInventory[i].data.id == itemData.id)
                {
                    if (itemInventory[i].count + count <= itemData.maxAmount)
                    {
                        itemInventory[i].count += count;
                        inventoryUI.ItemRefresh();
                        return;
                    }
                    else
                    {
                        count = itemInventory[i].count + count - itemData.maxAmount;
                        itemInventory[i].count = itemData.maxAmount;
                    }
                }
            }
        }
        for (int i = 0; i < itemInventory.Length; i++)
        {
            if (itemInventory[i].data == null)
            {
                itemInventory[i] = new Item(itemData, count);
                inventoryUI.AddItem(i);
                break;
            }
        }
    }

    public void ClearItem(int index)
    {
        itemInventory[index] = new Item(null, 0);
    }
}