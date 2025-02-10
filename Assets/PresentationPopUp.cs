using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PresentationPopUp : MonoBehaviour
{
    [TextAreaAttribute]
    public List<string> texts;
    public int indexTexts = 0;
    public TextMeshProUGUI zoneText;

    private void Start()
    {
        zoneText.text = texts[0];
        indexTexts++;
    }

    public void Click()
    {
        zoneText.text = texts[indexTexts];
        indexTexts++;
        if (indexTexts >= texts.Count)
        {
            indexTexts = 0;
            zoneText.text = texts[indexTexts];
            this.gameObject.SetActive(false);
        }
    }

}
