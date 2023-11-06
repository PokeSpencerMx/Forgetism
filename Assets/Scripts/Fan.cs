using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public LayerMask GumdumLayer;
    Vector2 stopPosition;
    GameObject gumdum;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, Mathf.Infinity, GumdumLayer);

        // if we hit gumdum
        if (hit.collider != null)
        {
            // only set gumdum var when stopped
            GameObject hitObject = hit.collider.gameObject;
            if (!hitObject.GetComponent<VerticalMovement>().IsMoving() && !hitObject.GetComponent<SideMovement>().IsMoving())
            {
                Debug.Log(hit.collider.gameObject);
                gumdum = hit.collider.gameObject;
            }
        }
        else
        {
            gumdum = null;
        }

        // if gumdum is set, that means fan is on
        if (gumdum != null)
        {
            //gumdum.GetComponent<Rigidbody2D>().velocity = transform.right * 10f;
        }

    }
}
