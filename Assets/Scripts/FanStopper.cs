using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanStopper : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(1f, rb.velocity.y);
        }
    }
}
