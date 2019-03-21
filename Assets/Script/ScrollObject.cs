using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{

    private Rigidbody2D rd2d;
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

        const double V = 0.0;
        if (GameController.instance.getSpeedUp() != V) {
            rd2d.AddForce(Vector3.down * 1);
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

        GameController.instance.SetPlayerSpeed(rd2d.velocity);
        //rd2d.velocity = Vector2.down * GameController.instance.getSpeedUp() * 10; 
    }
}
