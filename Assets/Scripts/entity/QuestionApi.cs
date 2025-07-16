using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

[System.Serializable]
public class QuestionApi
{
    public int id;
    public string typeFake;
    public string libelle;
    public string explication;
    public bool active;
    public string categorie;
}