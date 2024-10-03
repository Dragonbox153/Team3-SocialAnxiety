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

    public GameObject MinigameSlide1;
    public GameObject MinigameSlide2;
    public GameObject MinigameSlide3;

    PlayerMovements player;

    private CustomInputs input = null;
    

    public RectTransform ProgressRectTransform;

    public RectTransform MiniGameInterfaceRectTransform;

    public bool gameStart = false;
    public bool gameOver = false;

    private void Awake()
    {
        MinigameSlide1.SetActive(false);
        MinigameSlide2.SetActive(false);
        MinigameSlide3.SetActive(false);
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
            //GameOver();
            StartMiniGameSlide3();
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

    public void exitMiniGame()
    {
        GameOver();
    }

    public void StartMiniGameSlide3()
    {
        MinigameSlide2.SetActive(false);
        MinigameSlide3.SetActive(true);
    }

    public void StartMiniGame()
    {
        if (gameOver != true && gameStart == false)
        {
            MiniGameInterfaceRectTransform.anchoredPosition = new Vector2(0, 0);
            
            MinigameSlide1.SetActive(true);
        }
        else
        {
            return;
        }
        //Vector2.Lerp(phone.anchoredPosition, targetPosition, Time.deltaTime * moveSpeed);
        
        
    }

    public void StartMiniGameSlide2()
    {
        MinigameSlide1.SetActive(false);
        MinigameSlide2.SetActive(true);
        StartGame();
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
