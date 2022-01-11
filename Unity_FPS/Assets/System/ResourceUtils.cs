using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceUtils : MonoBehaviour
{
    #region Singleton
    static public ResourceUtils Instance { 
        get
        {
            if(instance == null)
            {
                GameObject container = new GameObject("$ResourceUtils");
                instance = container.AddComponent<ResourceUtils>();
            }
            return instance;
        } 
    }
    static ResourceUtils instance;
    #endregion
    public GameObject InteractionNpc_TalkUI;
    public Transform MainCanvas;

    private void Awake()
    {
        MainCanvas = GameObject.Find("Canvas").transform;
        InteractionNpc_TalkUI = Resources.Load<GameObject>("InteractionUI_TalkUI");
    }
}
