using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform point;
    private float canMove;
    private bool gonnaLoseLeft;
    private bool gonnaLoseRight;
    private bool noLeft;
    private bool noRight;

    public GameObject leftPrefab;
    public GameObject rightPrefab;

    private SpriteRenderer sRend;
    Animator animator;

    public LayerMask Stop;
    Vector3 fanCheck;
    bool fanOn = false;

    private void Start()
    {
        point.parent = null;
        canMove = 1f;
        gonnaLoseLeft = false;
        gonnaLoseRight = false;
        noLeft = false;
        noRight = false;

        animator = GetComponent<Animator>();
    }
  /*  public bool IsMoving()
    {
        return (transform.position != point.position);
    }*/

    private void Update()
    {
        //forgetting mechanic
        if (Vector3.Distance(transform.position, point.position) <= .05f && !Physics2D.OverlapCircle(point.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) * canMove, .2f, Stop))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Debug.Log("Forgot how to move left");
                    //losingLeft.Invoke();
                    gonnaLoseLeft = true;
                    if (noLeft == false)
                    {
                        Instantiate(leftPrefab, new Vector3(transform.position.x, transform.position.y, leftPrefab.transform.position.z), leftPrefab.transform.rotation);
                        FMODUnity.RuntimeManager.PlayOneShot("event:/Forgetism_Gumball_Drop/Gumball_Drop");

                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        Debug.Log("Forgot how to move right");
                        gonnaLoseRight = true;
                        if (noRight == false)
                        {
                            Instantiate(rightPrefab, new Vector3(transform.position.x, transform.position.y, rightPrefab.transform.position.z), rightPrefab.transform.rotation);
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Forgetism_Gumball_Drop/Gumball_Drop");
                        }
                    }
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);

            //movement
            if (Vector3.Distance(transform.position, point.position) <= .05f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (Input.GetAxisRaw("Horizontal") < 0 && noLeft)
                    {
                        canMove = 0;
                        FMODUnity.RuntimeManager.PlayOneShot("event:/Forgetism_Error/Error");
                    }
                    else if (Input.GetAxisRaw("Horizontal") > 0 && noRight)
                    {
                        canMove = 0;
                        FMODUnity.RuntimeManager.PlayOneShot("event:/Forgetism_Error/Error");
                    }
                    else
                    {
                        canMove = 1;
                    }
                    //collision check
                    if (!Physics2D.OverlapCircle(point.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) * canMove, .2f, Stop))
                    {
                        point.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) * canMove;
                        animator.SetTrigger("moves");
                    }
                }
            }
            // auto movement
            /*if (Input.GetAxisRaw("Horizontal") == -1)
            {
                Debug.Log("FAN ON");
                fanOn = true;

                float d = 0.5f;
                Vector3 start = point.position - new Vector3(d, 0, 0);
                Vector3 end = point.position + new Vector3(d, 0, 0);
                if (!Physics2D.Linecast(start, end, Stop))
                {
                    fanCheck = point.position + new Vector3(-1f, 0f, 0f);
                    Debug.Log("fanCheck:" + fanCheck);
                }
                else
                {
                    fanOn = false;
                }
            }
            if (fanOn)
            {
                point.position = fanCheck;
            }
           */
            // else
            // {
            //     Debug.Log("Hey no!");
            // }
            if (gonnaLoseLeft)
            {
                ForgotLeft();
            }
            if (gonnaLoseRight)
            {
                ForgotRight();
            }
        }
    }

    private void ForgotLeft()
    {
        noLeft = true;
    }

    private void ForgotRight()
    {
        noRight = true;
    }
}