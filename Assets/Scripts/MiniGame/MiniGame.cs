using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGame : MonoBehaviour
{

    public float decreaseRate = 0.05f; 
    public float increaseAmount = 0.01f; 
    public float mGameProgress;
    private bool gameOver = false;
    private CustomInputs input = null;

    public RectTransform ProgressRectTransform;

    public RectTransform MiniGameInterfaceRectTransform;

    public bool GameStart=false;

    private void Awake()
    {
        MiniGameInterfaceRectTransform.anchoredPosition = new Vector3(0, 1000, 0);
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
        
        Debug.Log("Game Progress: " + mGameProgress);
    }


    private void GameOver()
    {
        MiniGameInterfaceRectTransform.anchoredPosition = new Vector3(0, 1000, 0);
        gameOver = true;
        Debug.Log("Game Over!");
        GameStart = false;
    }

    public void StartMiniGame()
    {
        MiniGameInterfaceRectTransform.anchoredPosition = new Vector3(0,0,0);
        StartGame();
        GameStart = true;
    }

    private void StartGame()
    {
        input.Enable();
        gameOver = false;
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
