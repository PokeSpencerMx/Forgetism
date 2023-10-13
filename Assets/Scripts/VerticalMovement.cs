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

    private void Start()
    {
        point.parent = null;
        canMove = 1f;
        gonnaLoseUp = false;
        gonnaLoseDown = false;
        noUp = false;
        noDown = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
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
        transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);

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
                point.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * canMove;
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
}

