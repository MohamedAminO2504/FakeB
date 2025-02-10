using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreUi;
    public TextMeshProUGUI scoreMaxUi;

    public void init(int score, int pointMax){
        scoreUi.text = score +"";
        scoreMaxUi.text = "/"+pointMax;
    }
 
}
