using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonCollision1 : MonoBehaviour
{
    [SerializeField] private AudioSource Damage;
    [SerializeField] private float _time = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<DamageScript>().TakeDamage(50);
            Destroy(transform.gameObject);
            Damage.Play();
    
        }
    }
    public IEnumerator makefalse(float t)
    {
        yield return new WaitForSeconds(1);

    }
}
