using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryHeader : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] RectTransform inventoryRect;
    [SerializeField] RectTransform hearderRect;

    Coroutine dragCor;
    public void OnPointerDown(PointerEventData eventData)
    {
        dragCor = StartCoroutine(InventoryDrag(Input.mousePosition));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (dragCor != null)
            StopCoroutine(dragCor);

        dragCor = null;
    }

    IEnumerator InventoryDrag(Vector3 startPos)
    {
        Vector3 _inventoryPos = inventoryRect.position;
        while (true)
        {
            float a = inventoryRect.rect.size.y + hearderRect.rect.size.y;
            inventoryRect.position = _inventoryPos + Input.mousePosition - startPos;
            inventoryRect.position = new Vector3
                (Mathf.Clamp(inventoryRect.position.x, inventoryRect.rect.size.x * 0.5f , Camera.main.scaledPixelWidth - inventoryRect.rect.size.x * 0.5f),
                Mathf.Clamp(inventoryRect.position.y, a * 0.5f - hearderRect.rect.size.y * 0.5f, Camera.main.scaledPixelHeight - a * 0.5f - hearderRect.rect.size.y * 0.5f), inventoryRect.position.z);
            yield return null;
        }
    }

}
