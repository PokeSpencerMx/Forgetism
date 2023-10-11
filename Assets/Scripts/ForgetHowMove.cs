using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ForgetHowMove : MonoBehaviour
{
    //public UnityEvent losingLeft;
    // public Script SideMovement;
    public delegate void OnLosingLeft();
    public static OnLosingLeft onLosingLeft;
    public GameObject capsule;
    
    // Start is called before the first frame update
    void Start()
    {
        // onLosingLeft =
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //Debug.Log("LeftCtrl is pressed");
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Forgot how to move up");
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Forgot how to move left");
                //losingLeft.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Forgot how to move right");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Forgot how to move down");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Instantiate(capsule);
        }
    }
}
