using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public Transform Character;
    Rigidbody Rigidbody;
    bool move = false;
    // Start is called before the first frame update
    void Start()
    {

        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Character.position);
        if (Vector3.Distance(Character.position, transform.position) < 8)
        {
            Debug.Log("OMG");
            move = true;
        }
        if (move)
        {
            StartCoroutine(DestroyObject());
            Vector3 vector3 = Character.position - transform.position;
            Vector3 Normalized = vector3.normalized;
            Rigidbody.AddForce(Normalized * 7);
            Debug.Log("wow");
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(6);
        Destroy(transform.gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<DamageScript>().TakeDamage(25);
            Destroy(transform.gameObject);
        }

    }
}
