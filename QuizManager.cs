using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    
    public GameObject QuestionsPanel;
    [SerializeField] private float _time = 1f;
    public List<QuestionsAndAswers> QnA;
    public GameObject[] options;
    public int CurrentQuestion;

    public Text QuestionTxt;

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        
        
        StartCoroutine(Wait(_time));
    }

    void SetAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<QuestionAnswers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[CurrentQuestion].Answers[i];

            if(QnA[CurrentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<QuestionAnswers>().isCorrect = true;
                
            }
        }

    }

    void generateQuestion()
    {
       
        if(QnA.Count > 0)
        {
            
            CurrentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[CurrentQuestion].Question;
            SetAnswers();
           
        }
        else
        {
            Debug.Log("Out Of Question");
        }


    }
    public IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);
        QnA.RemoveAt(CurrentQuestion);
        generateQuestion();
        QuestionsPanel.SetActive(false);
        

    }
}



