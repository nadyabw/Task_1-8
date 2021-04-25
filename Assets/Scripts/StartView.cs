using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartView : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(StartClickHandler);
       
    }

    private void StartClickHandler()
    {
        SceneManager.LoadScene(1);
    }
}
   
