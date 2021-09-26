using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextEffect : MonoBehaviour
{
    private Image image = null;
    void Start()
    {
        image = GetComponent<Image>();

        StartCoroutine(Effect());
    }

    private IEnumerator Effect()
    {
        while(true)
        {
            image.DOColor(new Color(1, 1, 1, 1), 1.5f);
            yield return new WaitForSeconds(1.5f);
            image.DOColor(new Color(1, 1, 1, 0), 1.5f);
            yield return new WaitForSeconds(1.5f);
            InfiniteLoopDetector.Run();
        }
    }
}
