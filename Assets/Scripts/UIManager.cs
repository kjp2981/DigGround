using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text expText = null;
    [SerializeField]
    private Animator swordAnimator = null;
    [SerializeField]
    private UpgradePanel upgradePanelTemplate = null;
    [SerializeField]
    private GameObject amountText = null;

    private List<UpgradePanel> upgradePanelsList = new List<UpgradePanel>();

    void Start()
    {
        UpdateExpPanel();
        CreatePanels();
    }

    
    public void CreatePanels()
    {
        GameObject panel = null;
        UpgradePanel panelComponent = null;

        foreach(Place place in GameManager.Instance.CurrentUser.placeList)
        {
            panel = Instantiate(upgradePanelTemplate.gameObject, upgradePanelTemplate.transform.parent);
            panelComponent = panel.GetComponent<UpgradePanel>();
            panelComponent.SetValue(place);
            panel.SetActive(true);
            upgradePanelsList.Add(panelComponent);
        }
    }

    public void OnClickerSword()
    {
        GameManager.Instance.CurrentUser.exp++;
        swordAnimator.Play("Click");
        //Pooling();
        UpdateExpPanel();
    }
    public void UpdateExpPanel()
    {
        expText.text = string.Format("{0} EXP", GameManager.Instance.CurrentUser.exp);
    }

    //private GameObject Pooling()
    //{
    //    GameObject result = null;
    //    if (GameManager.Instance.poolManager.transform.childCount < 1)
    //    {
    //        result = Instantiate(amountText, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    //        result.transform.SetParent(GameObject.Find("Canvas").transform, false);
    //        result.SetActive(true);
    //    }
    //    else
    //    {
    //        result = GameManager.Instance.poolManager.transform.GetChild(0).gameObject;
    //        result.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        result.transform.SetParent(GameObject.Find("Canvas").transform, false);
    //        result.SetActive(true);
    //    }
    //    return result;
    //}
}
