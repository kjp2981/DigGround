using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    private Image placeImage = null;
    [SerializeField]
    private Text placeNameText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Text amountText = null;
    [SerializeField]
    private Button purchaseButton = null;
    [SerializeField]
    private Text purchaseButtonText = null;
    [SerializeField]
    private Sprite[] placeSprite = null;
    [SerializeField]
    private Text ePsText = null;

    private Place place = null;

    private Image panelImage = null;

    private void Start()
    {
        panelImage = GetComponent<Image>();
    }
    private void Update()
    {
        Effect();
    }
    public void UpdateUI()
    {
        placeImage.sprite = placeSprite[place.placeNumber];
        placeNameText.text = place.name;
        priceText.text = string.Format("{0}", place.price);
        amountText.text = string.Format("{0}", place.amount);
        ePsText.text = string.Format("{0}/s", place.ePs/* * place.amount*/);
    }
    public void SetValue(Place place)
    {
        this.place = place;
        UpdateUI();
    }
    
    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.money < place.price) return;
        GameManager.Instance.CurrentUser.money -= place.price;
        Place placeInList = GameManager.Instance.CurrentUser.placeList.Find((x) => x == place);
        placeInList.amount++;
        place.price = (long)(Mathf.Pow(place.amount,2)+place.price*1.3);
        UpdateUI();
        GameManager.Instance.uiManager.UpdateMoneyPanel();
    }

    private void Effect()
    {
        if (GameManager.Instance.CurrentUser.money < place.price)
        {
            placeImage.color = new Color(.5f, .5f, .5f, 1);
            placeNameText.color = new Color(.5f, .25f, 0f, 1);
            priceText.color = new Color(.5f, .5f, 0.5f, 1);
            amountText.color = new Color(.5f, .5f, .5f, 1);
            panelImage.color = new Color(.5f, .5f, .5f, 1);
            purchaseButton.GetComponent<Image>().color = new Color(.5f, .5f, .5f, 1);
            purchaseButtonText.color = new Color(.5f, .5f, .5f, 1);
            ePsText.color = new Color(.5f, .5f, .5f, 1);
        }
        else
        {
            placeImage.color = new Color(1, 1, 1, 1);
            placeNameText.color = new Color(1, .5f, 0, 1);
            priceText.color = new Color(1, 1, 1, 1);
            amountText.color = new Color(1, 1, 1, 1);
            panelImage.color = new Color(1, 1, 1, 1);
            purchaseButton.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            purchaseButtonText.color = new Color(1, 1, 1, 1);
            ePsText.color = new Color(1, 1, 1, 1);
        }
    }
}
