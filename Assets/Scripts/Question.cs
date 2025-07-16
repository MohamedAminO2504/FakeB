using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Quiz/Question", order = 0)]
public class Question : ScriptableObject
{    
    public TypeFake typeFake;

    public int id;

    public Theme theme;
    public Difficulte difficulte;

    [TextAreaAttribute]
    public string libelle;
    public string auteur;

    [TextAreaAttribute]
    public string explication;

    public bool active; 

    public QuestionApi toQuestionApi(){
        QuestionApi q = new QuestionApi();
        q.typeFake = typeFake+"";
        q.libelle = libelle;
        q.explication = explication;
        q.active = active;
        return q;
    }

}

[System.Serializable] 
public class Reponse{
    public string id;
    public string libelle;
    public int point;
}

public enum TypeFake{
    FACT, LIEN_CAUSAL, PENTE_GLISSANTE, GENERALISATION, ARGUMENT_AUTORITER, FAUX_DILEMME, FAUSSE_ANALOGIE
}

public enum Difficulte{
    FACILE, MOYEN, DIFFICILE
}