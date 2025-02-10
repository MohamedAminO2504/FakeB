using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Quiz/Data", order = 2)]
public class GameData : ScriptableObject
{
   public int nbQuestion;
   public bool showTuto;
}
