using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            newPosition -= new Vector2(0, gridIncrement);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            newPosition += new Vector2(0, gridIncrement);
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
