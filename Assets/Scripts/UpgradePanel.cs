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

    private Place place = null;

    public void SetValue(Place place)
    {
        placeNameText.text = place.name;
        priceText.text = string.Format("{0} EXP", place.price);
        amountText.text = string.Format("{0}", place.amount);
        this.place = place;
    }
    
    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.exp < place.price) return;
        GameManager.Instance.CurrentUser.exp -= place.price;
        Place placeInList = GameManager.Instance.CurrentUser.placeList.Find((x) => x == place);
        placeInList.amount++;
        place.price = (long)(Mathf.Pow(place.amount,2)+place.price*1.3);
        amountText.text = string.Format("{0}", placeInList.amount);
        priceText.text = string.Format("{0} EXP", placeInList.price);
        GameManager.Instance.uiManager.UpdateExpPanel();
    }
}
