using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAction : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Timer>().takeingAway = false;
            GetComponent<Timer>().secondsLeft = 15;
        }
    }
    

    /* IEnumerator hi()
    {
        yield return null;
        GetComponent<Timer>().secondsLeft = 15;
        
    }*/
}
