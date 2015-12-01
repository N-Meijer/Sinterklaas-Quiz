using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] questions;
    [SerializeField]
    GameObject startScreen;
    [SerializeField]
    Animator correct, incorrect;
    [Header("End screen")]
    [SerializeField]
    GameObject endScreen;
    [SerializeField]
    GameObject[] hintCovers;

    bool[] questionsCorrect;

    int currentQuestion = -1;

    void Start()
    {
        questionsCorrect = new bool[questions.Length];
        foreach (GameObject question in questions) question.SetActive(false);
        startScreen.SetActive(true);
        endScreen.SetActive(false);
    }

    public void StartQuiz()
    {
        NextQuestion();
        startScreen.SetActive(false);
    }

    public void WrongAnswer()
    {
        Debug.Log("Incorrect");
        questionsCorrect[currentQuestion] = false;
        incorrect.Play("CorrectAnimation");
        NextQuestion();
    }

    public void CorrectAnswer()
    {
        Debug.Log("Correct");
        questionsCorrect[currentQuestion] = true;
        correct.Play("CorrectAnimation");
        NextQuestion();
    }

    public void NextQuestion()
    {
        if (currentQuestion != -1)
        {
            questions[currentQuestion].SetActive(false);
        }

        if (currentQuestion + 1 != questions.Length)
        {
            currentQuestion++;
            questions[currentQuestion].SetActive(true);
        }

        else
        {
            endScreen.SetActive(true);
            for (int i = 0; i < questionsCorrect.Length; i++)
            {
                hintCovers[i].SetActive(!questionsCorrect[i]);
            }
        }
    }
}