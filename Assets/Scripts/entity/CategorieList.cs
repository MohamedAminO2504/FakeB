using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CategorieList
{
    public List<CategorieApi> categories;

    public CategorieList(List<CategorieApi> categories)
    {
        this.categories = categories;
    }
}
