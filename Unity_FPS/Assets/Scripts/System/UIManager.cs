using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UIManager : MonoSingleton<UIManager>
{
    public LinkedList<RectTransform> PopUpUIList = new LinkedList<RectTransform>();
    //UI들의 렌더링 순서를 바꿔야함

}