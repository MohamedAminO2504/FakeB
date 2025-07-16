using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CategorieManager : MonoBehaviour
{
    public GameData data;

    public Transform content;

    public GameObject prefab;

    public GameManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var item in data.categories)
        {
            if (item.active)
            {
                GameObject a = Instantiate(prefab, content);
                a.SetActive(true);
                Button b = a.GetComponentInChildren<Button>();

                b.onClick.AddListener(() => manager.jouerCategorie(item.name));

                TextMeshProUGUI texte = b.GetComponentInChildren<TextMeshProUGUI>();
                texte.text = item.name;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
