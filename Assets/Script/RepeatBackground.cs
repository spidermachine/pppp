using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    SpriteRenderer rd2d;

    private float bgy;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<SpriteRenderer>();
        bgy = rd2d.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < - bgy) {

            Vector2 vector2 = new Vector2(0, bgy * 2f);
            transform.position = (Vector2)transform.position + vector2; 
        }

    }
}
