using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGame : MonoBehaviour
{

    public float decreaseRate = 0.05f; 
    public float increaseAmount = 0.01f; 
    public float mGameProgress;
    public float[] timeLessThan = { 2,3,4,5,6};
    public int[] stressIncreaseAmount = { 2,3,4,5,6};

    PlayerMovements player;

    private CustomInputs input = null;
    
    
    public float SecToCompleteGame=0f;

    public RectTransform ProgressRectTransform;

    public RectTransform MiniGameInterfaceRectTransform;

    public bool GameStart=false;
    private bool gameOver = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovements>();
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

        if (GameStart == true)
        {
            SecToCompleteGame += Time.deltaTime;
        }
        
        //Debug.Log("Game Progress: " + mGameProgress);
    }

    private void AddStress()
    {
        Debug.Log("StressAdding");
        if (SecToCompleteGame <= timeLessThan[0])
        {
            player.stressLevel += stressIncreaseAmount[0];
        }
        else if(SecToCompleteGame <= timeLessThan[1] && SecToCompleteGame > timeLessThan[0])
        {
            player.stressLevel += stressIncreaseAmount[1];
        }
        else if (SecToCompleteGame <= timeLessThan[2] && SecToCompleteGame > timeLessThan[1])
        {
            player.stressLevel += stressIncreaseAmount[2];
        }
        else if (SecToCompleteGame <= timeLessThan[3] && SecToCompleteGame > timeLessThan[2])
        {
            player.stressLevel += stressIncreaseAmount[3];
        }
        else if (SecToCompleteGame <= timeLessThan[4] && SecToCompleteGame > timeLessThan[3])
        {
            player.stressLevel += stressIncreaseAmount[4];
        }
    }


    private void GameOver()
    {
        MiniGameInterfaceRectTransform.anchoredPosition = new Vector3(0, 1000, 0);
        gameOver = true;
        Debug.Log("Game Over!");
        Debug.Log(SecToCompleteGame);
        AddStress();
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
