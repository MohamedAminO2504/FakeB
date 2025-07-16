using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI version;

    public QuestionUI questionUI;
    public ReponseUI reponseUI;
    public FakeValidationUI fvUI;

    public ScoreUI scoreUI;
    public ScoresListUI listscores;
    public RecapManager recapManager;

    public GameObject question;
    public GameObject reponse;
    public GameObject acceuil;
    public GameObject paramettre;
    public GameObject typeFake;

    public GameObject typeFakeValidation;

    public GameObject score;
        public GameObject scoreList;

    public GameObject recap;

    public void Start(){
        version.text = "version "+Application.version;
    }

    public void toutMasquer(){
        question.SetActive(false);
        reponse.SetActive(false);
        acceuil.SetActive(false);
        paramettre.SetActive(false);
        score.SetActive(false);
        typeFake.SetActive(false);
        typeFakeValidation.SetActive(false);
        recap.SetActive(false);
    }

    public void afficheTypeFakeValidation(TypeFakeData typeFakeData){
        toutMasquer();
        typeFakeValidation.SetActive(true);
        fvUI.init(typeFakeData);    
    }

    public void afficheQuestion(Question q){
        q.active = true;
        questionUI.data = q;
        reponseUI.question = q;
        toutMasquer();
        question.SetActive(true);
        questionUI.init();
    }

     public void afficheReponse(Question q, TypeFake r, TypeFakeData tfd){
         toutMasquer();
        reponse.SetActive(true);
        reponseUI.init(q, r, tfd);
    }

    public void afficheTypeFakeValidation(){
         toutMasquer();
        typeFakeValidation.SetActive(true);
    }

    public void afficheAcceuil(){
        toutMasquer();
        acceuil.SetActive(true);

    }

    public void afficheRecap(){
        toutMasquer();
        recap.SetActive(true);
        recapManager.Init();    
    }
    
    public void afficheTypeFake(){
        toutMasquer();
        typeFake.SetActive(true);

    }
    
    public void afficheScores(){
         toutMasquer();
        scoreList.SetActive(true);
        listscores.init();
    }

    public void affichePramettre(){
        toutMasquer();
        paramettre.SetActive(true);
 

    }

    public void afficheScore(int nb, int nbMax){
        toutMasquer();
        score.SetActive(true);

        scoreUI.init(nb,nbMax);
    }
}
