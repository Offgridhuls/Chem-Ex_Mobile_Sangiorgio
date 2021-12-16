using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform, joystickTransform, cameraTransform;
    private Vector2 pointA;
    private Vector2 pointB;

    public Rigidbody2D playerRB;
    public int playerMaxHealth = 100,
        playerHealth;

    public GameObject bulletPrefab;

    public bool isGrounded;

    public Transform groundOrigin;
    public float groundRadius;


    public Vector2 playerDirection;

    [SerializeField]
    public LayerMask groundMask, buttonMask;

    public float speed = 5.0f;
    private bool touchStart = false;

    public static PlayerController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject((touch.fingerId)))
            {
                joystickTransform.GetComponent<SpriteRenderer>().enabled = true;
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        pointA = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
                            Camera.main.transform.position.z));
                        joystickTransform.position = pointA;
                        break;

                    case TouchPhase.Moved:
                        touchStart = true;
                        joystickTransform.GetComponent<SpriteRenderer>().enabled = true;
                        pointB = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
                            Camera.main.transform.position.z));
                        break;
                }
            }
        }
        else
            touchStart = false;
    }

    private void FixedUpdate()
    {
        Vector2 offset = pointA - pointB;
        Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
        playerDirection = direction;

        if (touchStart == true)
        {
            MovePlayer(direction);
            joystickTransform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
        }
        else
        {
            joystickTransform.GetComponent<SpriteRenderer>().enabled = false;
        }
        CheckIsGrounded();
    }

    void MovePlayer(Vector2 direction)
    {
        playerTransform.Translate(new Vector2(direction.x, 0) * speed * Time.deltaTime);
    }

    private void CheckIsGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, groundMask);

        isGrounded = (hit) ? true : false;
    }

}
