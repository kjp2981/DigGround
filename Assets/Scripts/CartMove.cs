using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CartMove : MonoBehaviour
{
    [SerializeField]
    private Transform cartPool = null;
    void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        transform.DOMoveX(-1.5f, 2);
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
        result = result * 3;
        GameManager.Instance.CurrentUser.money += result;
        GameManager.Instance.uiManager.textPool(result);
        GameManager.Instance.uiManager.UpdateMoneyPanel();
        gameObject.SetActive(false);
        transform.SetParent(cartPool.transform, false);
    }
}
