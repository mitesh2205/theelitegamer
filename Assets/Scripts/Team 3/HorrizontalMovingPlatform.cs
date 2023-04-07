using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrizontalMovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform startPosition;
    public Transform endPosition;
    public float speed = 1.5f;
    int direction = 1;
    private void Update()
    {
        Vector2 target = GetDirection();
        platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);
        float distance = (target - (Vector2)platform.position).magnitude;
        if (distance <= 0.1f){
            direction *= -1;
        }
        
    }

    private Vector2 GetDirection()
    {
        if (direction == 1){
            return startPosition.position;
        }
        else{
            return endPosition.position;
        }
    }

    // Update is called once per frame
   
}
