using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{

    Rigidbody2D rd2d;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rd2d.velocity = new Vector2(GameController.instance.getSpeedHorizontal() * 10, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //print("xxx");
    }
}
