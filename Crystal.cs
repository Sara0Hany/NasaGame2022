using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{

    [SerializeField] private AudioSource CollectEffect;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<DamageScript>().TakeHealth(25);
            Destroy(transform.gameObject);
            CollectEffect.Play();
        }
    }
}
