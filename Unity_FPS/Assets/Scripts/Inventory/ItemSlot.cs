using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    public Text countText;
    private int itemInventoryIndex;
    public int slotIndex;
    public int ItemInventoryIndex
    {
        get
        {
            return itemInventoryIndex;
        }
        set
        {
            itemInventoryIndex = value;
            Debug.Log(value);
            if (value == -1)
            {
                countText.text = "";
                icon.sprite = null;
                InItem = false;
            }
            else
            {
                itemInventoryIndex = value;
                countText.text = GameManager.instance.inventory.itemInventory[value].count != 1 ? GameManager.instance.inventory.itemInventory[value].count.ToString() : "";
                icon.sprite = GameManager.instance.inventory.itemInventory[value].data.icon;
                InItem = true;
            }
        }
    }
    public bool InItem
    {
        get
        {
            return inItem;
        }
        set
        {
            //Debug.Log("123");
            icon.gameObject.SetActive(value);
            inItem = value;
        }
    }
    bool inItem = false;
}
