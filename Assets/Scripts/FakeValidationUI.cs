using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FakeValidationUI : MonoBehaviour 
{
    public TypeFakeData data;
    public TextMeshProUGUI libelle;
    public TextMeshProUGUI explication;
    
    public void init(TypeFakeData d){
        data = d;
        libelle.text = data.libelle;
        explication.text = data.explication;
    }

}