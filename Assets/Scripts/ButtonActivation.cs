using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour
{
    SpriteRenderer s_rend;
    // Start is called before the first frame update
    void Start()
    {
        Color offColor = Color.red;
        Color onColor = Color.green;
        s_rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D()
    {
        //Debug.Log("Hello world.");
        s_rend.color = Color.green;
    }

    void OnTriggerExit2D()
    {
        s_rend.color = Color.red;
    }
}
