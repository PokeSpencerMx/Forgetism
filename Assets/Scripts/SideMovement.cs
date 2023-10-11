using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform point;
    private float canMove;
    private bool noLeft;
    private bool noRight;

    private void Start()
    {
        point.parent = null;
        canMove = 1f;
        noLeft = false;
        noRight = false;
    }

    private void Update()
    {
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
    }

    public void ForgotLeft()
    {
        noLeft = true;
    }
}
