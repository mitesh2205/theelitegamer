using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;
using Newtonsoft.Json;
public class Player : MonoBehaviour
{
    public Camera secondCamera;
    public Camera mainCamera;
    public float cameraSwitchDelay = 0.5f;
    private float lastCameraSwitchTime;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private float movementX;
    [SerializeField]
    public static float moveForce = 16f;
    [SerializeField]
    private float jumpForce = 12f;
    private Transform playerTransform;
    public Vector3 originalSize = new Vector3(1, 1, 1);
    private string GROUND_TAG = "Ground";
    private bool isGrounded = true;
    public int time_start;
    private bool isInvincible = false;
    public static bool spriteFlip = false;



    // private bool ispath_recorded;

    public GameObject play_again_panel;
    public Transform circle;
    public Transform square;

    public float greensafestandingtime = 0f;
    public float bluesafestandingtime = 0f;
    public float greenunsafestandingtime = 0f;
    public float blueunsafestandingtime = 0f;

    public bool intiater;
    public Text TextBox1;
    public Text TextBox2;
    public Text TextBox3;
    public int count = 0;
    public int attemps = 0;

    public int flagd = 0;
    public int flagw = 0;
    public int flagt = 0;
    public bool win_flag = false;

    public bool pushflag = false;

    public bool flagss = false;
    // hash set
    public HashSet<string> hs = new HashSet<string>();


    // Colliding with the blue floor 
    float timeElapsed = 0f;
    bool isColliding = false;

    bool ispresentonred = false;
    bool ispresentonblue = false;
    [SerializeField]
    public float maxstaytime = 8f;

    public LevelTimerScript levelTimerScript;

    public GameObject PausePanel;

    // hash set
    float safetimer = 0f;
    bool safemode = false;
    public static bool store_blue_state;
    public static bool store_green_state;

    public static int perfect_jumps = 0;
    public bool was_last_green = false;
    public bool was_last_blue = false;

    Color blueColor = new Color();

    // Start is called before the first frame update
    increment_death d;
    public static bool blink_blue = false;
    public static bool blink_green = false;

    public static bool die_hint = false;

    private bool is_unsafe_platform = true;

    public static bool reset_level_timer = false;

    public LevelTimerScript levelTimer1;

    // new code added 
    public static Vector3 checkpointPosition;
    public LevelTimerScript levelTimer;
    public static float timeLeft;
    public static float jetPackLeft;
    public static float timer_jetpack;
    public static float jetpackduration1;

    public static bool checkpointReached = false;
    private Animator anim;
    private bool isCameraEnabled = false;

    public int attemps_record = 5;

    private float boostTime;
    private bool bosting;

    private bool hotReload = true;
    private enum PlayerState
    {
        idle,
        running,
        jumping,
        falling
    };

    private void Awake()
    {
        //Dhruvit's code start
        // myText.SetActive(true);
        // myText2.SetActive(false);
        // myText3.SetActive(false);
        // myText4.SetActive(false);
        // myText5.SetActive(false);
        // myText6.SetActive(false);
        // myText7.SetActive(false);
        // myText8.SetActive(false);
        //Dhruvit's code end


        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        d = FindObjectOfType<increment_death>();
        time_start = (int)Time.deltaTime;

        if (pause_menu.GameIsPaused)
        {
            pause_menu.GameIsPaused = false;
        }

        //player_set_color_green();

        // create a object of the class and call the function

        // s._sessionID = System.DateTime.Now.Ticks;
        // Debug.Log(s._sessionID);

    }
    void Start()
    {
        ColorUtility.TryParseHtmlString("#0088F3", out blueColor);
        playerTransform = transform;
        myBody.gravityScale = 1;
        print(myBody.gravityScale);
        anim = GetComponent<Animator>();
        // playerTransform.color = Color.green;
        // player_set_color_green();
        // print("gravity");
        // circle = transform.Find("rolling_circle");


    }

