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
            return (long)(1f > Math.Ceiling(TotalMoney * 0.05f) ? 1f : Math.Ceiling(TotalMoney * 0.05f));
        }
    }
    public List<Place> placeList = new List<Place>();

    public float TotalMoney
    {
        get
        {
            float result = 0f;
            foreach(Place place in placeList)
            {
                result += place.ePs;
            }
            return result;
        }
    }
}
