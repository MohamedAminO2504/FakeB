using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ParametterService : MonoBehaviour
{

    public GameManager gameManager;
    public ParametterFacade facade;

    public Paramettre parametter;
    public ParametterUI paramettreUI;
    public QuestionService questionService;

    public CategorieService categorieService;

   public void Start()
    {

        FindAll();

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


    public void GetList(List<ParametterApi> res)
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

    public void Init(List<ParametterApi> list)
    {


        if (parametter.version != parametter.getParamettreValue("version", list))
        {

            parametter.version = parametter.getParamettreValue("version", list);

            questionService.GetQuestionsList(null);
                        categorieService.GetList(null);


        }
        else
        {
            return;
        }
        parametter.Init(list);
        //paramettreUI.Init();    
        
    }


}
