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
    private Sprite[] placeSprite = null;

    private Place place = null;
    public void UpdateUI()
    {
        placeImage.sprite = placeSprite[place.placeNumber];
        placeNameText.text = place.name;
        priceText.text = string.Format("{0}", place.price);
        amountText.text = string.Format("{0}", place.amount);
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
}
