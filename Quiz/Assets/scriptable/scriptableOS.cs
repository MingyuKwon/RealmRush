using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[CreateAssetMenu(menuName = "Quiz question", fileName ="question")]
public class scriptableOS : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter the question here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int ansIndex = 3;

    public string GetQuestion()
    {
        return question;
    } 

    public int GetCorrectAnswerIndex()
    {
        return ansIndex;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }
}
