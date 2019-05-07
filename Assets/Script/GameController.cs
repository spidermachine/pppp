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

    public GameObject preftab;

    public float spawneRate = 4f;

    private int score = 0;

    private GameObject []pref;

    private float timeSinceLastSpawned = 0f;

    private int column;

    // Start is called before the first frame update
    void Awake()
    {
       if (instance == null) {
            instance = this;
            pref = new GameObject[5];
            for (int i = 0; i<5;i++) {
                pref[i] = Instantiate(preftab, new Vector2(-1.55f, -9f), Quaternion.identity);
            }
         }else if (instance != this) {
            Destroy(gameObject);
         }
    }

    // Update is called once per frame
    void Update()
    {

        timeSinceLastSpawned += Time.deltaTime;

        if (gameOver) {
            timeSinceLastSpawned = 0f;
            speedUp = 0;
            speedHorizontal = 0;
            uiView.SetActive(true);
            return;
        }
        if (this.getSpeedUp() > 0)
        {
            if (timeSinceLastSpawned >= spawneRate)
            {

                timeSinceLastSpawned = 0f;
                pref[column].transform.position = new Vector2(-1.55f, 3.8f);
                pref[column].SetActive(true);
                column++;
                if (column >= 5)
                {
                    column = 0;
                }
            }
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
            //speedHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * 10;
            speedUp = Input.GetAxis("Vertical") * Time.deltaTime * 10;
        }
        if (speedUp < 0) speedUp = 0f;
    }

    public float getSpeedUp() {
        
        return this.speedUp;
    }

    public float getSpeedHorizontal() {
        return this.speedHorizontal;
    }


    public Vector2 GetPlayerSpeed() {
        
        return this.playerSpeed;
    }

    public void updatePlayerSpeed(Vector2 speed) {
        this.playerSpeed = speed;
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

    public void updateScore(int score) {

        this.score += score;
    }

    public int getScore() {
        return this.score;
    }

}
