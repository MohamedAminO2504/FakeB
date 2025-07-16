using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RecapDetailUI : MonoBehaviour
{

    public TextMeshProUGUI zoneEntete;

    public TextMeshProUGUI zoneText;

    public TextMeshProUGUI zoneQuestion;

    public GameData data;

    public void init(Question q)
    {
        string a = q.typeFake + "";
        if (a == "FACT")
        {
            zoneEntete.text = "FACT";
        }
        else
        {
            zoneEntete.text = getLibelleType(q.typeFake);
        }
        zoneText.text = q.explication;
        zoneQuestion.text = q.libelle;
    }

    public string getLibelleType(TypeFake typeFake){
        foreach (var item in data.typesFake)
        {
            if(item.typeFake == typeFake){
                return item.libelle;
            }   
        }
        return "";  
    }

}
