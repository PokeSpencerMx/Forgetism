using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform point;
    private float canMove;
    private bool gonnaLoseUp;
    private bool gonnaLoseDown;
    private bool noUp;
    private bool noDown;

    public GameObject upPrefab;
    public GameObject downPrefab;
    private bool isMove;

    Animator animator;
    
    public LayerMask Stop;
  

    private void Start()
    {
        point.parent = null;
        canMove = 1f;
        gonnaLoseUp = false;
        gonnaLoseDown = false;
        noUp = false;
        noDown = false;

        animator = GetComponent<Animator>();
    }
    public bool IsMoving()
    {
        isMove = transform.position != point.position;
        return isMove;
    }

    public void ResetPosition()
    {
        point.position = transform.position;
    }

    private void Update()
    {
        //forgetting
        if (transform.position == point.position && !Physics2D.OverlapCircle(point.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * canMove, .2f, Stop))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    Debug.Log("Forgot how to move up");
                    //Animation for forgetting up should go here.

                    //losingLeft.Invoke();
                    gonnaLoseUp = true;
                    if (noUp == false)
                    {
                        Instantiate(upPrefab, new Vector3(transform.position.x - 0.1f, transform.position.y - 0.2f, upPrefab.transform.position.z), transform.rotation);
                        FMODUnity.RuntimeManager.PlayOneShot("event:/Forgetism_Gumball_Drop/Gumball_Drop");
                    }
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    // Debug.Log("Forgot how to move down");

                    //Animation for forgetting down should go here.

                    gonnaLoseDown = true;
                    if (noDown == false)
                    {
                        Instantiate(downPrefab, new Vector3(transform.position.x - 0.1f, transform.position.y - 0.2f, downPrefab.transform.position.z), transform.rotation);
                        FMODUnity.RuntimeManager.PlayOneShot("event:/Forgetism_Gumball_Drop/Gumball_Drop");
                    }
                }
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);

        //movement
        if (Vector3.Distance(transform.position, point.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (Input.GetAxisRaw("Vertical") < 0 && noDown)
                {
                    canMove = 0;
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Forgetism_Error/Error");
                }
                else if (Input.GetAxisRaw("Vertical") > 0 && noUp)
                {
                    canMove = 0;
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Forgetism_Error/Error");
                }
                else
                {
                    canMove = 1;
                }
                //collision check
                if (!Physics2D.OverlapCircle(point.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * canMove, .2f, Stop))
                    point.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * canMove;
                    animator.SetTrigger("moves");
            }
        }
        
        if (gonnaLoseUp)
        {
            ForgotUp();
        }
        if (gonnaLoseDown)
        {
            ForgotDown();
        }
    }

    public void ForgotUp()
    {
        noUp = true;
    }

    public void ForgotDown()
    {
        noDown = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log("GameObject1 collided with " + col.name);
        // if(col.name == "UpTriangle(Clone)")
        // {
        //     // noUp = false;
        //     // gonnaLoseUp = false;
        //     Destroy(col);
        // }
        // if (Vector3.Distance(transform.position, point.position) <=.05f && !Physics2D.OverlapCircle(point.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * canMove, .2f, Stop))
        // {
        //     if(col.name == "UpTriangle(Clone)")
        //     {
        //         noUp = false;
        //         gonnaLoseUp = false;
        //         // Destroy(col);
        //     }
        // }
        // restart = true;
        // timer = 0.0f;
    }
}

