using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text moneyText = null;
    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private UpgradePanel upgradePanelTemplate = null;
    [SerializeField]
    private EnergyText energyTextTemplate = null;
    [SerializeField]
    private ParticleCallBack particle = null;
    [SerializeField]
    private CartMove cart = null;

    private List<UpgradePanel> upgradePanelsList = new List<UpgradePanel>();

    private CameraShake cameraShake = null;

    private PanelMove panelMove = null;
    void Start()
    {
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        panelMove = GetComponent<PanelMove>();
        UpdateMoneyPanel();
        CreatePanels();
        StartCoroutine(CartCreate());
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

    public void OnCick()
    {
        GameManager.Instance.CurrentUser.money += (long)(GameManager.Instance.CurrentUser.clickMoney);
        animator.Play("Click");
        ParticlePool();
        StartCoroutine(cameraShake.Shake(0.05f, 0.1f));
        textPool((long)(GameManager.Instance.CurrentUser.clickMoney));
    }

    public void textPool(long number)
    {
        EnergyText newText = null;
        if (GameManager.Instance.Pool.childCount > 0)
        {
            newText = GameManager.Instance.Pool.GetChild(0).GetComponent<EnergyText>();
            newText.transform.SetParent(GameManager.Instance.Pool.parent);
        }
        else
        {
            newText = Instantiate(energyTextTemplate, GameManager.Instance.Pool.parent).GetComponent<EnergyText>();
        }
        newText.gameObject.SetActive(true);
        newText.Show((long)(number));
        UpdateMoneyPanel();
    }
    public void UpdateMoneyPanel()
    {
        moneyText.text = string.Format("{0} MONEY", GameManager.Instance.CurrentUser.money);
        moneyText.transform.DOScale(1.2f, 0.1f).OnComplete(() => moneyText.transform.DOScale(1f, 0.1f));
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

    private IEnumerator CartCreate()
    {
        CartMove newCart = null;
        float RandomDelay = 0f;
        yield return new WaitForSeconds(20f);
        while(true)
        {
            if (panelMove.isClick == false) continue;
            RandomDelay = Random.Range(10f, 20f);
            if (GameManager.Instance.CartPool.childCount > 0)
            {
                newCart = GameManager.Instance.CartPool.GetChild(0).GetComponent<CartMove>();
                newCart.transform.SetParent(GameManager.Instance.CartPool.parent);
            }
            else
            {
                newCart = Instantiate(cart, GameManager.Instance.CartPool.parent).GetComponent<CartMove>();
            }
            newCart.gameObject.SetActive(true);
            yield return new WaitForSeconds(RandomDelay);
        }
    }
}
