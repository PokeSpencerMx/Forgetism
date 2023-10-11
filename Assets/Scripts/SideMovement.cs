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

    private void Start()
    {
        point.parent = null;
        canMove = 1f;
        gonnaLoseLeft = false;
        gonnaLoseRight = false;
        noLeft = false;
        noRight = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Forgot how to move left");
                //losingLeft.Invoke();
                gonnaLoseLeft = true;
                if (noLeft == false)
                {
                    Instantiate(leftPrefab, transform.position, leftPrefab.transform.rotation);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Forgot how to move right");
                gonnaLoseRight = true;
                if (noRight == false)
                {
                    Instantiate(rightPrefab, transform.position, rightPrefab.transform.rotation);
                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, point.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (Input.GetAxisRaw("Horizontal") < 0 && noLeft)
                {
                    canMove = 0;
                }
                else if (Input.GetAxisRaw("Horizontal") > 0 && noRight)
                {
                    canMove = 0;
                }
                else
                {
                    canMove = 1;
                }
                point.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) * canMove;
            }
        }
        if (gonnaLoseLeft)
        {
            ForgotLeft();
        }
        if (gonnaLoseRight)
        {
            ForgotRight();
        }
    }

    public void ForgotLeft()
    {
        noLeft = true;
    }

    public void ForgotRight()
    {
        noRight = true;
    }
}
