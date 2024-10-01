using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGame : MonoBehaviour
{

    public float decreaseRate = 0.05f; 
    public float increaseAmount = 0.01f; 
    public float mGameProgress;

    PlayerMovements player;

    private CustomInputs input = null;
    

    public RectTransform ProgressRectTransform;

    public RectTransform MiniGameInterfaceRectTransform;

    public bool gameStart = false;
    public bool gameOver = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovements>();
        MiniGameInterfaceRectTransform.anchoredPosition = new Vector2(0, 1200);
        input = new CustomInputs();
        //mGameProgress = 0.5f;
    }

    

    private void OnEnable()
    {
        //input.Enable();
        input.MiniGame.Spam.started += OnSpamStarted;
    }
    private void OnDisable()
    {
        input.Disable();
        input.MiniGame.Spam.started -= OnSpamStarted;
    }

    private void OnSpamStarted(InputAction.CallbackContext value)
    {
        if (mGameProgress <= 1f)
        {
            mGameProgress += increaseAmount;
        }
        if (mGameProgress > 1f)
        {
            mGameProgress = 1;
        }
    }



    private void FixedUpdate()
    {
        if (mGameProgress > 0 && !gameOver)
        {
            mGameProgress -= decreaseRate * Time.fixedDeltaTime; 
        }

        ProgressRectTransform.localScale = new Vector3(mGameProgress, 1f, 1f);

        if (mGameProgress >= 0.95f && !gameOver)
        {
            GameOver();
            mGameProgress = 1;
        }
        if (mGameProgress <= 0 && gameStart)
        {
            GameOver();
            player.LostGame();
        }
        
        //Debug.Log("Game Progress: " + mGameProgress);
    }



    private void GameOver()
    {
        MiniGameInterfaceRectTransform.anchoredPosition = new Vector2(0, 1200);
        gameOver = true;
        Debug.Log("Mini Game Over!");
        gameStart = false;
        return;
    }

    public void StartMiniGame()
    {
        //Vector2.Lerp(phone.anchoredPosition, targetPosition, Time.deltaTime * moveSpeed);

        if(gameOver != true && gameStart == false)
        {
            MiniGameInterfaceRectTransform.anchoredPosition = new Vector2(0, 0);
            StartGame();
        }
        else
        {
            return;
        }
    }

    private void StartGame()
    {
        gameStart = true;
        input.Enable();
        mGameProgress = 0.5f;
        Debug.Log("Mini-Game Started!");
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
