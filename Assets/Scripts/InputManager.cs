using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private int _desiredLane = 0; // -1:left  0:middle  1:right

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    PlayerMovement pm;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
        dragDistance = Screen.width * 15 / 100; //dragDistance is 15% height of the screen
    }
    private void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            pm.MovePlayer(1);
                        }
                        else
                        {   //Left swipe
                            pm.MovePlayer(-1);
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                       if (lp.y > fp.y)  //If the movement was up
                       {   //Up swipe
                       }
                       else
                       {   //Down swipe
                           pm.MovePlayer(0);
                       }
                    }
                }
            }
        }
    }
}
