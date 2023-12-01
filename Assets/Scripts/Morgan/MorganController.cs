using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorganController : MonoBehaviour
{
    public float speed = 4.0f;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastVertical = "LastVertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string walkingState = "Walking";
    public bool morganShouldMove = true;

    private Animator animator;

    public static bool isMorganCreated;
    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (!isMorganCreated)
        {
            isMorganCreated = true;
            playerRigidbody = GetComponent<Rigidbody2D>();
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Vector2 getPosition()
    {
        return playerRigidbody.position;
    }

    public void setPosition(Vector2 newPosition)
    {
        playerRigidbody.position = newPosition;
    }

    public void setPosition(Vector3 newPosition)
    {
        playerRigidbody.position = new Vector2(newPosition.x, newPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 7.9f;
            Environment.setMorganRunning(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 4.0f;
            Environment.setMorganRunning(false);
        }

        if (morganShouldMove)
        {
            float horizontalMovement = Input.GetAxisRaw(horizontal);
            float verticalMovement = Input.GetAxisRaw(vertical);

            Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0).normalized;

            // Aplicar la velocidad después de normalizar el vector de dirección
            this.transform.Translate(movement * speed * Time.deltaTime);
        }
        else
        {
            // Resto de tu código...
        }

        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));
    }
}
