using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjectCoin: MonoBehaviour
{

    private Rigidbody2D rd2d;

    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        rd2d.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        rd2d.velocity = GameController.instance.GetPlayerSpeed(); 
    }
}
