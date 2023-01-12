using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{   
    [SerializeField] float timeToSolveProlem = 30f;
    [SerializeField] float timeToShowAnswer = 10f;
    
    public float fillfraction;
    public bool loadNextQuestion;

    public bool isAnsweringQuestion;
    float timeValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timeValue = 0f;
    }

    void UpdateTimer()
    {
        timeValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(timeValue > 0)
            {
                fillfraction = timeValue / timeToSolveProlem;
            }
            else
            {
                isAnsweringQuestion = false;
                timeValue = timeToShowAnswer;
            }

        }
        else
        {
            if(timeValue > 0)
            {
                fillfraction = timeValue / timeToShowAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timeValue = timeToSolveProlem;
                loadNextQuestion = true;
            }
        }
    }
}
