using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{

    Rigidbody2D rd2d;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //print(Mathf.Abs(rd2d.transform.position.y) >= 3.8f);

         GameController.instance.SetGameOver(Mathf.Abs(rd2d.transform.position.y) >= 3.8f);

        if (GameController.instance.GetGameOver()) {
            rd2d.velocity = Vector2.zero;
        }
        else {
            rd2d.velocity = GameController.instance.GetPlayerSpeed() + new Vector2(0, speed);
        }
    }
}
