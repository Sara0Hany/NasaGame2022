using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs1 : MonoBehaviour
{
    public GameObject GameOverPanel;
    [SerializeField] private AudioSource Dead;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {
            GameOverPanel.SetActive(true);
            Debug.Log("hi");
            Dead.Play();
        }
    }
}
