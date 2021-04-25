using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameResults : MonoBehaviour
{
    #region Variables

    public Text correctAnswersNumber;
    public Text incorrectAnswersNumber;
    public Button newGame;

    #endregion


    #region Unity Lifecycle

    void Start()
    {
        newGame.onClick.AddListener(NewGameClickHandler);
        correctAnswersNumber.text = $"Правильных ответов : {Game.correctAnswersNumber}";
        incorrectAnswersNumber.text = $"Неправильных ответов : {Game.incorrectAnswersNumber}";
    }
    

    #endregion

    #region Private Methods

    private void NewGameClickHandler()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}