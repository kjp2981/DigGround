using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text ironText = null;
    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private UpgradePanel upgradePanelTemplate = null;
    [SerializeField]
    private EnergyText energyTextTemplate = null;
    [SerializeField]
    private ParticleCallBack particle = null;

    private List<UpgradePanel> upgradePanelsList = new List<UpgradePanel>();

    private CameraShake cameraShake = null;
    void Start()
    {
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
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

    public void OnClickerIron()
    {
        GameManager.Instance.CurrentUser.iron += (long)(GameManager.Instance.CurrentUser.clickiron);
        animator.Play("Click");
        ParticlePool();
        StartCoroutine(cameraShake.Shake(0.05f, 0.1f));

        EnergyText newText = null;
        if(GameManager.Instance.Pool.childCount > 0)
        {
            newText = GameManager.Instance.Pool.GetChild(0).GetComponent<EnergyText>();
            newText.transform.SetParent(GameManager.Instance.Pool.parent);
        }
        else
        {
            newText = Instantiate(energyTextTemplate, GameManager.Instance.Pool.parent).GetComponent<EnergyText>(); 
        }
        newText.gameObject.SetActive(true);
        newText.Show((long)(GameManager.Instance.CurrentUser.clickiron));
        UpdateExpPanel();
    }
    public void UpdateExpPanel()
    {
        ironText.text = string.Format("{0} IRON", GameManager.Instance.CurrentUser.iron);
    }

    private void ParticlePool()
    {
        ParticleCallBack newObject = null;
        if (GameManager.Instance.Particle.childCount > 0)
        {
            newObject = GameManager.Instance.Particle.GetChild(0).GetComponent<ParticleCallBack>();
            newObject.transform.SetParent(GameManager.Instance.Pool.parent);
        }
        else
        {
            newObject = Instantiate(particle, GameManager.Instance.Particle.parent).GetComponent<ParticleCallBack>();
        }
        newObject.gameObject.SetActive(true);
    }
}
