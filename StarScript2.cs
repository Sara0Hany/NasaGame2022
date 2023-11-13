using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScript2 : MonoBehaviour
{
    
    public GameObject panelover;
    public static int health = 3;
    public Image[] stars;
    public Sprite fullStar;
    public Sprite emptyStar;

    private void Awake()
    {
        health = 3;
    }


    // Update is called once per frame
    void Update()
    {

        foreach (Image img in stars)
        {
            img.sprite = emptyStar;
        }

        for (int i = 0; i < health; i++)
        {
            stars[i].sprite = fullStar;
        }

        if (health <= 0)
        {
            panelover.SetActive(true);
        }

        
    }
}
