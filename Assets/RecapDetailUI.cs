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


    public void init(Question q)
    {
        string a = q.typeFake + "";
        if (a == "VIDE")
        {
            zoneEntete.text = "FACT";
        }
        else
        {
            zoneEntete.text = q.typeFake + "";
        }
        zoneText.text = q.explication;
        zoneQuestion.text = q.libelle;
    }

}
