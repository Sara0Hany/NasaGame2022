using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScript : MonoBehaviour
{
    public GameObject GameOver;
    public static int health = 3;
    public Image[] stars;
    public Sprite fullStar;
    public Sprite emptyStar;
   

    // Update is called once per frame
    void Update()
    {
        
        foreach(Image img in stars)
        {
            img.sprite = emptyStar;
        }

        for(int i = 0; i < health; i++)
        {
            stars[i].sprite = fullStar;
        }

   

    }
}
