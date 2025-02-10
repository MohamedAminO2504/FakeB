using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Quiz/Question", order = 0)]
public class Question : ScriptableObject
{    
    public TypeFake typeFake;

    [TextAreaAttribute]
    public string libelle;
    public string auteur;

    [TextAreaAttribute]
    public string explication;

    public bool active; 

}

[System.Serializable] 
public class Reponse{
    public string id;
    public string libelle;
    public int point;
}

public enum TypeFake{
    VIDE, LIEN_CAUSAL, PENTE_GLISSANTE, GENERALISATION, ARGUMENT_AUTORITER, FAUX_DILEMME, FAUSSE_ANALOGIE
}