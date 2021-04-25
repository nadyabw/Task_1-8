using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Questions : MonoBehaviour
{
    #region Variables

    public List<QuestionData> questions;

    public int currentQuestionIndex = 0;

    public Button answerButton1;

    public Text questionText;
    public Text answerText_1;
    public Text answerText_2;
    public Text answerText_3;
    public Text answerText_4;

    #endregion

    #region Unity Lifecycle

    public QuestionData getNewQuetstion()
    {
        QuestionData qd = null;

        if (currentQuestionIndex < questions.Count)
        {
            qd = questions[currentQuestionIndex]; // текущий вопрос
            currentQuestionIndex++; // увеличение индекса вопроса
        }

        return qd;
    }

    #endregion
}