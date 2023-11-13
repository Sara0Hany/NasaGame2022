using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionAnswers : MonoBehaviour
{
    [SerializeField] private AudioSource Correct;
    [SerializeField] private AudioSource False;
    [SerializeField] private AudioSource Dead;
    public GameObject gameover;
    [SerializeField] private float _time = 2f;
    public bool isCorrect = false;
    public QuizManager quizManager;
    [SerializeField]
    public Color startColor;

    private void Start()
    {
        
        startColor = GetComponent<Image>().color;
    }
    public void Answer()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;

            Debug.Log("Correct");
            quizManager.correct();
            StartCoroutine(ChangeColor(_time));
            Correct.Play();
            
        }

        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong");
            StarScript2.health--;
            quizManager.correct();
            False.Play();
            StartCoroutine(ChangeColor(_time));
            if(StarScript2.health <= 0)
            {
                gameover.SetActive(true);
                Dead.Play();

            }
            else
            {
                gameover.SetActive(false);
            }
        }
    }
    public IEnumerator ChangeColor(float t)
    {
        yield return new WaitForSeconds(1);
        GetComponent<Image>().color = startColor;
   
    }
    
}






