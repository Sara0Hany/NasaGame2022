using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private AudioSource Dead;
    public bool collisiondetection = false;
    public GameObject GameOverPanel;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame


    /*private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.transform.tag == "Player")
        {
            
            currentHealth = currentHealth - damage;
            healthBar.SetHealth(currentHealth);
            Debug.Log("mmm");
            Destroy(transform.gameObject);
        }
    }*/

    void Update()
    {
        if (collisiondetection)
        {
            TakeDamage(20);
        }
            
        if (currentHealth <= 0)
        {
            GameOverPanel.SetActive(true);
            Dead.Play();
        }

       
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void TakeHealth(int Bonus)
    {
        currentHealth += Bonus;
        healthBar.SetHealth(currentHealth);
    }
    

    IEnumerator ExampleCoroutine()
    {
       
        yield return new WaitForSeconds(10);
    }
}
