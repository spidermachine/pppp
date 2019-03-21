using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private float speedUp = 0f;

    private float speedHorizontal = 0f;

    public static GameController instance;

    public GameObject uiView;

    public AudioSource runAudio;

    public AudioSource stopAudio;

    private Vector2 playerSpeed = Vector2.zero;

    bool touched = false;

    bool gameOver = false;

    // Start is called before the first frame update
    void Awake()
    {
       if (instance == null) {
            instance = this;
         }else if (instance != this) {
            Destroy(gameObject);
         }
    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver) {
            speedUp = 0;
            speedHorizontal = 0;
            uiView.SetActive(true);
            return;
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved) {
                speedUp = Time.deltaTime * 10;
                speedHorizontal = 0;
                run();
                touched = true;
              }
        }
        else
        {
            if (touched) {
                stop();
                touched = false; 
            }
            speedHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * 10;
            speedUp = Input.GetAxis("Vertical") * Time.deltaTime * 10;
        }
        if (speedUp < 0) speedUp = 0f;
    }

    public float getSpeedUp() {
        //print(this.speedUp);
        return this.speedUp;
    }

    public float getSpeedHorizontal() {
        return this.speedHorizontal;
    }


    public void SetPlayerSpeed(Vector2 speed) {
        this.playerSpeed = speed;
    }

    public Vector2 GetPlayerSpeed() {
        return this.playerSpeed;
    }

    public void SetGameOver(bool over) {
        this.gameOver = over;
      }


    public bool GetGameOver() {
        return this.gameOver;
      }

    void run() {
        if (!touched)
        {
            stopAudio.Stop();
            runAudio.loop = true;
            runAudio.Play();
        }

    }

    void stop() {

        runAudio.Stop();
        stopAudio.Play();
    }
}
