using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhonePanelController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int uses = 3;

    public RectTransform phone; // RectTransform of the phone
    public RectTransform phoneContent;
    public Button resetButton;  // Button to move the phone back to the bottom right corner
    public PlayerMovements player;

    [Header("Parameters")]
    public Vector2 hoverOffset = new Vector2(0, 30f);  // Offset when hovering (moving up)
    public float moveSpeed = 2f;  // Speed of the movement
    public Vector2 centerPosition = new Vector2(-940, 546);  // Position of the center of the screen
    public Vector2 bottomRightPosition = new Vector2(-266, -216);  // Position of the bottom right corner

    private Vector2 targetPosition;  // Target position for the phone to move to
    private bool isMoving = false;  // Flag indicating if the phone is moving
    private bool isHovering = false;  // Flag indicating if the mouse is hovering over the panel
    public Vector2 originalPosition;  // Original position

    void Start()
    {
        // Set the initial position to the bottom right corner
        originalPosition = bottomRightPosition;
        targetPosition = bottomRightPosition;
        phone.anchoredPosition = bottomRightPosition;

        // Add a listener to the resetButton to call MoveToBottomRight when clicked
        resetButton.onClick.AddListener(MoveToBottomRight);
    }

    void Update()
    {
        // Smoothly move towards the target position
        phone.anchoredPosition = Vector2.Lerp(phone.anchoredPosition, targetPosition, Time.deltaTime * moveSpeed);

        // If the phone is close enough to the target position, stop moving
        if (Vector2.Distance(phone.anchoredPosition, targetPosition) < 0.1f)
        {
            phone.anchoredPosition = targetPosition;
            isMoving = false;
        }
    }

    // Called when the mouse hovers over the PhonePanel
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isMoving)  // If the phone is not moving, apply the hover effect
        {
            isHovering = true;
            targetPosition = originalPosition + hoverOffset;  // Set the target position to the hovered offset position
        }
    }

    // Called when the mouse exits the PhonePanel
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isMoving)  // If the phone is not moving, return to the original position
        {
            isHovering = false;
        }
    }

    // Called when the PhonePanel is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        if(uses > 0)
        {
            MoveToCenter();
        }
    }

    // Move the phone to the center of the screen
    public void MoveToCenter()
    {
        targetPosition = centerPosition;
        isMoving = true;
    }

    // Move the phone back to the bottom right corner
    public void MoveToBottomRight()
    {
        if(phoneContent.position.y >= 195)
        {
            targetPosition = bottomRightPosition;
            originalPosition = bottomRightPosition;  // Update the original position
            isMoving = true;
            phoneContent.position = new Vector3(0, 0, 0);
            uses--;
            player.stressLevel -= 25;
        }
    }
}
