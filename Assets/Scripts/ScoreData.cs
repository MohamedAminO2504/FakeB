using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Score", menuName = "Quiz/Score", order = 4)]
public class ScoreData : ScriptableObject
{
    public List<OneScore> lists;

    public void addScore(int s, int sm, int nb){
        OneScore oneScore= new OneScore();
        oneScore.score=s;
        oneScore.scoreMax=sm;
        oneScore.nbAffirmationALaSuite=nb;
        oneScore.date= DateTime.Now;
        lists.Add(oneScore);

        EnsureMaxSize();
    }
    private void EnsureMaxSize()
    {
        while (lists.Count > 10)
        {
            // Find the element with the minimum score
            OneScore minScoreElement = lists[0];
            foreach (var item in lists)
            {
                if (item.score < minScoreElement.score)
                {
                    minScoreElement = item;
                }
            }
            // Remove the element with the minimum score
            lists.Remove(minScoreElement);
        }
    }
}

[System.Serializable] 
public class OneScore {
    public int score;
    public int scoreMax;
    public int nbAffirmationALaSuite;
    public DateTime date;

    public string toString(){
        string res = "";
        res += score+"/"+scoreMax+" et "+nbAffirmationALaSuite+" de reponses a la suite";
        return res;
    }

}