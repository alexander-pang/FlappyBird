using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHoriontalLength;

    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHoriontalLength = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHoriontalLength)
        {
            RepositionBackground();
        }
    }
    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(groundHoriontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffSet; ;
    }
}
