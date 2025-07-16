using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class QuestionList
{
    public List<QuestionApi> questions;

    public QuestionList(List<QuestionApi> questions){
        this.questions = questions;
    }
}