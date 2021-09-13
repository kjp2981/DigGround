using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Amount : MonoBehaviour
{
    private Text text = null;

    void Start()
    {
        text = GetComponent<Text>();

        transform.DOMove(new Vector2(0, transform.position.y + 2), 1);
        text.DOColor(Color.clear, 1);
        //StartCoroutine(Active());
        gameObject.transform.SetParent(GameManager.Instance.poolManager.transform, false);
        gameObject.SetActive(false);
    }

    private IEnumerator Active()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.SetParent(GameManager.Instance.poolManager.transform, false);
        gameObject.SetActive(false);
    }
}
