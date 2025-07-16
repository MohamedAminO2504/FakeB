using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoDebutManager : MonoBehaviour
{

    public List<GameObject> objectsToShow; // Liste des GameObject à afficher
    public GameObject finalObject;  
    public float timer = 2.0f;

    void Start()
    {
                    finalObject.SetActive(true);

        StartCoroutine(ShowObjectsInSequence());
    }

    IEnumerator ShowObjectsInSequence()
    {
        for (int i = 0; i < objectsToShow.Count; i++)
        {
            // Activer le GameObject courant
            objectsToShow[i].SetActive(true);

            // Désactiver le précédent s'il existe
            if (i > 0)
            {
                objectsToShow[i - 1].SetActive(false);
            }

            // Attendre 2 secondes
            yield return new WaitForSeconds(timer);
        }

        // Désactiver le dernier affiché
        if (objectsToShow.Count > 0)
        {
            objectsToShow[objectsToShow.Count - 1].SetActive(false);
        }

        // Désactiver l'objet final
        if (finalObject != null)
        {
            finalObject.SetActive(false);
        }
    }
}
