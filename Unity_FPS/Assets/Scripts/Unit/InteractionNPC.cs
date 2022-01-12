using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionNPC : NPC
{
    public InteractionNpcData interactionNpcData => _interactionNpcData;
    [SerializeField] InteractionNpcData _interactionNpcData;

    GameObject _talkUI;
    GameObject talkUI
    {
        get
        {
            if (_talkUI == null)
            {
                _talkUI = Instantiate(ResourceUtils.Instance.InteractionNpc_TalkUI, ResourceUtils.Instance.MainCanvas);
            }
            return _talkUI;
        }
    }
    Text _talkText;
    Text talkText
    {
        get
        {
            if (_talkText == null)
            {
                _talkText = talkUI.GetComponentInChildren<Text>();
            }
            return _talkText;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Talk(0);
    }

    public void ShowTalkUI() => talkUI.SetActive(true);
    public void HideTalkUI() => talkUI.SetActive(false);

    /// <summary>
    /// ¥Î»≠
    /// </summary>
    /// <param name="index"></param>
    public virtual void Talk(int index)
    {
        if (index < 0 || index > interactionNpcData.TalkData.Count) return;
        ShowTalkUI();
        talkText.text = interactionNpcData.TalkData[index];
    }

    protected override void Dead()
    {

    }
}
