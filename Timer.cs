using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject Panel;
    public GameObject textDisplay;
    public int secondsLeft = 16;
    public bool takeingAway = false;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        
    }


    void Update()
    {
        if(secondsLeft == 0)
        {
            StartCoroutine(Wait());
        }
        if (takeingAway == false && secondsLeft > 0 && Panel.activeSelf)
        {
            StartCoroutine(TimerTake());
        }
        if(Panel.activeSelf == false)
        {
            StartCoroutine(TakeAction());
        }
        
            
        
    
    }
    public IEnumerator TimerTake()
    {
        takeingAway = true; 
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if(secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        { 
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        
        }
        takeingAway = false;
    }
    public IEnumerator TakeAction()
    {
        takeingAway = false;
        secondsLeft = 16;
        yield return null;
    }

    IEnumerator Wait()
    {
        StarScript2.health = -1;
        yield return new WaitForSeconds(7);
    }

}
