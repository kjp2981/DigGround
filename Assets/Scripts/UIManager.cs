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
        UpdateExpPanel();
    }
    public void UpdateExpPanel()
    {
        expText.text = string.Format("{0} EXP", GameManager.Instance.CurrentUser.exp);
    }
}
