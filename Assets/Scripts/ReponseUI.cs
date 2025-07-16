using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReponseUI : MonoBehaviour
{
    public Question question;
    public TextMeshProUGUI idReponse;
    public TextMeshProUGUI reponse;
    public TextMeshProUGUI explication;
    public TextMeshProUGUI top;

    
    public void init(Question q, TypeFake r, TypeFakeData tfd){
        if(q == null)
            return ;


        question = q;
        if(q.typeFake == r){
            top.text = "BRAVO";
            if(tfd != null){
                reponse.text = "c'était bien un fake de type "+tfd.libelle;

            }else{
                reponse.text = "c'était bien une fact";  
            }
            explication.text = q.explication;
        }else{
            top.text = "Mauvaise réponse";
            
            if(tfd != null){
                reponse.text = "c'était un fake de type : "+tfd.libelle;

            }else{
                reponse.text = "c'était une fact";  
            }
            explication.text = q.explication;
        }
    }
}
