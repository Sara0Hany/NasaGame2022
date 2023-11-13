using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs2 : MonoBehaviour
{
    public GameObject GameOverPanel;
    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {
            GameOverPanel.SetActive(true);
            Debug.Log("hi");

        }
    }
}
