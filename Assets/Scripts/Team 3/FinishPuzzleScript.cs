using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPuzzleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int totalPieces = 16;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (totalPieces == 0){
            Destroy(gameObject);
        }
        
    }
}
