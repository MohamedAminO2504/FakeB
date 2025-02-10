using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionUI : MonoBehaviour
{
    public Question data;
    public TextMeshProUGUI question;
    public TextMeshProUGUI auteur;
    

    public void init(){
        question.text = data.libelle;
        auteur.text = data.auteur;
    }

    private void Start() {
        init();
    }
}