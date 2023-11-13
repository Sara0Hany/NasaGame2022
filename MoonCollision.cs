using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonCollision : MonoBehaviour
{
    [SerializeField] private AudioSource DamageEffect;
    [SerializeField] private float _time = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<DamageScript>().TakeDamage(25);
            Destroy(transform.gameObject);
            DamageEffect.Play();
    
        }
    }
    public IEnumerator makefalse(float t)
    {
        yield return new WaitForSeconds(1);

    }
}
