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

    private float startFrame = 0.35f;

    public GameObject leftPrefab;
    public GameObject rightPrefab;

    private SpriteRenderer sr;
    Animator animator;
    private bool isMove;

    public LayerMask Stop;
    private bool waitForAni = false;
  

    private void Start()
    {
        point.parent = null;
        canMove = 1f;
        gonnaLoseLeft = false;
        gonnaLoseRight = false;
        noLeft = false;
        noRight = false;

        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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
        if(waitForAni)return;

        //sprite flipping
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            sr.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            sr.flipX = false;
        }
        

        //forgetting mechanic
        if (transform.position == point.position && !Physics2D.OverlapCircle(point.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) * canMove, .2f, Stop))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Animation for getting ready to forget a direction
                animator.SetBool("thinking", true);


                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    // Debug.Log("Forgot how to move left");

                    //Animation for forgetting left should go here. 
                    //animator.SetBool("thinking", false);
                    //animator.SetBool("unmovable", true);
                   // animator.SetBool("right", true);

                    //losingLeft.Invoke();
                    gonnaLoseLeft = true;
                    if (noLeft == false)
                    {
                        //Not Flipped
                        sr.flipX = false;
                        
                        //Gumdum pan animation
                        animator.Play("PullingOutPan(right)", -1, startFrame);
                        
                        Instantiate(leftPrefab, new Vector3(transform.position.x - 0.1f, transform.position.y - 0.2f, leftPrefab.transform.position.z), leftPrefab.transform.rotation);
                        FMODUnity.RuntimeManager.PlayOneShot("event:/Forgetism_Gumball_Drop/Gumball_Drop");
                        //animator.SetBool("unmovable", false);
                        //animator.SetBool("right", false);

                    }
                    
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                    {
                        // Debug.Log("Forgot how to move right");
                        //Animation for forgetting right should go here.
                        //animator.SetBool("thinking", false);
                        //animator.SetBool("unmovable", true);
                        //animator.SetBool("right", true);

                        gonnaLoseRight = true;
                        if (noRight == false)
                        {
                            //Flipped
                            sr.flipX = true;

                            //Gumdum pan animation
                            animator.Play("PullingOutPan(right)", -1, startFrame);
                            
                            Instantiate(rightPrefab, new Vector3(transform.position.x - 0.1f, transform.position.y - 0.2f, rightPrefab.transform.position.z), rightPrefab.transform.rotation);
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Forgetism_Gumball_Drop/Gumball_Drop");
                            
                            
                            
                        }
                    }
            }
            else
            {
                animator.SetBool("thinking", false);
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
                        
                        //Makes sure the sprite isn't flipped.
                        sr.flipX = false;

                        //Plays the animation of Gumdum shrugging and thinking of a crossed out left arrow
                        animator.Play("ForgotLeft");
                    }
                    else if (Input.GetAxisRaw("Horizontal") > 0 && noRight)
                    {
                        canMove = 0;
                        FMODUnity.RuntimeManager.PlayOneShot("event:/Forgetism_Error/Error");

                        //Makes sure the sprite isn't flipped.
                        sr.flipX = false;

                        //Plays the animation of Gumdum shrugging and thinking of a crossed out right arrow
                        animator.Play("ForgotRight");
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

    public void AniComplete(){
        Instantiate(rightPrefab, new Vector3(transform.position.x - 0.1f, transform.position.y - 0.2f, rightPrefab.transform.position.z), rightPrefab.transform.rotation);
        waitForAni = false;
    }
}