    void decrease_attempts()
    {
        // node on decreasing the attempt i want to make player invincible for 2 seconds 
        // and then decrease the attempt

        if (!isInvincible)
        {
            Attempts_Counter.attempts--;
            die_hint = true;
            d.IncreaseDeathLocationOfPlayer(playerTransform.position.x, playerTransform.position.y);
            isInvincible = true;
            StartCoroutine(InvincibilityCoroutine());
        }
    }
    IEnumerator InvincibilityCoroutine()
    {
        yield return new WaitForSeconds(2);
        isInvincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (!die_hint)
        // {
        //     reset_player_color_to_white();
        // }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Restart_game.PauseGame();
        }
        if (Restart_game.isPaused)
        {
            PausePanel.SetActive(true);
        }
        else
        {
            PausePanel.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Time.time - lastCameraSwitchTime > cameraSwitchDelay)
            {
                if (isCameraEnabled)
                {
                    secondCamera.enabled = false;
                    mainCamera.enabled = true;
                    isCameraEnabled = false;
                }
                else
                {
                    secondCamera.enabled = true;
                    mainCamera.enabled = false;
                    isCameraEnabled = true;
                }
                lastCameraSwitchTime = Time.time;
            }
        }


        if (hotReload)
        {
            hotReload = false;
            Timer.green_safe = true;
            Timer.blue_safe = false;
            // player_set_color_green();
        }
        // if the flag of blue safe is true in timer then change the color of player to blue else green 
        if (Timer.IsBlueFloorSafe() && Timer.IsGreenFloorSafe())
        {
            sr.color = Color.white;
        }
        else
        {
            if (Timer.IsBlueFloorSafe())
            {
                sr.color = blueColor;
            }
            else if (Timer.IsGreenFloorSafe())
            {
                sr.color = Color.green;
            }
        }
        // if (Timer.IsBlueFloorSafe() && Timer.IsGreenFloorSafe())
        // {
        //     sr.color = Color.white;
        // }
        // else
        // {
        //     if (Timer.IsBlueFloorSafe())
        //     {
        //         // sr.color = blueColor;
        //         player_set_color_blue();
        //     }
        //     else if (Timer.IsGreenFloorSafe())
        //     {
        //         // sr.color = Color.green;
        //         player_set_color_green();
        //     }
        // }


        if (perfect_jumps >= 3)
        {
            perfect_jumps = 0;
            GameObject[] red_blocks = GameObject.FindGameObjectsWithTag("Red_block");
            foreach (GameObject red_block in red_blocks)
            {
                red_block.GetComponent<SpriteRenderer>().color = Color.white;
            }
            GameObject[] blue_blocks = GameObject.FindGameObjectsWithTag("Blue_block");
            foreach (GameObject blue_block in blue_blocks)
            {
                blue_block.GetComponent<SpriteRenderer>().color = Color.white;
            }
            safemode = true;
            Timer.danger_time = false;
            store_blue_state = Timer.blue_safe;
            store_green_state = Timer.green_safe;
        }
        if (bosting)
        {
            boostTime += Time.deltaTime;
            if (boostTime >= 4)
            {
                moveForce = 16f;
                boostTime = 0;
                bosting = false;
            }
        }
        if (safemode)
        {

            safetimer += Time.deltaTime;
            if (safetimer >= 6f && safetimer < 10f)
            {
                blink_blue = true;
                blink_green = true;
            }
            if (safetimer >= 10f)
            {
                blink_blue = false;
                blink_green = false;
                safetimer = 0f;
                safemode = false;

                // set back the color of the red blocks and blue blocks to normal
                GameObject[] redblocks = GameObject.FindGameObjectsWithTag("Red_block");
                foreach (GameObject redblock in redblocks)
                {
                    redblock.GetComponent<SpriteRenderer>().color = Color.green;
                }
                GameObject[] blue_blocks = GameObject.FindGameObjectsWithTag("Blue_block");
                foreach (GameObject blue_block in blue_blocks)
                {
                    ColorUtility.TryParseHtmlString("#0088F3", out blueColor);
                    blue_block.GetComponent<SpriteRenderer>().color = blueColor;
                }
                Timer.danger_time = true;
                Timer.blue_safe = store_blue_state;
                Timer.green_safe = store_green_state;
            }
        }


        // myBody.gravityScale = -2;
        if (LevelTimerScript.timerover == true)
        {
            reset_player_position();
            death_option();
            d.IncreaseIsTimeout();
            LevelTimerScript.timerover = false;
        }
        // colliding with any floor--------------------
        if (Attempts_Counter.attempts <= 0)
        {

            if (checkpointReached)
            {
                reset_player_position_to_checkpoint();

            }
            else
            {
                reset_player_position();
                Debug.Log("player reset to start_____");
                death_option();
                Debug.Log("player died))____");
                Attempts_Counter.attempts = 5;
                Debug.Log("attempts reset to 5 _____");
            }
            // reset_player_position();
            // death_option();
            // Attempts_Counter.attempts = 5;
        }

        if (isColliding && timeElapsed >= maxstaytime && ispresentonblue && !Timer.IsBlueFloorSafe())
        {
            Debug.Log("Player is colling more than 2 sec");
            Debug.Log("time elap: " + timeElapsed);
            Debug.Log("max stay time: " + maxstaytime);
            timeElapsed = 0f;
            // d.IncreaseDeath();
            isColliding = false;
            decrease_attempts();
            // Attempts_Counter.attempts--;

            blueunsafestandingtime += Time.deltaTime;

            // Debug.Log("present on blue and unsafe");
            Debug.Log(blueunsafestandingtime);
            // reset_player_position();
            // death_option();
        }
        else if (isColliding && timeElapsed >= maxstaytime && ispresentonred && !Timer.IsGreenFloorSafe())
        {
            // Debug.Log("Player is colling more than 2 sec");
            timeElapsed = 0f;
            // d.IncreaseDeath();
            isColliding = false;
            decrease_attempts();
            // Attempts_Counter.attempts--;
            greenunsafestandingtime += Time.deltaTime;
            // Debug.Log("present on green and unsafe");
            Debug.Log(greenunsafestandingtime);
            // reset_player_position();
            // death_option();
        }
        if (isColliding && ispresentonblue && !Timer.IsBlueFloorSafe())
        {
            timeElapsed += Time.deltaTime;
            blueunsafestandingtime += Time.deltaTime;
        }
        else if (isColliding && ispresentonred && !Timer.IsGreenFloorSafe())
        {
            timeElapsed += Time.deltaTime;
            greenunsafestandingtime += Time.deltaTime;
        }
        else
        {
            timeElapsed = 0f;
        }

        if (isColliding && ispresentonblue && Timer.IsBlueFloorSafe())
        {
            Debug.Log("Blue is safe and player is standing on it");
            bluesafestandingtime += Time.deltaTime;
            Debug.Log(bluesafestandingtime);
        }
        else if (isColliding && ispresentonred && Timer.IsGreenFloorSafe())
        {
            Debug.Log("Green is safe and player is standing on it");
            greensafestandingtime += Time.deltaTime;
            Debug.Log(greensafestandingtime);
        }

        if (pushflag)
        {
            //find gamecomponent by tag and enable it 
            // GameObject.FindGameObjectsWithTag("blokage").SpriteRenderer.enabled = false;
            GameObject blokage = GameObject.FindWithTag("blokage");
            if (blokage != null)
            {
                BoxCollider2D collider = blokage.GetComponent<BoxCollider2D>();
                collider.isTrigger = true;
                SpriteRenderer renderer = blokage.GetComponent<SpriteRenderer>();
                renderer.enabled = false;
                // blokage.SetActive(false);
            }
            GameObject push_button = GameObject.FindWithTag("Push_button");
            if (push_button != null)
            {
                SpriteRenderer renderer = push_button.GetComponent<SpriteRenderer>();
                renderer.color = Color.green;
            }
            // GameObject.FindGameObjectsWithTag("Push_button").SetActive(false);
        }
        else
        {
            GameObject blokage = GameObject.FindWithTag("blokage");
            if (blokage != null)
            {
                BoxCollider2D collider = blokage.GetComponent<BoxCollider2D>();
                collider.isTrigger = false;
                SpriteRenderer renderer = blokage.GetComponent<SpriteRenderer>();
                renderer.enabled = true;
            }
            GameObject push_button = GameObject.FindWithTag("Push_button");
            if (push_button != null)
            {
                SpriteRenderer renderer = push_button.GetComponent<SpriteRenderer>();
                renderer.color = Color.white;
            }
        }

        if (flagss)
        {
            pushflag = false;
            flagss = false;
        }


        if (pushflag)
        {
            //find gamecomponent by tag and enable it 
            // GameObject.FindGameObjectsWithTag("blokage").SpriteRenderer.enabled = false;
            GameObject blokage = GameObject.FindWithTag("blokage");
            if (blokage != null)
            {
                BoxCollider2D collider = blokage.GetComponent<BoxCollider2D>();
                collider.isTrigger = true;
                SpriteRenderer renderer = blokage.GetComponent<SpriteRenderer>();
                renderer.enabled = false;
                // blokage.SetActive(false);
            }
            GameObject push_button = GameObject.FindWithTag("Push_button");
            if (push_button != null)
            {
                SpriteRenderer renderer = push_button.GetComponent<SpriteRenderer>();
                renderer.color = Color.green;
            }
            // GameObject.FindGameObjectsWithTag("Push_button").SetActive(false);
        }
        else
        {
            GameObject blokage = GameObject.FindWithTag("blokage");
            if (blokage != null)
            {
                BoxCollider2D collider = blokage.GetComponent<BoxCollider2D>();
                collider.isTrigger = false;
                SpriteRenderer renderer = blokage.GetComponent<SpriteRenderer>();
                renderer.enabled = true;
            }
            GameObject push_button = GameObject.FindWithTag("Push_button");
            if (push_button != null)
            {
                SpriteRenderer renderer = push_button.GetComponent<SpriteRenderer>();
                renderer.color = Color.white;
            }
        }

        if (Movement.usedJetpack)
        {
            d.IncreaseJetpack();
            Movement.usedJetpack = false;
        }

        if (flagss)
        {
            pushflag = false;
            flagss = false;
        }

        PlayerMoveKeyboard();
        PlayerJump();
        // count = hs.Count;
        if (hs.Count == 4)
        {
            TextBox3.enabled = true;
            win_flag = true;
            count = 0;
            flagw = 1;
            flagt = 1;
            attemps = -1;
            hs.Clear();
            TextBox1.enabled = false;
            TextBox2.enabled = false;
        }
        // if (count == 4)
        // if (attemps == 2)
        // {
        //     // d.IncreaseDeath();
        //     // d.IncreaseDeathByPuzzle();
        //     print("You Lost");

        //     // textbox_disabler();
        //     attemps = 0;
        //     playerTransform.position = new Vector2(-12f, -8.6f);


        //     // textbox_disabler();
        //     attemps = 0;
        //     playerTransform.position = new Vector2(-12f, -8.6f);

        // }
        // if (intiater)
        // {
        //     TextBox1.enabled = true;
        //     TextBox2.enabled = true;
        //     intiater = false;
        // }

        if (LevelOverScreenScript.isGameOver)
        {
            d.IncreaseIsTimeout();
        }
        if (play_again_button.sendData == true)
        {
            play_again_button.sendData = false;
            // print("sending data");
            Debug.Log("sending data");
            d.IncreaseDeath();
            d.IncreaseTimeToCompleteLevel((int)Time.time - time_start);
            d.IncreseTimeRedStandingSafe((int)greensafestandingtime);
            d.IncreseTimeBlueStandingSafe((int)bluesafestandingtime);
            d.IncreseTimeRedStandingUnsafe((int)greenunsafestandingtime);
            d.IncreseTimeBlueStandingUnsafe((int)blueunsafestandingtime);

            PlayerDied(System.DateTime.Now.Ticks.ToString(), d.death.ToString(), d.death_by_saw.ToString(),
            d.death_by_spikes.ToString(), d.death_by_enemy.ToString(), d.death_by_spear.ToString(),
            d.death_by_explosive.ToString(), d.death_by_crusher.ToString(), d.time_to_complete_level.ToString(),
            d.death_by_falling.ToString(), d.death_by_puzzle.ToString(), SceneManager.GetActiveScene().buildIndex.ToString(),
            d.spring_used.ToString(), d.button_used.ToString(), d.ladder_used.ToString(), d.jetpack.ToString(),
            d.rope.ToString(), d.teleporter_used.ToString(), Math.Round(greensafestandingtime, 0).ToString(),
            Math.Round(bluesafestandingtime, 0).ToString(), Math.Round(greenunsafestandingtime, 0).ToString(),
            Math.Round(blueunsafestandingtime, 0).ToString(), d.jetpack_used_cnt_success.ToString(),
            d.rope_used_cnt_success.ToString(), d.spring_used_cnt_success.ToString(), d.teleporter_used_cnt_success.ToString(),
            Attempts_Counter.attempts.ToString(), d.death_location_of_player, d.is_timeout.ToString(), d.is_level_completed.ToString(),
            d.player_path, d.unsafe_platform_coordinates, d.death_by_laser.ToString());
            // play_again_panel.SetActive(true
        }
        else
        {
            // print("not sending data");
            // Debug.Log("not sending data");
            // play_again_panel.SetActive(false);
        }



    }

    void reset_player_color_to_white()
    {
        Debug.Log("reset_player_color_to_white");
        sr.GetComponent<SpriteRenderer>().color = Color.white;
    }
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

        PlayerState playerState;

        if (movementX > 0f)
        {
            // anim.SetBool("running", true);
            playerState = PlayerState.running;
            sr.flipX = false;
            spriteFlip = false;
            firepoint.unfix();
        }
        else if (movementX < 0f)
        {
            // anim.SetBool("running", true);
            playerState = PlayerState.running;
            sr.flipX = true;
            spriteFlip = true;
            firepoint.fix();
        }
        else
        {
            // anim.SetBool("running", false);
            playerState = PlayerState.idle;
        }

        if (myBody.velocity.y < -0.1f)
        {
            // anim.SetBool("falling", true);
            playerState = PlayerState.falling;
        }
        else if (myBody.velocity.y > 0.1f)
        {
            // anim.SetBool("jumping", true);
            playerState = PlayerState.jumping;
        }

        anim.SetInteger("player_state", (int)playerState);
        Debug.Log("player_state: " + playerState);


    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump_pressed");
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Blue_block") && !Timer.IsBlueFloorSafe())
        {
            // isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
            // print("IsBlueFloorSafe ---- Stay");
            isColliding = true;
            ispresentonblue = true;
            if (is_unsafe_platform)
            {
                d.IncreaseUnsafePlatformCoordinates(playerTransform.position.x, playerTransform.position.y);
                is_unsafe_platform = false;
            }
        }
        if (collision.gameObject.CompareTag("Blue_block") && Timer.IsBlueFloorSafe())
        {
            // isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
            // print("IsBlueFloorSafe safe ----");
            isColliding = true;
            ispresentonblue = true;
            timeElapsed = 0f;
            is_unsafe_platform = true;
        }
        if (collision.gameObject.CompareTag("Red_block") && !Timer.IsGreenFloorSafe())
        {
            // isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
            // print("IsGreenFloorSafe ---- Stay");
            isColliding = true;
            ispresentonred = true;
            if (is_unsafe_platform)
            {
                d.IncreaseUnsafePlatformCoordinates(playerTransform.position.x, playerTransform.position.y);
                is_unsafe_platform = false;
            }
        }
        if (collision.gameObject.CompareTag("Red_block") && Timer.IsGreenFloorSafe())
        {
            // isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
            // print("IsGreenFloorSafe safe ----");
            isColliding = true;
            ispresentonred = true;
            timeElapsed = 0f;
            is_unsafe_platform = true;
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            d.IncreaseDeathByEnemy();
            d.IncreaseDeathLocationOfPlayer(playerTransform.position.x, playerTransform.position.y);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Blue_block") && !Timer.IsBlueFloorSafe())
        {
            // isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
            // print("IsBlueFloorSafe ---- Exit");
            isColliding = false;
            timeElapsed = 0f;
            ispresentonblue = false;

        }

        if (collision.gameObject.CompareTag("Blue_block") && Timer.IsBlueFloorSafe())
        {
            // isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
            // print("IsBlueFloorSafe ---- Exit");
            isColliding = false;
            timeElapsed = 0f;
            ispresentonblue = false;

        }

        if (collision.gameObject.CompareTag("Red_block") && !Timer.IsGreenFloorSafe())
        {
            // isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
            // print("IsGreenFloorSafe ---- Exit");
            isColliding = false;
            timeElapsed = 0f;
            ispresentonred = false;
        }
        if (collision.gameObject.CompareTag("Red_block") && Timer.IsGreenFloorSafe())
        {
            // isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
            // print("IsGreenFloorSafe ---- Exit");
            isColliding = false;
            timeElapsed = 0f;
            ispresentonred = false;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Blue_block") && Timer.IsBlueFloorSafe())
        {
            isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
            // print("IsBlueFloorSafe");
            ispresentonblue = true;
            if (!was_last_blue && Timer.danger_time)
            {
                perfect_jumps++;
                was_last_blue = true;
                was_last_green = false;
                Debug.Log("perfect jumps: " + perfect_jumps);
            }


            timeElapsed = 0f;

        }

        if (collision.gameObject.CompareTag("Blue_block") && !Timer.IsBlueFloorSafe())
        {
            isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
            // print("IsBlueNotSafe");
            ispresentonblue = true;
            perfect_jumps = 0;
            // d.IncreaseDeath();
            // d.IncreaseDeathByFalling();
            decrease_attempts();
            // Attempts_Counter.attempts--;
            // Destroy(gameObject);
            // reset_player_position();
            // death_option();
        }

        if (collision.gameObject.CompareTag("Red_block") && Timer.IsGreenFloorSafe())
        {
            isGrounded = true;
            // moveForce = 10f;
            ispresentonred = true;
            // transform.localScale = originalSize;
            // print("IsGreenFloorSafe");
            if (!was_last_green && Timer.danger_time)
            {
                perfect_jumps++;
                was_last_green = true;
                was_last_blue = false;
                Debug.Log("perfect jumps: " + perfect_jumps);
            }
            timeElapsed = 0f;

        }

        if (collision.gameObject.CompareTag("Red_block") && !Timer.IsGreenFloorSafe())
        {
            isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
            // print("IsGreenNotSafe");
            ispresentonred = true;
            perfect_jumps = 0;
            // d.IncreaseDeath();
            // d.IncreaseDeathByFalling();
            decrease_attempts();
            // Attempts_Counter.attempts--;
            // Destroy(gameObject);
            // reset_player_position();
            // death_option();
        }


        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
        }


        if (collision.gameObject.CompareTag("falling1"))
        {
            isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
        }
        if (collision.gameObject.CompareTag("falling2"))
        {
            isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
        }
        if (collision.gameObject.CompareTag("falling3"))
        {
            isGrounded = true;
            // moveForce = 10f;
            // transform.localScale = originalSize;
        }

        if (collision.gameObject.CompareTag("Spike"))
        {

            // d.IncreaseDeath();
            // Destroy(gameObject);
            d.IncreaseDeathBySpikes();

            // reset_player_position();
            decrease_attempts();

            // death_option();
            // reset_player_position();

        }
        if (collision.gameObject.CompareTag("Spring"))
        {
            d.IncreaseSpringUsed();
        }
        if (collision.gameObject.CompareTag("Saw"))
        {


            // d.IncreaseDeath();
            d.IncreaseDeathBySaw();
            decrease_attempts();
            // death_option();
            // reset_player_position();
        }
        if (collision.gameObject.CompareTag("Pool"))
        {
            // moveForce = 5f;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // d.IncreaseDeath();
            d.IncreaseDeathByEnemy();

            decrease_attempts();

            // death_option();
            // reset_player_position();
        }
        if (collision.gameObject.CompareTag("Rope2D"))
        {
            RopeControl.fix = true;
            RopeControl.coll = collision;
            // transform.localScale = originalSize;
            d.IncreaseRope();
        }
        if (collision.gameObject.CompareTag("Spear"))
        {
            // d.IncreaseDeath();
            d.IncreaseDeathBySpear();
            decrease_attempts();
            // death_option();

            // reset_player_position();
        }
        if (collision.gameObject.CompareTag("Explosives"))
        {
            // d.IncreaseDeath();
            d.IncreaseDeathByExplosive();
            decrease_attempts();
            // death_option();

            // reset_player_position();
        }
        if (collision.gameObject.CompareTag("upper_block"))
        {
            // d.IncreaseDeath();
            d.IncreaseDeathByCrusher();
            decrease_attempts();
            // death_option();

            // reset_player_position();

        }
        if (collision.gameObject.CompareTag("invisible"))
        {

            if (win_flag)
            {
                collision.gameObject.SetActive(false);
            }

        }

        if (win_flag)
        {
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("FlyingMonster"))
        {
            Debug.Log("Decrease health by flying monster");
            d.IncreaseDeathByFlyingMonster();
            decrease_attempts();
            // death_option();

            // reset_player_position();
        }


    }

    // slope behaviour not intended.
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if(collision.gameObject.CompareTag("slippery_slope"))
    //     {
    //         moveForce = 15f;
    //     }
    // }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("slippery_slope"))
        {
            bosting = true;
            moveForce = 25f;
            Debug.Log("on slope");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Dhruvit's code start

        // if (collision.gameObject.tag == "pillar_1")
        // {

        //     // myText.SetActive(false);
        //     // myText2.SetActive(true);

        // }


        // if (collision.gameObject.tag == "pillar_2")
        // {

        //     // myText2.SetActive(false);
        //     // myText8.SetActive(false);

        // }


        // if (collision.gameObject.tag == "pillar_3")
        // {

        //     // myText3.SetActive(true);

        // }


        // if (collision.gameObject.tag == "pillar_4")
        // {

        //     // myText3.SetActive(false);
        //     // myText4.SetActive(true);

        // }

        // if (collision.gameObject.tag == "pillar_5")
        // {

        //     // myText4.SetActive(false);
        //     // myText5.SetActive(true);
        //     // myText8.SetActive(false);
        //     // myText2.SetActive(false);
        // }

        // if (collision.gameObject.tag == "pillar_6")
        // {

        //     // myText5.SetActive(false);

        // }

        // if (collision.gameObject.tag == "pillar_7")
        // {

        //     // myText6.SetActive(true);
        //     // myText5.SetActive(false);
        //     // myText4.SetActive(false);
        //     // myText3.SetActive(false);

        // }

        // if (collision.gameObject.tag == "pillar_8")
        // {

        //     // myText6.SetActive(false);

        // }

        // if (collision.gameObject.tag == "pillar_9")
        // {

        //     myText7.SetActive(true);

        // }

        // if (collision.gameObject.tag == "pillar_10")
        // {

        //     // myText3.SetActive(false);

        // }

        // if (collision.gameObject.tag == "pillar_11")
        // {

        //     // myText8.SetActive(true);
        //     // Jetpack_on.jetpack.SetActive(false);
        //     // myText2.SetActive(false);

        // }
        //Dhruvit's code end

















        // if (collision.gameObject.CompareTag("setEvery"))
        // {


        //     GameObject[] healths = GameObject.FindGameObjectsWithTag("health_1");
        //     foreach (GameObject health in healths)
        //     {
        //         health.GetComponent<SpriteRenderer>().enabled = true;
        //     }
        // }
        // if (collision.gameObject.CompareTag("freez"))
        // {
        //     // get the sprite renderer of red and blue blocks and set the color to white 
        //     //after 5 seconds set the color to red and blue again

        //     GameObject[] red_blocks = GameObject.FindGameObjectsWithTag("Red_block");
        //     foreach (GameObject red_block in red_blocks)
        //     {
        //         red_block.GetComponent<SpriteRenderer>().color = Color.white;
        //     }
        //     GameObject[] blue_blocks = GameObject.FindGameObjectsWithTag("Blue_block");
        //     foreach (GameObject blue_block in blue_blocks)
        //     {
        //         blue_block.GetComponent<SpriteRenderer>().color = Color.white;
        //     }
        //     safemode = true;
        //     Timer.danger_time = false;
        //     store_blue_state = Timer.blue_safe;
        //     store_green_state = Timer.green_safe;

        // }
        if (collision.gameObject.CompareTag("checkpoint"))
        {
            checkpointReached = true;
            // store the position of the checkpoint in the checkpointPosition variable by creating a new Vector3 object
            checkpointPosition = new Vector3(transform.position.x + 8, transform.position.y, transform.position.z);
            //store the attempts left
            attemps_record = Attempts_Counter.attempts;
            timeLeft = levelTimer.timer;
            // set the jet pack left to the current jet pack left
            jetPackLeft = Movement.elapsedTime;
            timer_jetpack = TimeLeft.ScoreValue;
            jetpackduration1 = Movement.jetpackDuration;

        }

        if (collision.gameObject.CompareTag("slippery_slope"))
        {
            bosting = true;
            moveForce = 25f;
            Debug.Log("on slope");
        }

        if (collision.gameObject.CompareTag("Laser"))
        {
            d.IncreaseDeathByLaser();
            Debug.Log("Laser");
            decrease_attempts();
        }
        if (collision.gameObject.CompareTag("set_push_flag"))
        {
            Debug.Log("set_push_flag");
            Movement.jetpackDuration = 1.5f;
            Movement.push_force = true;
        }
        if (collision.gameObject.CompareTag("players_path"))
        {
            // declare a 2d array and store the x and y coordinates of the player
            // then store the coordinates in the array
            d.players_path(transform.position.x, transform.position.y);

            // Debug.Log(coordinates_list.Count);
            // Debug.Log("x: " + coordinates.x + " y: " + coordinates.y);
            // ispath_recorded = true;
        }
        if (collision.gameObject.CompareTag("Success_spring"))
        {
            d.IncreaseSpringUsedCntSuccess();
        }
        if (collision.gameObject.CompareTag("Success_rope"))
        {
            d.IncreaseRopeUsedCntSuccess();
        }
        if (collision.gameObject.CompareTag("Success_teleport"))
        {
            d.IncreaseTeleporterUsedCntSuccess();
        }
        if (collision.gameObject.CompareTag("Success_jetpack") && Movement.isJetpacking)
        {
            d.IncreaseJetpackUsedCntSuccess();
        }
        if (collision.gameObject.CompareTag("Push_button"))
        {
            // disappear the wall with tag "blokage"
            pushflag = true;
        }

        if (collision.gameObject.CompareTag("Set_Flags"))
        {
            flagss = true;
            GameObject falling1 = GameObject.FindWithTag("falling1");
            Rigidbody2D rb = falling1.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            falling1.transform.position = new Vector2(82.0246f, -10.2f);

            GameObject falling2 = GameObject.FindWithTag("falling2");
            Rigidbody2D rb2 = falling2.GetComponent<Rigidbody2D>();
            rb2.bodyType = RigidbodyType2D.Kinematic;
            falling2.transform.position = new Vector2(87.33f, -8.01f);

            GameObject falling3 = GameObject.FindWithTag("falling3");
            Rigidbody2D rb3 = falling3.GetComponent<Rigidbody2D>();
            rb3.bodyType = RigidbodyType2D.Kinematic;
            falling3.transform.position = new Vector2(93.09f, -5.84f);

            print("flagss");
        }
        try
        {
            if (collision.gameObject.CompareTag("Gate1"))
            {
                // below is the code to move the player to the next x,y position. set the x,y to the position you want the player to move to.
                playerTransform.position = new Vector2(142.1f, 30.72f); // updated 
                d.IncreaseTeleporterUsed();
            }
            // if (collision.gameObject.CompareTag("Gate1"))
            // {
            //     // below is the code to move the player to the next x,y position. set the x,y to the position you want the player to move to.
            //     playerTransform.position = new Vector2(60f, -2.6f);

            // }
            if (collision.gameObject.CompareTag("Gate2"))
            {
                // below is the code to move the player to the next x,y position. set the x,y to the position you want the player to move to.

                d.IncreaseTeleporterUsed();
                playerTransform.position = new Vector2(90.07f, -14.01f); // updated

            }
            if (collision.gameObject.CompareTag("Gate3"))
            {
                // below is the code to move the player to the next x,y position. set the x,y to the position you want the player to move to.
                playerTransform.position = new Vector2(133.3f, -15.6f);
                d.IncreaseTeleporterUsed();
            }
            if (collision.gameObject.CompareTag("Gate4"))
            {
                playerTransform.position = new Vector2(105.751f, 28.0f);
                d.IncreaseTeleporterUsed();
            }

            // sp_level
            if (collision.gameObject.CompareTag("sp_tel_8"))
            {
                playerTransform.position = new Vector2(206.6f, -15.4f);
                d.IncreaseTeleporterUsed();
            }
            if (collision.gameObject.CompareTag("sp_tel_7"))
            {
                playerTransform.position = new Vector2(117.2f, -83.6f);
                d.IncreaseTeleporterUsed();
            }
            if (collision.gameObject.CompareTag("sp_tel_6"))
            {
                playerTransform.position = new Vector2(26.3f, -35.9f);
                d.IncreaseTeleporterUsed();
            }
            if (collision.gameObject.CompareTag("sp_tel_5"))
            {
                playerTransform.position = new Vector2(125.86f, -35.2f);
                d.IncreaseTeleporterUsed();
            }
            if (collision.gameObject.CompareTag("sp_tel_4"))
            {
                playerTransform.position = new Vector2(117.3f, 52.6f);
                d.IncreaseTeleporterUsed();
            }
            if (collision.gameObject.CompareTag("sp_tel_3"))
            {
                playerTransform.position = new Vector2(68.2f, -2.7f);
                d.IncreaseTeleporterUsed();
            }
            if (collision.gameObject.CompareTag("sp_tel_2"))
            {
                playerTransform.position = new Vector2(139.5f, -2.7f);
                d.IncreaseTeleporterUsed();
            }
            if (collision.gameObject.CompareTag("sp_tel_1"))
            {
                playerTransform.position = new Vector2(93.9f, 53.1f);
            }
            if (collision.gameObject.CompareTag("ap_level_gate1"))
            {
                playerTransform.position = new Vector2(128.12f, 70.819f);
                d.IncreaseTeleporterUsed();
            }
            if (collision.gameObject.CompareTag("ap_level_gate2"))
            {
                playerTransform.position = new Vector2(-44.1961f, 121.6182f);
                d.IncreaseTeleporterUsed();
            }

        }
        catch (Exception e)
        {
            print(e);
        }

        if (collision.gameObject.CompareTag("Points"))
        {

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Outbound"))
        {

            // d.IncreaseDeath();
            if (button_trigger.checkpointReached)
            {
                reset_player_position_to_checkpoint();
            }
            else
            {
                d.IncreaseDeathByFalling();
                d.IncreaseDeathLocationOfPlayer(playerTransform.position.x, playerTransform.position.y);
                death_option();
                reset_player_position();
            }
            // d.IncreaseDeathByFalling();
            // d.IncreaseDeathLocationOfPlayer(playerTransform.position.x, playerTransform.position.y);
            // death_option();
            // reset_player_position();
        }
        if (collision.gameObject.CompareTag("falling_bombs"))
        {
            decrease_attempts();
            Destroy(collision.gameObject);
        }

        // if (collision.gameObject.CompareTag("F"))
        // {
        //     Destroy(collision.gameObject);
        //     // check if element not in set
        //     if (!hs.Contains("F"))
        //     {
        //         hs.Add("F");
        //     }
        //     Alphabets_Swaner.ind = 2;
        //     // count++;
        //     Alphabets_Swaner.flag = true;
        //     GameObject[] FL = GameObject.FindGameObjectsWithTag("F_L");
        //     SpriteRenderer sr = FL[0].GetComponent<SpriteRenderer>();
        //     sr.enabled = true;

        //     // Alphabets_Swaner.Alphabets[GameObject.Find("F").GetComponent<Alphabets_Swaner>().index()].SetActive(false);
        // }
        // if (collision.gameObject.CompareTag("I"))
        // {
        //     if (!hs.Contains("I"))
        //     {
        //         hs.Add("I");
        //     }
        //     Destroy(collision.gameObject);
        //     Alphabets_Swaner.ind = 4;
        //     // count++;
        //     Alphabets_Swaner.flag = true;
        //     GameObject[] IL = GameObject.FindGameObjectsWithTag("I_L");
        //     SpriteRenderer sr = IL[0].GetComponent<SpriteRenderer>();
        //     sr.enabled = true;
        // }
        // if (collision.gameObject.CompareTag("R"))
        // {
        //     if (!hs.Contains("R"))
        //     {
        //         hs.Add("R");
        //     }
        //     Destroy(collision.gameObject);
        //     Alphabets_Swaner.ind = 3;
        //     // count++;
        //     Alphabets_Swaner.flag = true;
        //     GameObject[] RL = GameObject.FindGameObjectsWithTag("R_L");
        //     SpriteRenderer sr = RL[0].GetComponent<SpriteRenderer>();
        //     sr.enabled = true;
        // }
        // if (collision.gameObject.CompareTag("E"))
        // {
        //     if (!hs.Contains("E"))
        //     {
        //         hs.Add("E");
        //     }
        //     Destroy(collision.gameObject);
        //     Alphabets_Swaner.ind = 1;
        //     // count++;
        //     Alphabets_Swaner.flag = true;
        //     GameObject[] EL = GameObject.FindGameObjectsWithTag("E_L");
        //     SpriteRenderer sr = EL[0].GetComponent<SpriteRenderer>();
        //     sr.enabled = true;
        // }
        // if (collision.gameObject.CompareTag("A"))
        // {
        //     Destroy(collision.gameObject);
        //     Alphabets_Swaner.ind = 0;
        //     attemps++;
        //     Alphabets_Swaner.flag = true;
        // }
        // if (collision.gameObject.CompareTag("U"))
        // {
        //     Destroy(collision.gameObject);
        //     Alphabets_Swaner.ind = 5;
        //     attemps++;
        //     Alphabets_Swaner.flag = true;
        // }
        // if (collision.gameObject.CompareTag("detect"))
        // {
        //     // intiater = true;
        //     if (flagd == 0)
        //     {
        //         TextBox1.enabled = true;
        //         TextBox2.enabled = true;
        //         flagd = 1;
        //     }
        //     else if (flagd == 1)
        //     {
        //         TextBox1.enabled = false;
        //         TextBox2.enabled = false;
        //         flagd = 0;
        //     }
        //     if (flagw == 1)
        //     {
        //         TextBox3.enabled = false;
        //         flagw = 0;
        //     }
        //     if (flagt == 1)
        //     {
        //         TextBox1.enabled = false;
        //         TextBox2.enabled = false;
        //     }
        // }
        // if (collision.gameObject.CompareTag("exit"))
        // {
        //     TextBox1.enabled = false;
        //     TextBox2.enabled = false;
        //     TextBox3.enabled = false;
        // }

        if (collision.gameObject.CompareTag("button_trigger"))
        {
            d.IncreaseButtonUsed();
        }

        if (collision.gameObject.CompareTag("Ladder"))
        {
            d.IncreaseLadderUsed();
        }

        // if (collision.gameObject.CompareTag("jetpack_trigger")){
        //     d.IncreaseButtonUsed();
        // }

        // if (collision.gameObject.CompareTag("Finish"))
        // {

        //     death_option();
        //     reset_player_position();
        // }


        // if (collision.gameObject.CompareTag("F"))
        // {
        //     Destroy(collision.gameObject);
        //     // check if element not in set
        //     if (!hs.Contains("F")){
        //         hs.Add("F");
        //     }
        //     Alphabets_Swaner.ind = 2;
        //     // count++;
        //     Alphabets_Swaner.flag = true;
        //     GameObject[] FL = GameObject.FindGameObjectsWithTag("F_L");
        //     SpriteRenderer sr = FL[0].GetComponent<SpriteRenderer>();
        //     sr.enabled = true;

        //     // Alphabets_Swaner.Alphabets[GameObject.Find("F").GetComponent<Alphabets_Swaner>().index()].SetActive(false);
        // }
        // if (collision.gameObject.CompareTag("I"))
        // {
        //     if (!hs.Contains("I")){
        //         hs.Add("I");
        //     }
        //     Destroy(collision.gameObject);
        //     Alphabets_Swaner.ind = 4;
        //     // count++;
        //     Alphabets_Swaner.flag = true;
        //     GameObject[] IL = GameObject.FindGameObjectsWithTag("I_L");
        //     SpriteRenderer sr = IL[0].GetComponent<SpriteRenderer>();
        //     sr.enabled = true;
        // }
        // if (collision.gameObject.CompareTag("R"))
        // {
        //     if (!hs.Contains("R")){
        //         hs.Add("R");
        //     }
        //     Destroy(collision.gameObject);
        //     Alphabets_Swaner.ind = 3;
        //     // count++;
        //     Alphabets_Swaner.flag = true;
        //     GameObject[] RL = GameObject.FindGameObjectsWithTag("R_L");
        //     SpriteRenderer sr = RL[0].GetComponent<SpriteRenderer>();
        //     sr.enabled = true;
        // }
        // if (collision.gameObject.CompareTag("E"))
        // {
        //     if (!hs.Contains("E")){
        //         hs.Add("E");
        //     }
        //     Destroy(collision.gameObject);
        //     Alphabets_Swaner.ind = 1;
        //     // count++;
        //     Alphabets_Swaner.flag = true;
        //     GameObject[] EL = GameObject.FindGameObjectsWithTag("E_L");
        //     SpriteRenderer sr = EL[0].GetComponent<SpriteRenderer>();
        //     sr.enabled = true;
        // }
        // if (collision.gameObject.CompareTag("A"))
        // {
        //     Destroy(collision.gameObject);
        //     Alphabets_Swaner.ind = 0;
        //     attemps++;
        //     Alphabets_Swaner.flag = true;
        // }
        // if (collision.gameObject.CompareTag("U"))
        // {
        //     Destroy(collision.gameObject);
        //     Alphabets_Swaner.ind = 5;
        //     attemps++;
        //     Alphabets_Swaner.flag = true;
        // }
        // if (collision.gameObject.CompareTag("detect"))
        // {
        //     // intiater = true;
        //     if(flagd==0){
        //         TextBox1.enabled = true;
        //         TextBox2.enabled = true;
        //         flagd = 1;
        //     }
        //     else if(flagd==1){
        //         TextBox1.enabled = false;
        //         TextBox2.enabled = false;
        //         flagd = 0;
        //     }
        //     if(flagw==1){
        //         TextBox3.enabled = false;
        //         flagw = 0;
        //     }
        //     if(flagt==1){
        //         TextBox1.enabled = false;
        //         TextBox2.enabled = false;
        //     }
        // }
        // if (collision.gameObject.CompareTag("exit"))
        // {
        //     TextBox1.enabled = false;
        //     TextBox2.enabled = false;
        //     TextBox3.enabled = false;
        // }

        if (collision.gameObject.CompareTag("Finish"))
        {
            perfect_jumps = 0;
            checkpointReached = false;
            Movement.elapsedTime = 0f;
            Movement.jetpackDuration = 1.5f;
            Movement.resumeJetpack = false;
            Movement.resume1 = false;
            Movement.stopit = true;
            Movement.push_force = true;
            Movement.isJetpacking = false;
            blink_blue = false;
            blink_green = false;
            d.IncreaseDeath();
            d.IncreaseIsLevelCompleted();
            d.IncreaseTimeToCompleteLevel((int)Time.time - time_start);
            //             PlayerDied(System.DateTime.Now.Ticks.ToString(), d.death.ToString(), d.death_by_saw.ToString(), d.death_by_spikes.ToString(), d.death_by_enemy.ToString(), d.death_by_spear.ToString(), d.death_by_explosive.ToString(), d.death_by_crusher.ToString(), d.time_to_complete_level.ToString(), d.death_by_falling.ToString(), d.death_by_puzzle.ToString(), SceneManager.GetActiveScene().buildIndex.ToString(),
            // d.spring_used.ToString(), d.button_used.ToString(), d.ladder_used.ToString(), d.jetpack.ToString(), d.rope.ToString(), d.teleporter_used.ToString());
            // Debug.Log(d.red_safe_standing_time.ToString());
            // Debug.Log(d.blue_safe_standing_time.ToString());
            // Debug.Log(d.red_unsafe_standing_time.ToString());
            // Debug.Log(d.blue_unsafe_standing_time.ToString());
            Debug.Log(greensafestandingtime);
            Debug.Log(greenunsafestandingtime);
            Debug.Log(bluesafestandingtime);
            Debug.Log(blueunsafestandingtime);

            PlayerDied(System.DateTime.Now.Ticks.ToString(), d.death.ToString(), d.death_by_saw.ToString(), d.death_by_spikes.ToString(),
            d.death_by_enemy.ToString(), d.death_by_spear.ToString(), d.death_by_explosive.ToString(), d.death_by_crusher.ToString(),
            d.time_to_complete_level.ToString(), d.death_by_falling.ToString(), d.death_by_puzzle.ToString(),
            SceneManager.GetActiveScene().buildIndex.ToString(), d.spring_used.ToString(), d.button_used.ToString(),
            d.ladder_used.ToString(), d.jetpack.ToString(), d.rope.ToString(), d.teleporter_used.ToString(),
            Math.Round(greensafestandingtime, 0).ToString(), Math.Round(bluesafestandingtime, 0).ToString(),
            Math.Round(greenunsafestandingtime, 0).ToString(), Math.Round(blueunsafestandingtime, 0).ToString(),
            d.jetpack_used_cnt_success.ToString(), d.rope_used_cnt_success.ToString(), d.spring_used_cnt_success.ToString(),
            d.teleporter_used_cnt_success.ToString(), Attempts_Counter.attempts.ToString(), d.death_location_of_player,
            d.is_timeout.ToString(), d.is_level_completed.ToString(), d.player_path, d.unsafe_platform_coordinates,
            d.death_by_laser.ToString());

            // Debug.Log("Completed");


            // LoadNextLevel();
        }
    }


    // below function is used to reset the player position to the position of checkpoint if checkpoint is not null
    private void reset_player_position_to_checkpoint()
    {
        playerTransform.position = checkpointPosition;
        Attempts_Counter.attempts = attemps_record;
        levelTimer1.timer = timeLeft;
        Movement.elapsedTime = jetPackLeft;
        TimeLeft.ScoreValue = timer_jetpack;
        Movement.jetpackDuration = jetpackduration1;
        Debug.Log("b_ Movement.elapsedTime: " + Movement.elapsedTime);
        Movement.resumeJetpack = false;
        Movement.resume1 = false;
        Movement.stopit = true;
        Movement.push_force = true;
        Movement.isJetpacking = false;
    }

    private void reset_player_position()
    {
        // textbox_disabler();
        // get current player position
        // d.IncreaseDeathLocationOfPlayer(playerTransform.position.x, playerTransform.position.y);
        playerTransform.position = new Vector2(-59.3f, -18.8f);
        TimeLeft.ScoreValue = 1.5f;
        Timer.timeleft = 0;
        Timer.resetCounter = true;
        Movement.jetpackDuration = 1.5f;
        Movement.jetpackForce = 10f;
        Movement.elapsedTime = 0f;
        Movement.isJetpacking = false;
        Movement.isGrounded = true;
        Attempts_Counter.attempts = 5;
        levelTimerScript.resetTimer();

        // if (SceneManager.GetActiveScene().buildIndex == 2)
        // {
        //circle.position = new Vector2(38.17f, 11.64f);
        // square.position = new Vector2(36.83f, 5.1f);
        //GameObject.FindGameObjectWithTag("invisible_moving_platform").SetActive(false);
        // invisible_platform_mov

        // }



    }


    private void death_option()
    {
        Time.timeScale = 0;
        // GameObject panelObject = GameObject.Find("Panel");
        // Panel panel = panelObject.GetComponent<Panel>();
        myBody.velocity = Vector2.zero;
        print("Death");
        play_again_panel.SetActive(true);
        Attempts_Counter.attempts = 5;
        myBody.gravityScale = 1;

    }

    private void Player_life_reset()
    {
        Attempts_Counter.attempts = 5;
    }



    // Google Form

    [SerializeField] private string URL;

    private string _sessionID;
    private string _number_of_attempts;
    private string _saw;
    private string _spike;
    private string _enemy;
    private string _spear;
    private string _explosives;
    private string _crusher;
    private string _falling;
    private string _death_by_puzzle;
    private string _time_to_complete_level;
    private string _level;
    private string _spring_used;
    private string _button_used;
    private string _ladder_used;
    private string _jetpack_used;
    private string _rope_used;
    private string _teleport_used;

    private string _red_safe_standing_time;
    private string _blue_safe_standing_time;
    private string _red_unsafe_standing_time;
    private string _blue_unsafe_standing_time;

    private string _jetpack_used_cnt_success;

    private string _rope_used_cnt_success;

    private string _spring_used_cnt_success;

    private string _teleport_used_cnt_success;

    private string _number_of_attempts_left;
    private string _death_location_of_player;
    private string _is_timeout;

    private string _is_level_completed;
    private string _player_path;

    private string _unsafe_platoform_cooridantes;

    private string _death_by_laser;
    // private void Awake()
    // {
    //     _sessionID = System.DateTime.Now.Ticks;

    // }

    public void PlayerDied(string session, string attempts, string saw, string spike, string enemy, string spear,
    string explosives, string crusher, string time_to_complete_level, string falling, string death_by_puzzle,
    string level, string spring_used, string button_used, string ladder_used, string jetpack_used, string rope_used,
    string teleport_used, string red_safe_standing_time, string blue_safe_standing_time, string red_unsafe_standing_time,
    string blue_unsafe_standing_time, string jetpack_used_cnt_success, string rope_used_cnt_success,
    string spring_used_cnt_success, string teleport_used_cnt_success, string number_of_attempts_left,
    string death_location_of_player, string is_timeout, string is_level_completed, string player_path, string unsafe_platoform_cooridantes,
    string death_by_laser)

    {
        _sessionID = session;
        _number_of_attempts = attempts;
        _saw = saw;
        _spike = spike;
        _enemy = enemy;
        _spear = spear;
        _explosives = explosives;
        _crusher = crusher;
        _falling = falling;
        _death_by_puzzle = death_by_puzzle;
        _time_to_complete_level = time_to_complete_level;
        _level = level;
        _spring_used = spring_used;
        _button_used = button_used;
        _ladder_used = ladder_used;
        _jetpack_used = jetpack_used;
        _rope_used = rope_used;
        _teleport_used = teleport_used;
        _red_safe_standing_time = red_safe_standing_time;
        _blue_safe_standing_time = blue_safe_standing_time;
        _red_unsafe_standing_time = red_unsafe_standing_time;
        _blue_unsafe_standing_time = blue_unsafe_standing_time;
        _jetpack_used_cnt_success = jetpack_used_cnt_success;
        _rope_used_cnt_success = rope_used_cnt_success;
        _spring_used_cnt_success = spring_used_cnt_success;
        _teleport_used_cnt_success = teleport_used_cnt_success;
        _number_of_attempts_left = number_of_attempts_left;
        _death_location_of_player = death_location_of_player;
        _is_timeout = is_timeout;
        _is_level_completed = is_level_completed;
        _player_path = player_path;
        _unsafe_platoform_cooridantes = unsafe_platoform_cooridantes;
        _death_by_laser = death_by_laser;
        StartCoroutine(Post());
    }

    public void number_of_attempt()
    {
        _number_of_attempts += 1;
        Debug.Log(_number_of_attempts);
    }

    private IEnumerator Post()
    {

        WWWForm form = new WWWForm();
        form.AddField("entry.1873251736", _sessionID);
        form.AddField("entry.202336478", _player_path);
        form.AddField("entry.184508093", _number_of_attempts);
        form.AddField("entry.1811764899", _saw);
        form.AddField("entry.1524214175", _spike);
        form.AddField("entry.667379507", _enemy);
        form.AddField("entry.872293039", _spear);
        form.AddField("entry.739396312", _explosives);
        form.AddField("entry.995108995", _crusher);
        form.AddField("entry.787260575", _falling);
        form.AddField("entry.964640412", _time_to_complete_level);
        // form.AddField("entry.1713570514", _death_by_puzzle);
        form.AddField("entry.1850271904", _level);
        form.AddField("entry.441471285", _spring_used);
        form.AddField("entry.1490520637", _button_used);
        form.AddField("entry.2141273141", _ladder_used);
        form.AddField("entry.477381647", _jetpack_used);
        form.AddField("entry.2133737579", _rope_used);
        form.AddField("entry.1240977175", _teleport_used);

        form.AddField("entry.1036195061", _red_safe_standing_time);
        form.AddField("entry.1400961872", _red_unsafe_standing_time);
        form.AddField("entry.452285488", _blue_safe_standing_time);
        form.AddField("entry.129586789", _blue_unsafe_standing_time);

        form.AddField("entry.742555134", _jetpack_used_cnt_success);
        form.AddField("entry.1730045103", _rope_used_cnt_success);
        form.AddField("entry.20066052", _spring_used_cnt_success);
        form.AddField("entry.581539510", _teleport_used_cnt_success);

        form.AddField("entry.1764859169", _number_of_attempts_left);
        form.AddField("entry.141782581", _death_location_of_player);
        form.AddField("entry.1094196752", _is_timeout);

        form.AddField("entry.1492178500", _is_level_completed);
        form.AddField("entry.14083175", _unsafe_platoform_cooridantes);

        form.AddField("entry.607956081", _death_by_laser);

        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            d.ResetDeath();
            Player_life_reset();
            LoadNextLevel();
        }
        else
        {
            Debug.Log("Data sent successfully");
            d.ResetDeath();
            Player_life_reset();
            LoadNextLevel();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



    //  Load next level

    public void LoadNextLevel()
    {
        Destroy(playerTransform);
        player_set_color_green();
        reset_level_timer = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Timer.danger_time = true;
        Timer.green_safe = true;
        Timer.blue_safe = false;
        blink_blue = false;
        blink_green = false;
    }

    // make player sprite green
    public void player_set_color_green()
    {
        sr.color = Color.green;
    }

    // make player sprite blue
    public void player_set_color_blue()
    {
        sr.color = blueColor;
    }
}

