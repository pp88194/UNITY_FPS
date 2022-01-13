using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryScaler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] RectTransform inventoryRect;
    [SerializeField] RectTransform scalerRect;

    Coroutine scalingCor;

    public void OnPointerDown(PointerEventData eventData)
    {
        scalingCor = StartCoroutine(Scaling());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(scalingCor != null)
        {
            StopCoroutine(scalingCor);
            scalingCor = null;
        }
    }

    IEnumerator Scaling()
    {
        Vector3 startPos_s = scalerRect.position;
        Vector3 startPos_i = inventoryRect.position;
        Vector2 startScl = inventoryRect.sizeDelta;

        Vector2 limit = new Vector2(startPos_s.x -  inventoryRect.sizeDelta.x + 420, startPos_s.y + inventoryRect.sizeDelta.y - 400);
        

        Vector2 move;
        while (true)
        {
            scalerRect.position = Input.mousePosition;

            scalerRect.position = new Vector3(Mathf.Clamp(scalerRect.position.x, limit.x, 1920), Mathf.Clamp(scalerRect.position.y, 0, limit.y), scalerRect.position.z);

            

            move = startScl + new Vector2(scalerRect.position.x - startPos_s.x, startPos_s.y - scalerRect.position.y);


            inventoryRect.position = startPos_i + new Vector3(scalerRect.position.x - startPos_s.x, scalerRect.position.y - startPos_s.y, inventoryRect.position.z) * 0.5f;

            inventoryRect.sizeDelta = move;
            yield return null;
        }
    }
}
