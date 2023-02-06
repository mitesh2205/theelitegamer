using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

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
    public int time_start;
    // Start is called before the first frame update
    increment_death d;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        d = FindObjectOfType<increment_death>();
        time_start = (int)Time.deltaTime;

        // create a object of the class and call the function

        // s._sessionID = System.DateTime.Now.Ticks;
        // Debug.Log(s._sessionID);
         
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
            d.IncreaseDeath();
            // Destroy(gameObject);
            d.IncreaseDeathBySpikes();
            reset_player_position();
            

        }
        if (collision.gameObject.CompareTag("Saw"))
        {
            
            d.IncreaseDeath();
            d.IncreaseDeathBySaw();
            reset_player_position();
        }
        if (collision.gameObject.CompareTag("Pool"))
        {
            moveForce = 5f;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            d.IncreaseDeath();
            d.IncreaseDeathByEnemy();
            reset_player_position();
        }
        if (collision.gameObject.CompareTag("Rope2D"))
        {
            RopeControl.fix = true;
            RopeControl.coll = collision;
            transform.localScale = originalSize;
        }
        if (collision.gameObject.CompareTag("Spear"))
        {
            d.IncreaseDeath();
            d.IncreaseDeathBySpear();
            reset_player_position();
        }
        if (collision.gameObject.CompareTag("Explosives"))
        {
            d.IncreaseDeath();
            d.IncreaseDeathByExplosive();
            reset_player_position();
        }
        if (collision.gameObject.CompareTag("upper_block"))
        {
            d.IncreaseDeath();
            d.IncreaseDeathByCrusher();
            reset_player_position();
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

        if (collision.gameObject.CompareTag("Outbound"))
        {
            d.IncreaseDeath();
            d.IncreaseDeathByFalling();
            reset_player_position();
        }

        if (collision.gameObject.CompareTag("Finish")){
            d.IncreaseDeath();
            d.IncreaseTimeToCompleteLevel((int)Time.time - time_start);
            PlayerDied(System.DateTime.Now.Ticks.ToString(), d.death.ToString(), d.death_by_saw.ToString(), d.death_by_spikes.ToString(), d.death_by_enemy.ToString(), d.death_by_spear.ToString(), d.death_by_explosive.ToString(), d.death_by_crusher.ToString(), d.time_to_complete_level.ToString(), d.death_by_falling.ToString());
            // Debug.Log("Completed");
        }
    }

    private void reset_player_position(){
        playerTransform.position = new Vector2(-12f, -8.6f);
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
    private string _time_to_complete_level;


    // private void Awake()
    // {
    //     _sessionID = System.DateTime.Now.Ticks;

    // }

    public void PlayerDied(string session, string attempts, string saw, string spike, string enemy, string spear, string explosives, string crusher, string time_to_complete_level , string falling)
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
        _time_to_complete_level = time_to_complete_level;

        StartCoroutine(Post());
    }

    public void number_of_attempt(){
        _number_of_attempts += 1;
        Debug.Log(_number_of_attempts);
    }

    private IEnumerator Post()
    {
        
       WWWForm form = new WWWForm();
        form.AddField("entry.1873251736", _sessionID); 
        form.AddField("entry.184508093", _number_of_attempts); 
        form.AddField("entry.1811764899", _saw);
        form.AddField("entry.1524214175", _spike);
        form.AddField("entry.667379507", _enemy);
        form.AddField("entry.872293039", _spear);
        form.AddField("entry.739396312", _explosives);
        form.AddField("entry.995108995", _crusher);
        form.AddField("entry.787260575", _falling);
        form.AddField("entry.964640412", _time_to_complete_level);

        
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Data sent successfully");
        }
    }

    // public void RestartLevel()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }

    

}
