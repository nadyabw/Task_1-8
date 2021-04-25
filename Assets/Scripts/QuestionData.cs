using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Question Data", order = 51)]
public class QuestionData : ScriptableObject
{
    [SerializeField] public string question;
    [SerializeField] public string answer_1;
    [SerializeField] public string answer_2;
    [SerializeField] public string answer_3;
    [SerializeField] public string answer_4;
    public int correctAnswerIndex;
    
}