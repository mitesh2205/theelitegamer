using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private float movementX;
    private float moveForce = 10f;
    private float jumpForce = 10f;
    private Transform playerTransform;
    public Vector3 originalSize = new Vector3(1, 1, 1);
    private string GROUND_TAG = "Ground";
    private bool isGrounded = true;
    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            moveForce = 10f;
            transform.localScale = originalSize;
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Pool"))
        {
            moveForce = 5f;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Rope2D"))
        {
            RopeControl.fix = true;
            RopeControl.coll = collision;
        }
        if (collision.gameObject.CompareTag("Spear"))
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gate1"))
        {
            // below is the code to move the player to the next x,y position. set the x,y to the position you want the player to move to.
            playerTransform.position = new Vector2(60f, -2.6f);
        }
        if (collision.gameObject.CompareTag("Gate2"))
        {
            // below is the code to move the player to the next x,y position. set the x,y to the position you want the player to move to.
            playerTransform.position = new Vector2(22.99046f, -2.6f);
        }
        if (collision.gameObject.CompareTag("Points"))
        {

            Destroy(collision.gameObject);
        }
    }

}
