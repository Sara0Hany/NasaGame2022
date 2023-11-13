using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStar : MonoBehaviour
{
    [SerializeField] private float _time = 5f;
    Animator Opening;
    /*public Transform RayPosition2;
    public LayerMask mask;
    public Transform doorAnim;*/

    public GameObject Panel;

    private void Start()
    {
        Opening = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Wait(_time));
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(Wait(_time));
            Panel.SetActive(true);
            StartCoroutine(Wait(_time));
            Opening.SetBool("Open", true);
            StartCoroutine(Wait(_time));
        }
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        /*if (Vector3.Distance(transform.position, doorAnim.position) < 10)
        {
            Debug.Log("lol");
            //doorAnim.transform.GetComponent<Animator>().SetBool("open", true);

        }
        else
        {
            Debug.Log("no");
            //doorAnim.transform.GetComponent<Animator>().SetBool("open", false);
        }*/
    }
    public IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(20);

    }
}
