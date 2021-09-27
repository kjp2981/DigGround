using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CartMove : MonoBehaviour
{
    [SerializeField]
    private Transform cartPool = null;
    [SerializeField]
    private RectTransform cartPosition = null;

    private RectTransform rectTransform = null;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        cartPosition = GameObject.Find("CartPosition").GetComponent<RectTransform>();
        rectTransform.position = cartPosition.position;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        transform.DOMoveX(-1f, 2);
        yield return new WaitForSeconds(5f);
        transform.DOMoveX(-3.5f, 2);
        yield return new WaitForSeconds(2f);
        transform.SetParent(GameManager.Instance.CartPool);
        gameObject.SetActive(false);
    }

    public void CartClick()
    {
        long result = 0;
        foreach (Place place in GameManager.Instance.CurrentUser.placeList)
        {
            result += (place.ePs * place.amount);
        }
        result *= 3;
        if (result == 0)
            result += 3;
        GameManager.Instance.CurrentUser.money += result;
        GameManager.Instance.uiManager.textPool(result);
        GameManager.Instance.uiManager.UpdateMoneyPanel();
        rectTransform.position = cartPosition.position;
        gameObject.SetActive(false);
        transform.SetParent(cartPool.transform, false);
    }
}
