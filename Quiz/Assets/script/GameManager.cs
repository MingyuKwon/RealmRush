using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    Quiz quiz;
    resultCanvas result;

    void Start()
    {
        quiz = FindObjectOfType<Quiz>();
        result = FindObjectOfType<resultCanvas>();

        quiz.gameObject.SetActive(true);
        result.gameObject.SetActive(false);

    }

    void Update()
    {
        if(quiz.isQuizCompleted)
        {
            quiz.gameObject.SetActive(false);
            result.gameObject.SetActive(true);
            result.ShowFinalScore();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
