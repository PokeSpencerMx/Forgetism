using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public LayerMask GumdumAndStopLayer;
    public float fanSpeed = 5f;
    Vector3 fanEndPos;
    bool endSet = false;

    // round to grid
    float FloorTo(float val, float multOf)
    {
        return Mathf.Floor(val / multOf) * multOf;
    }

    // Update is called once per frame
    void Update()
    {
        // raycast for fan to look for gumdum
        RaycastHit2D[] hits = Physics2D.RaycastAll(
            transform.position,
            transform.right,
            Mathf.Infinity,
            GumdumAndStopLayer);

        // if two hits, first is gumdum, second is wall
        if (hits.Length > 1 &&
            hits[0].collider.gameObject.layer == 7 &&
            hits[1].collider.gameObject.layer == 6)
        {
            GameObject gumdum = hits[0].collider.gameObject;

            // if an end position hasn't been found get it... else move it
            if (!endSet)
            {
                // if gumdum isn't moving, set a destination
                if (!gumdum.GetComponent<VerticalMovement>().IsMoving() && !gumdum.GetComponent<SideMovement>().IsMoving())
                {
                    Debug.Log("hit on");
                    // vector from gumdum to wall
                    Vector2 diffVec = hits[1].point - (Vector2)gumdum.transform.position;

                    // clamp dist to grid and floor to 1 (but allows for other grid sizes)
                    float diffVecMagFloor = FloorTo(diffVec.magnitude, 1);
                    Vector2 clampVec = Vector3.ClampMagnitude(diffVec, diffVecMagFloor);

                    // set end pos
                    gumdum.GetComponent<SideMovement>().ResetPosition();
                    gumdum.GetComponent<VerticalMovement>().ResetPosition();

                    fanEndPos = (Vector2)gumdum.transform.position + clampVec;
                    endSet = true;
                    Debug.Log("End pos created" + fanEndPos);
                }
            }
            else
            {
                Debug.Log("moving");
                gumdum.transform.position = Vector3.MoveTowards(gumdum.transform.position, fanEndPos, fanSpeed * Time.deltaTime);
            }

            // if you've reached the end, reset position of gumdum (kinda weird) and reset fan
            if (endSet && gumdum.transform.position == fanEndPos)
            {
                gumdum.GetComponent<SideMovement>().ResetPosition();
                gumdum.GetComponent<VerticalMovement>().ResetPosition();
                endSet = false;
            }
        }
    }
}
