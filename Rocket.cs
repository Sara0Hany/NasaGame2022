using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{ 
    public GameObject cket;
    [SerializeField] private AudioSource Finish;
public GameObject WinPanel;
    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {
            WinPanel.SetActive(true);
            Finish.Play();
        }
    }
}
