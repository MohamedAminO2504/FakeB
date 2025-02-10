using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;

    public List<Question> questions;

    public List<TypeFakeData> listFakes;

    public List<Question> choisies;

    public UIManager uIManager;

    public int count;

    public string url = "www.google.fr";

    public int point;
    public int pointMax;
    public int countNbAffile;
    public int maxNbAffile;
    public TypeFake reponseCurrent;
    public GameObject tuto;

    public void jouer()
    {
        vraimentJouer();
        if (gameData.showTuto)
        {
            ShowTuto();
            gameData.showTuto = false;
        }
    }

    public void ShowTuto()
    {
        tuto.SetActive(true);
    }

    public void vraimentJouer()
    {
        count = 0;
        point = 0;
        pointMax = 0;
        maxNbAffile = 0;
        countNbAffile = 0;
        initQuestionChoisie();
        uIManager.afficheQuestion(choisies[count]);
    }

    public void ReponseFake()
    {
        uIManager.afficheTypeFake();
    }

    public void GoReponse(TypeFake typeFake)
    {
        choisies[count].active = true;
        if (choisies[count].typeFake == typeFake)
        {
            point++;
        }
        pointMax++;
        uIManager.afficheReponse(choisies[count], typeFake, getFakeData(choisies[count].typeFake));
    }

    public void GoReponseFake(TypeFake typeFake)
    {
        uIManager.afficheTypeFakeValidation(getFakeData(typeFake));
    }


    public void ReponseFact()
    {
        GoReponse(TypeFake.VIDE);
    }
    public void ValiderFake()
    {
        GoReponse(reponseCurrent);
    }
    public void rLienCausalDouteux()
    {
        reponseCurrent = TypeFake.LIEN_CAUSAL;
        GoReponseFake(TypeFake.LIEN_CAUSAL);
    }
    public void rPenteGlissante()
    {
        reponseCurrent = TypeFake.PENTE_GLISSANTE;
        GoReponseFake(TypeFake.PENTE_GLISSANTE);
    }
    public void rGeneralisationHative()
    {
        reponseCurrent = TypeFake.GENERALISATION;
        GoReponseFake(TypeFake.GENERALISATION);
    }

    public void rArgumentAutorite()
    {
        reponseCurrent = TypeFake.ARGUMENT_AUTORITER;
        GoReponseFake(TypeFake.ARGUMENT_AUTORITER);
    }

    public void rFauxDilemme()
    {
        reponseCurrent = TypeFake.FAUX_DILEMME;
        GoReponseFake(TypeFake.FAUX_DILEMME);
    }

    public void rFausseAnalogie()
    {
        reponseCurrent = TypeFake.FAUSSE_ANALOGIE;
        GoReponseFake(TypeFake.FAUSSE_ANALOGIE);
    }

    public void nextQuestion()
    {
        count++;
        Debug.Log(count+" sus "+gameData.nbQuestion);
        if (count < choisies.Count)
            uIManager.afficheQuestion(choisies[count]);
        else
            afficheScore();

        Debug.Log(point+"/"+pointMax);
    }

    public void initQuestionChoisie()
    {
        choisies.Clear();

        // Vérifier que le nombre de questions demandées ne dépasse pas le nombre de questions disponibles
        int nombreQuestionsAAjouter = Mathf.Min(gameData.nbQuestion, questions.Count);

        // Créer un HashSet pour suivre les questions déjà ajoutées
        HashSet<Question> questionsAjoutees = new HashSet<Question>();

        // Initialiser un générateur de nombres aléatoires
        System.Random rand = new System.Random();

        while (questionsAjoutees.Count < nombreQuestionsAAjouter)
        {
            // Sélectionner une question aléatoire
            int index = rand.Next(questions.Count);
            Question questionChoisie = questions[index];

            // Vérifier si la question a déjà été ajoutée
            if (!questionsAjoutees.Contains(questionChoisie))
            {
                // Ajouter la question choisie à la liste choisies et au HashSet
                choisies.Add(questionChoisie);
                questionsAjoutees.Add(questionChoisie);
            }
        }
    }

    public void openUrl()
    {
        Application.OpenURL(url);
    }

    public void changeNbQuestion(int nb)
    {
        this.gameData.nbQuestion = nb;
    }

    public void afficheScore()
    {
        uIManager.afficheScore(point, pointMax);
        foreach (var item in questions)
        {
            item.active = false;
        }
    }

    public TypeFakeData getFakeData(TypeFake f)
    {
        foreach (var item in listFakes)
        {
            if (f == item.typeFake)
            {
                return item;
            }
        }

        return null;
    }


}
