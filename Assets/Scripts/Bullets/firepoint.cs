using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firepoint : MonoBehaviour
{
    public static Transform firePoint;
    public static int flag = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (flag == 1)
        {
            // firePoint.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
            // negate the x position of the firepoint
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        }
    }
    public static void fix()
    {
        flag = 1;
    }
    public static void unfix()
    {
        flag = 0;
    }
}
