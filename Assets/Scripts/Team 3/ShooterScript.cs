using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject ball ;
    public Transform firepoint;
    public float bulletSpeed = 10f;
    public float playerSpeed = 20f;
    Vector2 direction;
    public float leftLimit;
    public float rightLimit;
    float cnt = 0;
    float angle;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        float horizontalMove = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right*horizontalMove*playerSpeed*Time.deltaTime);
        if(transform.position.x < leftLimit){
            transform.position = new Vector2(leftLimit, transform.position.y );
        }
        if(transform.position.y > rightLimit){
            transform.position = new Vector2(rightLimit, transform.position.y );
        }
        direction = Camera.main.WorldToScreenPoint(Input.mousePosition) - transform.position ;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90f;
        firepoint.rotation = Quaternion.Euler(0,0,angle);
        
        if (Input.GetMouseButtonDown(0)){
            
            if (cnt < 20){
                cnt = cnt+1;
                ScoreScript.scoreVal -= 1;
                GameObject ballClone = Instantiate(ball);
                ballClone.transform.position = firepoint.position;
                ballClone.transform.rotation =  Quaternion.Euler(0,0,angle);
                ballClone.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
                
            }
        }
    }
}
