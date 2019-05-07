using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollison : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject lgameObject = collision.gameObject;
        lgameObject.SetActive(false);
        Rigidbody2D rd = collision.GetComponent<Rigidbody2D>();
        rd.transform.position = new Vector2(-1.55f, -9f);

        GameController.instance.updateScore(1);
        
    }


}
