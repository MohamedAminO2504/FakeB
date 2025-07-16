using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TypeFakeService : MonoBehaviour
{

    public GameManager gameManager;
    public TypeFakeFacade facade;


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
