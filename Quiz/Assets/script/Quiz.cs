using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<scriptableOS> questions = new List<scriptableOS>();
    scriptableOS currentQuestion;

    [Header("Answer")]
    [SerializeField] GameObject[] answerButtons;
    int correctIndex;
    bool hasAnswerEarly;

    [SerializeField] public bool isQuizCompleted;

    [Header("Button Sprite Image")]
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite changedSprite;


    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scorekeeper;

    [Header("Slider")]
    [SerializeField] Slider slider;    
    

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scorekeeper = FindObjectOfType<ScoreKeeper>();
        slider.maxValue = questions.Count;
        
    }

    void Update() {
        timerImage.fillAmount =  timer.fillfraction;
        if(timer.loadNextQuestion)
        {
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }

        if( !hasAnswerEarly && !timer.isAnsweringQuestion )
        {
            ShowAnswer(-1);
            SetButtonState(false);
            hasAnswerEarly = true;
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnswerEarly = true;
        ShowAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score : " + scorekeeper.CalculateScore() + "%";
    
    }

     void ShowAnswer(int index)
    {
        if (index == correctIndex)
        {
            questionText.text = "correct!";
            Image button = answerButtons[index].GetComponent<Image>();
            button.sprite = changedSprite;
            scorekeeper.IncrementCorrectAnswers();
        }
        else
        {
            questionText.text = "Wrong! the correct answer is \n" + currentQuestion.GetAnswer(correctIndex);
            Image button = answerButtons[correctIndex].GetComponent<Image>();
            button.sprite = changedSprite;
        }
        scorekeeper.IncrementQuestionsSeen();
        slider.value = scorekeeper.GetQuestionsSeen();
        scoreText.text = "Score : " + scorekeeper.CalculateScore() + "%";
    
        if(slider.value == slider.maxValue)
        {
            isQuizCompleted = true;
        }
    }

    void DisplayQuesion()
    {
        correctIndex = currentQuestion.GetCorrectAnswerIndex();

        questionText.text = currentQuestion.GetQuestion();
        for(int i=0; i<answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.GetAnswer(i);
        }
    }

    void GetNextQuestion()
    {
        if(questions.Count > 0 )
        {
            hasAnswerEarly = false;
            SetRandomQuestion();
            SetButtonState(true);
            DisplayQuesion();
            SetDefaultButtonSprites();
        }
        
    }

    void SetRandomQuestion()
    {
        int index = (int)Random.Range(0f, questions.Count);
        currentQuestion = questions[index];
        questions.Remove(currentQuestion);
    }

    void SetButtonState(bool state)
    {
        for(int i=0; i<answerButtons.Length; i++)
        {
           Button button = answerButtons[i].GetComponent<Button>();
           button.interactable = state;
        }
    }
    
    void SetDefaultButtonSprites()
    {
        for(int i=0; i<answerButtons.Length; i++)
        {
        Image button = answerButtons[i].GetComponent<Image>();
        button.sprite = defaultSprite;
        }
    }   

}
