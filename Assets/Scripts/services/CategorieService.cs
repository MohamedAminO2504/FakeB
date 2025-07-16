using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CategorieService : MonoBehaviour
{

    public GameManager gameManager;
    public CategorieFacade facade;


    public void Start(){
        if(gameManager.gameData.paramettre.profil == Profil.ADMIN){
            Finds();
        }
    }

    public void Finds()
    {
        StartCoroutine(facade.Get(
             onSuccess: l =>
             {
                GetList(l);
             },
             onError: error => Debug.LogError("Erreur : " + error)
         ));
    }


    public void GetList(List<CategorieApi> res)
    {
        if (res == null)
        {
            Finds();
        }
        else
        {
            Init(res);
        }
    }

    public void Init(List<CategorieApi> l)
    {
        GameData data = gameManager.gameData;
        Debug.Log("il y'a " + l.Count + " cat");
               foreach (var cat in data.categories)
        {
            cat.active = false;
            cat.name = "";
        }

        for (int i = 0; i < l.Count; i++)
        {
            CategorieApi capi = l[i];
            CategorieData d = data.GetCategorieLibre();
            d.active = capi.active;
            d.name = capi.libelle;
            Debug.Log("add 1 " + i);
        }

    }

}
