using UnityEngine;
using UnityEngine.UI;

public class ButtonGetItem : MonoBehaviour
{
    [SerializeField] ItemData data;
    [SerializeField] int count;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(GetItem);
    }

    private void GetItem()
    {
        GameManager.Instance.inventory.GetItem(data,count);
    }
}
