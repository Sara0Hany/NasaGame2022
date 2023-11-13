using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAgain : MonoBehaviour
{
    int i = 0;
    [SerializeField] private float _timePeriod = 20f;
    public Text timeText;
    public int time = 30;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "0:" + time;
        
        while(i < time)
        {
            time--;
            StartCoroutine(Seconds(_timePeriod));
            i++;
        }
        /*for (int i = 0; i < time; i++)
        {
            time--;
            StartCoroutine(Seconds(_timePeriod));
        }*/

    }

    public IEnumerator Seconds(float t)
    {
        yield return new WaitForSeconds(1);

    }
}

