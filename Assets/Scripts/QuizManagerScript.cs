using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuizManagerScript : MonoBehaviour {

    public Question[] questions;
    private static List<Question> unAnsweredQuestions;
    private Question currentQuestion;

    [SerializeField]
    private Image sourceImage;
    [SerializeField]
    private Text[] answers = new Text[3];
    [SerializeField]
    private Text[] result = new Text[3];
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float timeBetweenQuestions = 1f;
    private void Start()
    {
        if (unAnsweredQuestions == null || unAnsweredQuestions.Count == 0)
            unAnsweredQuestions = questions.ToList<Question>();

        SetCurrentQuestion();
        Debug.Log(currentQuestion.answers[currentQuestion.correct].ToString());
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unAnsweredQuestions.Count);
        currentQuestion = unAnsweredQuestions[randomQuestionIndex];

        sourceImage.sprite = currentQuestion.signBoard;
        answers[0].text = currentQuestion.answers[0];
        answers[1].text = currentQuestion.answers[1];
        answers[2].text = currentQuestion.answers[2];

        if (currentQuestion.correct == 0)
        {
            result[0].text = "CORRECT";
            result[1].text = "FALSE";
            result[2].text = "FALSE";
        }
        else if (currentQuestion.correct == 1)
        {
            result[0].text = "FALSE";
            result[1].text = "CORRECT";
            result[2].text = "FALSE";
        }
        else
        {
            result[0].text = "FALSE";
            result[1].text = "FALSE";
            result[2].text = "CORRECT";
        }

    }

    IEnumerator TransitionToNextQuestion()
    {
        unAnsweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public  void UserSelectA()
    {
        animator.SetTrigger("A");

        if (currentQuestion.correct == 0)
            Debug.Log("Correct");
        else
            Debug.Log("Incorrect");

        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectB()
    {
        animator.SetTrigger("B");
        if (currentQuestion.correct == 1)
            Debug.Log("Correct");
        else
            Debug.Log("Incorrect");

        StartCoroutine(TransitionToNextQuestion());
    }
    public void UserSelectC()
    {
        animator.SetTrigger("C");

        if (currentQuestion.correct == 2)
            Debug.Log("Correct");
        else
            Debug.Log("Incorrect");

        StartCoroutine(TransitionToNextQuestion());

    }
}
