using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    #region Variables

    public static int correctAnswersNumber;
    public static int incorrectAnswersNumber;
    public int lifenumber = 3;
    public Questions questions;
    public Button[] answerButtons;

    public Text questionText;
    public Text lifeText;
    private int correctAnswerIndex;
    public float timeBetweenQuestion = 1.5f;
    private float timeToNewQuestion;

    private delegate void Updater();

    private Updater updater;
    private Color colorOriginal;

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        colorOriginal = answerButtons[0].image.color; // сохраниени исходного цвета кнопки
        answerButtons[0].onClick.AddListener(delegate { OnAnswerClick(0); });
        answerButtons[1].onClick.AddListener(delegate { OnAnswerClick(1); });
        answerButtons[2].onClick.AddListener(delegate { OnAnswerClick(2); });
        answerButtons[3].onClick.AddListener(delegate { OnAnswerClick(3); });

        SetupNewQuestion();

        updater = UpdateGame;
    }

    private void Update()
    {
        updater();
    }

    #endregion

    #region Private Methods

    private void SetupNewQuestion()
    {
        EnableButtons();
        QuestionData qd = questions.getNewQuetstion();
        if (qd != null & lifenumber > 0) // проверка остались ли вопросы и жизни
        {
            questionText.text = qd.question;
            answerButtons[0].GetComponentInChildren<Text>().text = qd.answer_1; //слушатели для кнопок
            answerButtons[1].GetComponentInChildren<Text>().text = qd.answer_2;
            answerButtons[2].GetComponentInChildren<Text>().text = qd.answer_3;
            answerButtons[3].GetComponentInChildren<Text>().text = qd.answer_4;
            lifeText.text = $"Количество жизней = {lifenumber}" ;

            correctAnswerIndex = qd.correctAnswerIndex - 1; // индекс кнопки с правильным ответом
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnAnswerClick(int buttonIndex)
    {
        DisableButtons();

        bool isCorrect = (buttonIndex == correctAnswerIndex); //если кнопка верная 
        if (isCorrect)
        {
            correctAnswersNumber++;
        }
        else // Если кнопка не верная
        {
            incorrectAnswersNumber++;
            lifenumber--;
        }

        ColorizeButton(buttonIndex, isCorrect); // возваращение исходного цвета кнопки

        timeToNewQuestion = timeBetweenQuestion;
        updater = UpdateTimeToNewQuestion;
    }

    private void ColorizeButton(int buttonIndex, bool isCorrect) // замена цвета кнопки
    {
        if (isCorrect)
        {
            answerButtons[buttonIndex].image.color = new Color(0, 1, 0);
        }
        else
        {
            answerButtons[buttonIndex].image.color = new Color(1, 0, 0);
        }
    }

    private void UpdateGame()
    {
    }

    private void UpdateTimeToNewQuestion()
    {
        timeToNewQuestion -= Time.deltaTime;

        if (timeToNewQuestion <= 0)
        {
            updater = UpdateGame;
            SetupNewQuestion();
        }
    }

    private void DisableButtons() // блокировка кнопок
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].enabled = false;
        }
    }

    private void EnableButtons() // разблокировка кнопок
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].enabled = true;
            answerButtons[i].image.color = colorOriginal;
        }
    }

    #endregion
}