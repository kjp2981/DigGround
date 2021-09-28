using System;
using System.Collections.Generic;

[System.Serializable]
public class User
{
    public string nickname;
    public long money;
    public float clickMoney
    {
        get
        {
            long result = (long)(1f > Math.Round(Math.Pow(TotalAmount, 0.5f) - 1) ? 1f : Math.Round(Math.Pow(TotalAmount, 0.5f) - 1));
            if (TotalAmount == 0)
                return 1;
            else
                return result * 2;
        }
    }
    public List<Place> placeList = new List<Place>();

    public float TotalAmount
    {
        get
        {
            float result = 0f;
            foreach(Place place in placeList)
            {
                result += place.amount;
            }
            return result;
        }
    }

    public float TotalExp
    {
        get
        {
            float result = 0f;
            foreach(Place place in placeList)
            {
                result += (place.ePs * place.amount);
            }
            return result;
        }
    }
}
