using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParametterUI : MonoBehaviour
{
    public Paramettre paramettre;
    public TextMeshProUGUI slogan;

        public TextMeshProUGUI remerciements;


    public void Start()
    {
        Init();
    }

    public void Init()
    {
        slogan.text = paramettre.slogan;
        remerciements.text = paramettre.remerciments;
    }


}
