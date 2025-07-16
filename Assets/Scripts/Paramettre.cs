using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Quiz/Paramettre", order = 1)]
public class Paramettre : ScriptableObject
{
    //Private
    public string version;
    public Environnement environnement;
    public Profil profil;

    public string slogan;

    public string urlLocal = "";
    public string urlProduction = "";

    //Public
    public int nbDeQuestion;

    public string remerciments;

    public string GetUrl()
    {
        if (environnement == Environnement.LOCAL)
        {
            return urlLocal;
        }
        return urlProduction;
    }

    public void Init(List<ParametterApi> list)
    {
        string value = getParamettreValue("version", list);
        if (value != null)
        {
            this.version = value;
        }
        value = getParamettreValue("slogan", list);
        if (value != null)
        {
            this.slogan = value;
        }

        value = getParamettreValue("remerciements", list);
        if (value != null)
        {
            this.remerciments = value;
        }
    }

    public string getParamettreValue(string id, List<ParametterApi> list)
    {
        foreach (var item in list)
        {
            if (item.id == id)
            {
                if (item.active)
                {
                    return item.value;
                }
                else
                {
                    return null;
                }
            }
        }
        return null;
    }
    
}


public enum Environnement{
    LOCAL, PRODUCTION
}

public enum Profil{
    USER, ADMIN
}