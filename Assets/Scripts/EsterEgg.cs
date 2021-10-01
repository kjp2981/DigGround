using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsterEgg : MonoBehaviour
{
    [SerializeField]
    private GameObject coin = null;
    void Start()
    {
        coin.SetActive(false);
        EE();
    }
    private void EE()
    {
        if(GameManager.Instance.CurrentUser.TotalExp == 500)
        {
            coin.SetActive(true);
        }
    }
}
