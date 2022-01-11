using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UnitData/InteractionNpxData")]
public class InteractionNpcData : UnitData
{
    public List<string> TalkData => talkData;
    [SerializeField] List<string> talkData = new List<string>();

}