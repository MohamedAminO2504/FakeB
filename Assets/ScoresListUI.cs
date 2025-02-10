using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoresListUI : MonoBehaviour
{
    public List<TextMeshProUGUI> lists;
    public ScoreData data;

    public void init()
    {
        int i = 0;
        data.lists.Sort((a, b) => tri(a, b));

        foreach (var item in lists)
        {

            if (i < data.lists.Count)
                item.text = data.lists[i].toString();
            else
                item.text = "vide";
            i++;
        }
    }

    public int tri(OneScore a, OneScore b)
    {
        int compareScore = b.score.CompareTo(a.score);
        int compareAffile = b.nbAffirmationALaSuite.CompareTo(a.nbAffirmationALaSuite);

        if (compareScore != 0)
            return compareScore;

        return compareAffile;
    }
}
