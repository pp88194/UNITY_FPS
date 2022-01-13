using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Inventory inventory;
    public InventoryUI inventoryUI;
    private void Awake()
    {
        instance = this;
    }
}