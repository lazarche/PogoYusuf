using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePecPec : MonoBehaviour
{
    enum Direction{
        Vertical, Horizontal
    }
    [Header("Limits")]
    [SerializeField] float min,max;
    [SerializeField] float spd;
    [SerializeField] Direction direction;
    
    [SerializeField] float dir = 1;
    Vector3 start;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 220 * Time.deltaTime), Space.World);

        switch (direction)
        {
            case Direction.Vertical:
                VerticalMovement();
            break;

            case Direction.Horizontal:
                HorizontalMovement();
            break;
        }
    }

    void VerticalMovement() {
        ChangeDirections(transform.localPosition.y);
        transform.Translate(new Vector3(0, spd * dir * Time.deltaTime, 0), Space.World);
    }

    void HorizontalMovement() {
        ChangeDirections(transform.localPosition.x);
        transform.Translate(new Vector3(spd * dir * Time.deltaTime, 0, 0), Space.World);
    }

    void ChangeDirections(float value) {
        if(dir > 0) {
            if(value >= max)
                dir = -1;
        } else {
            if(value <= min)
                dir = 1;
        }
    }
}