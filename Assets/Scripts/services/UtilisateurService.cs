using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UtilisateurService : MonoBehaviour
{

    public GameManager gameManager;
    public UtilisateurFacade facade;

    public void Connexion(UtilisateurApi utilisateurApi)
    {
       StartCoroutine(facade.Post( utilisateurApi,
            onSuccess: () =>
             {
                 Debug.Log("connexion ok");
             },
             onError: error => Debug.LogError("Erreur : " + error)
         ));   
    }

    public void FindAll()
    {
        StartCoroutine(facade.Get(
             onSuccess: list =>
             {
                 GetList(list);
             },
             onError: error => Debug.LogError("Erreur : " + error)
         ));
    }


    public void GetList(List<TypeFakeApi> res)
    {
        if (res == null)
        {
            FindAll();
        }
        else
        {
            Init(res);
        }
    }

    public void Init(List<TypeFakeApi> list)
    {
      
    }

}
