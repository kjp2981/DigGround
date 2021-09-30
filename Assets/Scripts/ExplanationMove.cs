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
        StartCoroutine(Move());
    }

    private void Update()
    {

    }

    private IEnumerator Move()
    {
        while (true)
        {
            rectTransform.DOMoveX(-8, 6f);
            yield return new WaitForSeconds(6f);
            rectTransform.anchoredPosition = new Vector2(1800, 925);
            yield return new WaitForSeconds(10f);
            InfiniteLoopDetector.Run();
        }
    }
}