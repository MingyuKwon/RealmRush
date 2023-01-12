using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class resultCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI congratulation;
    ScoreKeeper scoreKeeper;

    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        
    }

    public void ShowFinalScore()
    {
        congratulation.text = "Congratulation!\n Your Score is : " +  
                                scoreKeeper.CalculateScore() + "%";
    }

    
}
