// This script is attached to the player object and is used to control the player's movement on the rope and to jump off the rope.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RopeControl : MonoBehaviour
{
    public float swingForce = 2f;
    public float delayBeforeSecondHand = 0.4f;
    private static Transform collidedChain;
    private static List<Transform> chains;

    private Transform playerTransform;
    private int chainIndex = 0;
    private Collider2D[] colliders;
    private Player pControl;


    private bool onRope = false;
    // private float timer = 0.0f;
    private float direction;
    float dirX;

    public static bool fix = false;
    public static Collision2D coll;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        colliders = GetComponentsInChildren<Collider2D>();
        pControl = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (fix)
        {
            try
            {
                var joint = coll.gameObject.GetComponent<HingeJoint2D>();
                if (joint && joint.enabled)
                {
                    pControl.enabled = false;

                    foreach (var col in colliders)
                        col.enabled = false;

                    var chainParent = coll.transform.parent;
                    chains = new List<Transform>();
                    foreach (Transform chain in chainParent)
                    {
                        chains.Add(chain);
                    }

                    collidedChain = coll.transform;
                    chainIndex = chains.IndexOf(collidedChain);
                    playerTransform.parent = collidedChain;
                    onRope = true;

                    direction = Mathf.Sign(Vector3.Dot(collidedChain.right, Vector3.up));
                    fix = false;
                }
            }
            catch (System.Exception)
            {
                
                Debug.Log("Error");
            }

            // var joint = coll.gameObject.GetComponent<HingeJoint2D>();
            // if (joint && joint.enabled)
            // {
            //     pControl.enabled = false;

            //     foreach (var col in colliders)
            //         col.enabled = false;

            //     var chainParent = coll.transform.parent;
            //     chains = new List<Transform>();
            //     foreach (Transform chain in chainParent)
            //     {
            //         chains.Add(chain);
            //     }

            //     collidedChain = coll.transform;
            //     chainIndex = chains.IndexOf(collidedChain);
            //     playerTransform.parent = collidedChain;
            //     onRope = true;

            //     direction = Mathf.Sign(Vector3.Dot(collidedChain.right, Vector3.up));
            //     fix = false;
            // }

        }
        if (onRope)
        {
            //make player's position and rotation same as connected chain's
            playerTransform.position = collidedChain.position;
            // playerTransform.localRotation = Quaternion.AngleAxis(direction * 90, Vector3.forward);

            if (Input.GetButtonDown("Jump"))
            {
                StartCoroutine(JumpOff());

                // pControl.jump = true;
            }
            dirX = Input.GetAxisRaw("Horizontal");
            // if (dirX > dirX && !pControl.facingRight)
            // {
            //     pControl.Flip();
            // }
            // else if (dirX < 0 && pControl.facingRight)
            // {
            //     pControl.Flip();
            // }

            collidedChain.GetComponent<Rigidbody2D>().AddForce(Vector2.right * dirX * swingForce);
        }
    }

    IEnumerator JumpOff()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerTransform.parent = null;
        onRope = false;
        pControl.enabled = true;
        yield return new WaitForSeconds(delayBeforeSecondHand);
        foreach (var col in colliders)
        {
            col.enabled = true;
        }
    }
    // IEnumerator onCollisionEnter2D(Collision2D coll)
    // {

    //     if (coll.gameObject.tag == "Rope2D")
    //     {
    //         print("collided");
    //         var joint = coll.gameObject.GetComponent<HingeJoint2D>();
    //         if (joint && joint.enabled)
    //         {
    //             pControl.enabled = false;

    //             foreach (var col in colliders)
    //                 col.enabled = false;

    //             var chainParent = coll.transform.parent;
    //             chains = new List<Transform>();
    //             foreach (Transform chain in chainParent)
    //             {
    //                 chains.Add(chain);
    //             }

    //             collidedChain = coll.transform;
    //             chainIndex = chains.IndexOf(collidedChain);
    //             playerTransform.parent = collidedChain;
    //             onRope = true;

    //             direction = Mathf.Sign(Vector3.Dot(collidedChain.right, Vector3.up));
    //         }
    //     }
    //     return null;
    // }
}
