using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject slotUIPrefab;
    public GameObject inventoryContents;
    public Canvas canvas;

    GraphicRaycaster g_raycast;
    PointerEventData ped;

    Inventory inventory;

    public ItemSlot[] itemSlot;

    private void Awake()
    {
        g_raycast = canvas.GetComponent<GraphicRaycaster>();
        ped = new PointerEventData(null);

        //GetComponent<GameManager>().inventoryUI = this;
        inventory = GetComponent<Inventory>();
        itemSlot = new ItemSlot[inventory.inventoryLength];

        for (int i = 0; i < inventory.inventoryLength; i++)
        {
            itemSlot[i] = Instantiate(slotUIPrefab, inventoryContents.transform).GetComponent<ItemSlot>();
            itemSlot[i].ItemInventoryIndex = -1;
            itemSlot[i].slotIndex = i;
        }
    }

    private void Update()
    {
        GraphicRaycast();
    }

    public void ItemSlotReSet()
    {
        for (int i = 0; i < inventory.itemInventory.Length; i++)
            itemSlot[i].ItemInventoryIndex = i;
    }
    public void GraphicRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ped.position = Input.mousePosition;
            List<RaycastResult> result = new List<RaycastResult>();
            g_raycast.Raycast(ped,result);

            if (result.Count > 0 && result[0].gameObject.CompareTag("ItemSlot"))
            {
                ItemSlot slot = result[0].gameObject.GetComponent<ItemSlot>();
                if (slot.InItem)
                {
                    StartCoroutine(IconDrag(slot));
                }
            }
        }
    }

    public void AddItem(int _index)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].ItemInventoryIndex == -1)
            {
                itemSlot[i].ItemInventoryIndex = _index;
                return;
            }
        }
    }
    public void ItemRefresh()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].ItemInventoryIndex = itemSlot[i].ItemInventoryIndex;
        }
    }

    IEnumerator IconDrag(ItemSlot slot)
    {
        slot.icon.transform.SetParent(canvas.transform);
        RectTransform slotRect = slot.icon.GetComponent<RectTransform>();
        RectTransform contentsRect = inventoryContents.GetComponent<RectTransform>();
        Vector2 startPos = contentsRect.position;
        while (true)
        {
            contentsRect.position = startPos;
            slotRect.position = Input.mousePosition;
            if (Input.GetMouseButtonUp(0))
            {
                ped.position = Input.mousePosition;
                List<RaycastResult> result = new List<RaycastResult>();
                g_raycast.Raycast(ped, result);
                if(result.Count == 0)
                {
                    Debug.Log("아이템 버려?");
                    inventory.ClearItem(slot.ItemInventoryIndex);
                    slot.ItemInventoryIndex = -1;
                }
                else if (result.Count > 0 && result[0].gameObject.CompareTag("ItemSlot"))
                {
                    ItemSlot slot2 = result[0].gameObject.GetComponent<ItemSlot>();
                    SlotSwap(slot, slot2);
                }
                break;
            }
            yield return null;
        }
        slot.icon.transform.SetParent(slot.transform);
        slotRect.anchoredPosition = Vector2.zero;
    }
    void SlotSwap(ItemSlot slot1, ItemSlot slot2)
    {
        int temp = slot2.ItemInventoryIndex;
        slot2.ItemInventoryIndex = slot1.ItemInventoryIndex;
        slot1.ItemInventoryIndex = temp;
    }
}