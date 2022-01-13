using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Header : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] RectTransform moveRect;
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
        Vector3 _inventoryPos = moveRect.position;
        while (true)
        {
            float a = moveRect.rect.size.y + hearderRect.rect.size.y;
            moveRect.position = _inventoryPos + Input.mousePosition - startPos;
            moveRect.position = new Vector3
                (Mathf.Clamp(moveRect.position.x, moveRect.rect.size.x * 0.5f, Camera.main.scaledPixelWidth - moveRect.rect.size.x * 0.5f),
                Mathf.Clamp(moveRect.position.y, a * 0.5f - hearderRect.rect.size.y * 0.5f, Camera.main.scaledPixelHeight - a * 0.5f - hearderRect.rect.size.y * 0.5f), moveRect.position.z);
            yield return null;
        }
    }

}