using System;
using System.Collections.Generic;

[System.Serializable]
public class User
{
    public string nickname;
    public long iron;
    public float clickiron
    {
        get
        {
            return (long)(1f > Math.Ceiling(TotalIron * 0.05f) ? 1f : Math.Ceiling(TotalIron * 0.05f));
        }
    }
    public List<Place> placeList = new List<Place>();

    public float TotalIron
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
