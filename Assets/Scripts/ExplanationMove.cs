using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ExplanationMove : MonoBehaviour
{
    private RectTransform rectTransform = null;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        //Move();
    }

    private void Update()
    {
        Move();
    }

    private IEnumerator Move()
    {
        rectTransform.DOMoveX(-8, 5f);
        yield return new WaitForSeconds(5f);
        rectTransform.anchoredPosition = new Vector2(1484, 925);
    }
}