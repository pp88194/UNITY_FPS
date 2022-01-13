using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Inventory inventory;
    public InventoryUI inventoryUI;
    public static GameManager Instance;
    public void OnOffButton(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    private void Awake()
    {
        Instance = this;
    }
}
