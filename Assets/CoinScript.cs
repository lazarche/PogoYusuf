using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    float min, max, dir = 1, spd = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.y+0.1f;
        max = transform.position.y-0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 15 * Time.deltaTime, 0), Space.World);
        VerticalMovement();
    }

    void VerticalMovement() {
        ChangeDirections(transform.position.y);
        transform.Translate(new Vector3(0, spd * dir * Time.deltaTime, 0), Space.World);
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
