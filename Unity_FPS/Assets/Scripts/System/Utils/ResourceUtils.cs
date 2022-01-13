using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceUtils : MonoSingleton<ResourceUtils>
{
    public GameObject InteractionNpc_TalkUI;
    public Transform MainCanvas;

    private void Awake()
    {
        MainCanvas = GameObject.Find("Canvas").transform;
        InteractionNpc_TalkUI = Resources.Load<GameObject>("InteractionUI_TalkUI");
    }
}
