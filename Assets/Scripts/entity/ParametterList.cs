using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ParametterList
{
    public List<ParametterApi> parametters;

    public ParametterList(List<ParametterApi> parametters){
        this.parametters = parametters;
    }
}