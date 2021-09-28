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
    private Text mPsText = null;
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
    [SerializeField]
    private GameObject quitButton = null;
    [SerializeField]
    private GameObject twoFloor = null;
    [SerializeField]
    private GameObject threeFloor = null;

    private List<UpgradePanel> upgradePanelsList = new List<UpgradePanel>();

    private CameraShake cameraShake = null;
    private PanelMove panelMove = null;
    private SoilMove soilMove = null;

    private AudioSource audioSource = null;
    private void Start()
    {
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        audioSource = GameObject.Find("Char").GetComponent<AudioSource>();
        soilMove = GameObject.Find("Background_1 (1)").GetComponent<SoilMove>();
        panelMove = GetComponent<PanelMove>();
        twoFloor.SetActive(false);
        threeFloor.SetActive(false);
        UpdateMoneyPanel();
        CreatePanels();
        StartCoroutine(CartCreate());
    }

    private void Update()
    {
        CreateNewFloor();
    }

    private void CreateNewFloor()
    {
        if (GameManager.Instance.CurrentUser.clickMoney >= 5)
            twoFloor.SetActive(true);
        if (GameManager.Instance.CurrentUser.clickMoney >= 15)
            threeFloor.SetActive(true);
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
        soilMove.Move();
        audioSource.Play();
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
        mPsText.text = string.Format("{0} exp/s", GameManager.Instance.CurrentUser.TotalExp);
    }

    private void ParticlePool()
    {
        if (panelMove.isClick == false) return;
        ParticleCallBack newObject = null;
        if (GameManager.Instance.Particle.childCount > 0)
        {
            newObject = GameManager.Instance.Particle.GetChild(0).GetComponent<ParticleCallBack>();
            newObject.transform.SetParent(GameManager.Instance.Pool.parent);
            newObject.transform.SetSiblingIndex(3);
        }
        else
        {
            newObject = Instantiate(particle, GameManager.Instance.Particle.parent).GetComponent<ParticleCallBack>();
            newObject.transform.SetSiblingIndex(3);
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
            RandomDelay = Random.Range(20, 30f);
            if (GameManager.Instance.CartPool.childCount > 0)
            {
                newCart = GameManager.Instance.CartPool.GetChild(0).gameObject.AddComponent<CartMove>();
                newCart.transform.SetParent(GameManager.Instance.CartPool.parent);
                int index = quitButton.transform.GetSiblingIndex();
                newCart.transform.SetSiblingIndex(index - 1);
            }
            else
            {
                newCart = Instantiate(cart, GameManager.Instance.CartPool.parent).GetComponent<CartMove>();
                int index = quitButton.transform.GetSiblingIndex();
                newCart.transform.SetSiblingIndex(index - 1);
            }
            newCart.gameObject.SetActive(true);
            yield return new WaitForSeconds(RandomDelay);
            InfiniteLoopDetector.Run();
        }
    }
}
