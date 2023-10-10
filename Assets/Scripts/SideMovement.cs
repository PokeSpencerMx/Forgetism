using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    Vector2 newPosition;
    public float gridIncrement;

    void Start()
    {
        newPosition = transform.position;
    }

    void Update()
    {
        // input
        if (Input.GetKeyDown(KeyCode.A))
        {
            newPosition -= new Vector2(gridIncrement, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            newPosition += new Vector2(gridIncrement, 0);
        }

        // raycast
        RaycastHit2D hit = Physics2D.Linecast(transform.position, newPosition);
        if (hit.collider == null)
        {
            transform.position = newPosition;
        }
        else
        {
            newPosition = transform.position;
        }
    }
}
