using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    private float portalTimer;
    private bool portalActive;
    private float delay = 1.7f;
    public Transform portal;
    private GameObject gumDum;

    private void Start()
    {
        portalTimer = delay;
    }

    private void Update()
    {
        if (gumDum && portalActive)
        {
            if(portalTimer > 0)
            {
                portalTimer -= Time.deltaTime;
            } else
            {
                Teleport();
            }
        }
    }

    private void Teleport()
    {
        gumDum.transform.position = portal.position;
        gumDum.GetComponent<SideMovement>().ResetPosition();
        gumDum.GetComponent<VerticalMovement>().ResetPosition();
        portalTimer = delay;
        portalActive = false;
       // gumDum = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            portalActive = true;
            gumDum = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            portalActive = false;
            gumDum = null;
        }
    }

}
