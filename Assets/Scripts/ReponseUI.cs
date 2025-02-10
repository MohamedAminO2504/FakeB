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
        if(q == null || r == null)
            return ;


        question = q;
        if(q.typeFake == r){
            top.text = "BRAVO";
            if(tfd != null){
                reponse.text = "c'etait bien une "+tfd.libelle;

            }else{
                reponse.text = "c'etait bien une fact";  
            }
            explication.text = q.explication;
        }else{
            top.text = "RATE";
            
            if(tfd != null){
                reponse.text = "c'etait une "+tfd.libelle;

            }else{
                reponse.text = "c'etait une fact";  
            }
            explication.text = q.explication;
        }
    }
}
