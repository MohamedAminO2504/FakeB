using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuestionService : MonoBehaviour
{

    public GameManager gameManager;
    public QuestionFacade questionFacade;


    public void Start(){
        if(gameManager.gameData.paramettre.profil == Profil.ADMIN){
            FindQuestions();
        }
    }

    public void FindQuestions()
    {
        StartCoroutine(questionFacade.Get(
             onSuccess: questions =>
             {
                GetQuestionsList(questions);
             },
             onError: error => Debug.LogError("Erreur : " + error)
         ));
    }


    public void GetQuestionsList(List<QuestionApi> res)
    {
        if (res == null)
        {
            FindQuestions();
        }
        else
        {
            InitQuestions(res);
        }
    }

    public void InitQuestions(List<QuestionApi> questionList)
    {
        GameData data = gameManager.gameData;

        foreach (var fake in data.questions)
        {
            fake.active = false;
            fake.id = 0;
            fake.libelle = "";
            fake.explication = "";
            fake.theme = null;
        }

        for (int i = 0; i < questionList.Count; i++)
        {
            QuestionApi qApi = questionList[i];
            Question fake = data.getFakeById(qApi.id);
            fake.id = qApi.id;
            fake.libelle = qApi.libelle;
            fake.explication = qApi.explication;
            fake.active = qApi.active;
            fake.typeFake = (TypeFake)Enum.Parse(typeof(TypeFake), qApi.typeFake);

        }

    }

}
