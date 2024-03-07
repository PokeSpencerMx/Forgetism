using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePortal : MonoBehaviour
{
   
    public Transform portal;
    private GameObject gumDum;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gumDum.transform.position = portal.position;
            gumDum.GetComponent<SideMovement>().ResetPosition();
            gumDum.GetComponent<VerticalMovement>().ResetPosition();
           // Debug.Log("its working");
        }
       // Debug.Log("its working");
    }

    

}
