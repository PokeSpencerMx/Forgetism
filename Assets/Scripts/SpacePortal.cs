using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePortal : MonoBehaviour
{
   // private float portalTimer;
   // private bool portalActive;
   // private float delay = 1.7f;
    public Transform portal;
    private GameObject gumDum;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gumDum.transform.position = portal.position;
            gumDum.GetComponent<SideMovement>().ResetPosition();
            gumDum.GetComponent<VerticalMovement>().ResetPosition();
        }
    }
  /*  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gumDum.transform.position = portal.position;
            gumDum.GetComponent<SideMovement>().ResetPosition();
            gumDum.GetComponent<VerticalMovement>().ResetPosition();
        }
   }
*/
    

}
