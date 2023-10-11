using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform point;

    private void Start()
    {
        point.parent = null;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, point.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                point.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
        }
    }
}
