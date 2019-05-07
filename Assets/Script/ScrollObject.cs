using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{

    private Rigidbody2D rd2d;

    public float speed = 2.0f;

    public bool updatePlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        rd2d.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.GetGameOver()) {

            rd2d.AddForce(Vector3.zero);
            rd2d.velocity = Vector2.zero;
            return;
        }

        if (GameController.instance.getSpeedUp() > 0) {
           
            rd2d.AddForce(Vector3.down * GameController.instance.getSpeedUp() * speed);
        }
        else { 
            if ( Mathf.Sqrt(Mathf.Pow(rd2d.velocity.x, 2) + Mathf.Pow(rd2d.velocity.y, 2)) > 0.1 ) {
                rd2d.AddForce(Vector3.up * 1);
            }
            else {
                rd2d.AddForce(Vector3.zero);
                rd2d.velocity = Vector2.zero;
            }
        }
        //更新玩家速度
        if (updatePlayer)
        {
            GameController.instance.updatePlayerSpeed(rd2d.velocity);
        }
    }
}
