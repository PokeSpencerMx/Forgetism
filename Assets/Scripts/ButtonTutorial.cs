using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTutorial : MonoBehaviour
{
    public Component text;
    public Text t;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("GameObject1 collided with " + col.name);
        // Debug.Log(OutputMessage(col.name));
        t.text = OutputMessage(col.name);
        // text.input = "Hello World";
    }

    // void OnTriggerStay2D(Collider2D col)
    // {
    //     if (Input.GetKey(KeyCode.LeftShift))
    //     {
    //         t.text = "Now move to lose your marbles!";
    //     }
    //     // else
    //     // {
    //     //     t.text = OutputMessage(col.name);
    //     // }
    // }

    private string OutputMessage(string name)
    {
        string tutorial_mess = name;
        if (name == "Gumdum")
        {
            tutorial_mess = "While standing on the Button, hold shift and move.";
        }
        else if (name == "LeftTriangle(Clone)")
        {
            tutorial_mess = "You have now dropped your memories of how to move left!";
        }
        else if (name == "RightTriangle(Clone)")
        {
            tutorial_mess = "You have now dropped your memories of how to move right!";
        }
        else if (name == "DownTriangle(Clone)")
        {
            tutorial_mess = "You have now dropped your memories of how to move down!";
        }
        else if (name == "UpTriangle(Clone)")
        {
            tutorial_mess = "You have now dropped your memories of how to move up! You can press R to Restart.";
        }
    
        return tutorial_mess;
    }
}
