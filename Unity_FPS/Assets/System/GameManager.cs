using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    void CreatePlayer()
    {
        GameObject container = new GameObject("Player");
        container.AddComponent<Player>();
    }
}