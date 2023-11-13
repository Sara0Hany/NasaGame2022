using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal1 : MonoBehaviour
{
   


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<DamageScript>().TakeHealth(50);
            Destroy(transform.gameObject);
            
        }
    }
}
