using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TypeFakeList
{
    public List<TypeFakeApi> typeFakes;

    public TypeFakeList(List<TypeFakeApi> typefakes){
        this.typeFakes = typefakes;
    }
}