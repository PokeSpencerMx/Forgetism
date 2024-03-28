using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowAway : MonoBehaviour
{
    //public Vector2, which is the spot Gumdum will be blown to.
    public Vector3 destination;

    //private float indicating the speed Gumdum will be blown at
    private float speed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D gumdum)
    {
        //When Gumdum activates the trigger by entering the collider...
        Debug.Log("BlowAwaySpot triggered with " + gumdum.name);
        
        gumdum.transform.position = Vector3.MoveTowards(gumdum.transform.position, destination, speed * Time.deltaTime);
        if(gumdum.transform.position == destination)
        {
            
        }
        
    }

    void ResetPositions(Collider2D gumdum)
    {
        gumdum.GetComponent<SideMovement>().ResetPosition();
        gumdum.GetComponent<VerticalMovement>().ResetPosition();
    }


}
