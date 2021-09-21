using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelMove : MonoBehaviour
{
    [SerializeField]
    private GameObject panel = null;
    
    public bool isClick = true;

    public void OnClick()
    {
        isClick = (isClick == true) ? false : true;
        if(!isClick)
        {
            panel.transform.DOLocalMoveY(1250f, 1f);
        }
        else
        { 
            panel.transform.DOLocalMoveY(-1250f, 1f);
        }
    }
}
