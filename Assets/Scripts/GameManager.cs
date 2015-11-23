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

    bool[] questionsCorrect;

    int currentQuestion = -1;

    // Use this for initialization
    void Start()
    {
        questionsCorrect = new bool[questions.Length];
        foreach (GameObject question in questions) question.SetActive(false);
        startScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

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
            Debug.Log("End reached");
        }
    }
}
