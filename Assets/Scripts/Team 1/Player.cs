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

    public GameObject play_again_panel;
    public Transform circle;
    public Transform square;


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



    // hash set



    // Start is called before the first frame update
    increment_death d;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        d = FindObjectOfType<increment_death>();
        time_start = (int)Time.deltaTime;

        if (pause_menu.GameIsPaused)
        {
            pause_menu.GameIsPaused = false;
        }


        // create a object of the class and call the function

        // s._sessionID = System.DateTime.Now.Ticks;
        // Debug.Log(s._sessionID);

    }
    void Start()
    {
        playerTransform = transform;
        myBody.gravityScale = 1;
        print(myBody.gravityScale);
        print("gravity");
        // circle = transform.Find("rolling_circle");


    }

    // Update is called once per frame
    void Update()
    {
        // myBody.gravityScale = -2;

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
        if (attemps == 2)
        {
            d.IncreaseDeath();
            d.IncreaseDeathByPuzzle();
            print("You Lost");

            // textbox_disabler();
            attemps = 0;
            playerTransform.position = new Vector2(-12f, -8.6f);


            // textbox_disabler();
            attemps = 0;
            playerTransform.position = new Vector2(-12f, -8.6f);

        }
        // if (intiater)
        // {
        //     TextBox1.enabled = true;
        //     TextBox2.enabled = true;
        //     intiater = false;
        // }


        if (play_again_button.sendData == true)
        {
            play_again_button.sendData = false;
            // print("sending data");
            Debug.Log("sending data");
            d.IncreaseDeath();
            d.IncreaseTimeToCompleteLevel((int)Time.time - time_start);
             PlayerDied(System.DateTime.Now.Ticks.ToString(), d.death.ToString(), d.death_by_saw.ToString(), d.death_by_spikes.ToString(), d.death_by_enemy.ToString(), d.death_by_spear.ToString(), d.death_by_explosive.ToString(), d.death_by_crusher.ToString(), d.time_to_complete_level.ToString(), d.death_by_falling.ToString(), d.death_by_puzzle.ToString(), SceneManager.GetActiveScene().buildIndex.ToString(), 
d.spring_used.ToString(),d.button_used.ToString(),d.ladder_used.ToString(),d.jetpack.ToString(),d.rope.ToString(), d.teleporter_used.ToString());
        }
        else
        {
            // print("not sending data");
            // Debug.Log("not sending data");
            // play_again_panel.SetActive(false);
        }



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


        if (collision.gameObject.CompareTag("falling1"))
        {
            isGrounded = true;
            moveForce = 10f;
            transform.localScale = originalSize;
        }
        if (collision.gameObject.CompareTag("falling2"))
        {
            isGrounded = true;
            moveForce = 10f;
            transform.localScale = originalSize;
        }
        if (collision.gameObject.CompareTag("falling3"))
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

            circle.position = new Vector2(38.33f, 7.36f);
            square.position = new Vector2(36.83f, 5.1f);
            death_option();
            reset_player_position();
        }
        if (collision.gameObject.CompareTag("Spring"))
        {
            d.IncreaseSpringUsed();
        }
        if (collision.gameObject.CompareTag("Saw"))
        {


            d.IncreaseDeath();
            d.IncreaseDeathBySaw();

            d.IncreaseDeath();
            d.IncreaseDeathBySaw();
            death_option();

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

            death_option();

            reset_player_position();
        }
        if (collision.gameObject.CompareTag("Rope2D"))
        {
            RopeControl.fix = true;
            RopeControl.coll = collision;
            transform.localScale = originalSize;
            d.IncreaseRope();
        }
        if (collision.gameObject.CompareTag("Spear"))
        {
            d.IncreaseDeath();
            d.IncreaseDeathBySpear();

            death_option();

            reset_player_position();
        }
        if (collision.gameObject.CompareTag("Explosives"))
        {
            d.IncreaseDeath();
            d.IncreaseDeathByExplosive();

            death_option();

            reset_player_position();
        }
        if (collision.gameObject.CompareTag("upper_block"))
        {
            d.IncreaseDeath();
            d.IncreaseDeathByCrusher();

            death_option();

            reset_player_position();

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

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


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

        if (collision.gameObject.CompareTag("Gate1"))
        {
            // below is the code to move the player to the next x,y position. set the x,y to the position you want the player to move to.
            playerTransform.position = new Vector2(60f, 17f);
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


            playerTransform.position = new Vector2(41f, -5.619558f);

        }
        if (collision.gameObject.CompareTag("Points"))
        {

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Outbound"))
        {

            d.IncreaseDeath();
            d.IncreaseDeathByFalling();
            death_option();
            reset_player_position();
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

        if (collision.gameObject.CompareTag("button_trigger")){
            d.IncreaseButtonUsed();
        }

        if (collision.gameObject.CompareTag("Ladder")){
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

            d.IncreaseDeath();
            d.IncreaseTimeToCompleteLevel((int)Time.time - time_start);
             PlayerDied(System.DateTime.Now.Ticks.ToString(), d.death.ToString(), d.death_by_saw.ToString(), d.death_by_spikes.ToString(), d.death_by_enemy.ToString(), d.death_by_spear.ToString(), d.death_by_explosive.ToString(), d.death_by_crusher.ToString(), d.time_to_complete_level.ToString(), d.death_by_falling.ToString(), d.death_by_puzzle.ToString(), SceneManager.GetActiveScene().buildIndex.ToString(), 
d.spring_used.ToString(),d.button_used.ToString(),d.ladder_used.ToString(),d.jetpack.ToString(),d.rope.ToString(), d.teleporter_used.ToString());
            LoadNextLevel();
            // Debug.Log("Completed");
        }
    }


    private void reset_player_position()
    {
        // textbox_disabler();

        playerTransform.position = new Vector2(-12f, -8.6f);

    }


    // private void textbox_disabler()
    // {
    //     TextBox1.enabled = false;
    //     TextBox2.enabled = false;
    //     TextBox3.enabled = false;
    // }



    // private void textbox_disabler(){
    //     TextBox1.enabled = false;
    //     TextBox2.enabled = false;
    //     TextBox3.enabled = false;
    // }

    private void death_option()
    {
        Time.timeScale = 0;
        // GameObject panelObject = GameObject.Find("Panel");
        // Panel panel = panelObject.GetComponent<Panel>();
        print("Death");
        play_again_panel.SetActive(true);

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


    // private void Awake()
    // {
    //     _sessionID = System.DateTime.Now.Ticks;

    // }

    public void PlayerDied(string session, string attempts, string saw, string spike, string enemy, string spear, string explosives, string crusher, string time_to_complete_level , string falling, string death_by_puzzle, string level, string spring_used, string button_used, string ladder_used, string jetpack_used, string rope_used, string teleport_used)
    
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
        // form.AddField("entry.1713570514", _death_by_puzzle);
        form.AddField("entry.1850271904", _level);
        form.AddField("entry.441471285", _spring_used);
        form.AddField("entry.1490520637", _button_used);
        form.AddField("entry.2141273141", _ladder_used);
        form.AddField("entry.477381647", _jetpack_used);
        form.AddField("entry.2133737579", _rope_used);
        form.AddField("entry.1240977175", _teleport_used);
        
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

    //  Load next level

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
