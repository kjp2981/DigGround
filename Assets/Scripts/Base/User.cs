using System.Collections.Generic;

[System.Serializable]
public class User
{
    public string nickname;
    public long exp;
    public int clickExp;
    public List<Place> placeList = new List<Place>();
}
