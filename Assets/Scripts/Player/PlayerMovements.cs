using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerMovements : MonoBehaviour
{
    // calling the customInputs class
    private CustomInputs input = null;
    private Vector2 moveVector = Vector2.zero;
    [SerializeField] float moveSpeed = 10f;
    private Rigidbody2D rb=null;
    public int stressLevel =0;
    public MiniGame MiniGame;
    public Animator animator;

    public GameObject winScreen;
    public GameObject gameOverScreen;
    public GameObject Instructions;

    private bool mainGame = false;



    private void Awake()
    {
        Instructions.SetActive(true);
        input = new CustomInputs();
        rb = GetComponent<Rigidbody2D>();
        stressLevel = 0;
        mainGame = false;
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancled;

    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancled;
    }

    public void StartMainGame()
    {
        Instructions.SetActive(false);
        mainGame = true;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
        animator.SetBool("Moving", true);
        if (moveVector.x < 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnMovementCancled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
        animator.SetBool("Moving", false);
    }


    private void FixedUpdate()
    {

        rb.velocity = moveVector*moveSpeed;
        if (MiniGame.gameStart)
        {
            input.Disable();
        }
        else
        {
            input.Enable();
        }
        if (mainGame==false)
        {
            input.Disable();
        }
        else
        {
            input.Enable();
        }

        if (stressLevel >= 100)
        {
            LostGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Goal")
        {
            Debug.Log(collision.gameObject.name);
        }

        if(collision.gameObject.name == "Friend")
        {
            //Debug.Log("MiniGame Start");
            MiniGame?.StartMiniGame();

        }
        if(collision.gameObject.tag =="Enemy")
        {
            LostGame();
        }
        if(collision.gameObject.name == "Sister")
        {
            WonGame();
        }
    }

    public void LostGame()
    {
        Debug.Log("Game is over you lost");
        gameOverScreen.SetActive(true);
    }

    public void WonGame()
    {
        Debug.Log("Game is over you Won");
        winScreen.SetActive(true);
    }



    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // Start is called before the first frame update
    void Start()
    {
        if (MiniGame == null)
        {
            Debug.LogError("MiniGame reference is not assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
