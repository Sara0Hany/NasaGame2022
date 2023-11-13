using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPanel : MonoBehaviour
{
    [SerializeField] private float _time = 10f;
    public GameObject lastpanel;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(WaitDoor(_time));
            lastpanel.SetActive(true);
        }
    }

    public IEnumerator WaitDoor(float t)
    {
        yield return new WaitForSeconds(20);

    }
}
