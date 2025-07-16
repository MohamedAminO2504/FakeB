using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TypeFakeData", menuName = "Quiz/TypeFake", order = 0)]
public class TypeFakeData : ScriptableObject
{
    public string libelle;

    [TextAreaAttribute]
    public string explication;

    public TypeFake typeFake;

    public TypeFakeApi toApi(){
        TypeFakeApi res = new TypeFakeApi();
        res.id = typeFake+"";
        res.libelle = libelle;
        res.explication = explication;
        return res;
    }
}