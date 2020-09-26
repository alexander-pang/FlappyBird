using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Bird> () != null)
        {
            GameControl.instance.BirdScored();
        }
        if (other.GetComponent<Bird2>() != null)
        {
            GameControl.instance.Bird2Scored();
        }
    }
}
