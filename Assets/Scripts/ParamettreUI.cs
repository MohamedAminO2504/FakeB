using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ParamettreUI : MonoBehaviour
{
    public GameData data;
    public TMP_InputField nbTour;

    private void Start() {
        nbTour.text = data.nbQuestion+"";    
    }

    public void majNbTour(string nb){
        data.nbQuestion = int.Parse(nbTour.text);
    }
 
}
