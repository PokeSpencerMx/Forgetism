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

    private void Update()
    {
        //forgetting
        if (Vector3.Distance(transform.position, point.position) <=.05f && !Physics2D.OverlapCircle(point.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * canMove, .2f, Stop))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("Forgot how to move up");
                    //losingLeft.Invoke();
                    gonnaLoseUp = true;
                    if (noUp == false)
                    {
                        Instantiate(upPrefab, new Vector3(transform.position.x, transform.position.y, upPrefab.transform.position.z), transform.rotation);
                    }
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Debug.Log("Forgot how to move down");
                    gonnaLoseDown = true;
                    if (noDown == false)
                    {
                        Instantiate(downPrefab, new Vector3(transform.position.x, transform.position.y, downPrefab.transform.position.z), transform.rotation);
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
                }
                else if (Input.GetAxisRaw("Vertical") > 0 && noUp)
                {
                    canMove = 0;
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

