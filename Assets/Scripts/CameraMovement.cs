using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    
    public float increment = 4, limit = 0;

    bool follow = false;

    public Vector3 targetPos;
    
    void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        if(target.position.y < limit && targetPos == transform.position && !follow) {
            limit -= increment;
            targetPos -= new Vector3(0, increment, 0);
            follow = true;
        }
            
        if(follow) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, target.position.y-1.5f, -9), 7 * Time.deltaTime);
            if( transform.position.y < targetPos.y)
                follow = false;
        } else {
            transform.position = Vector3.Lerp(transform.position, targetPos, 3f * Time.deltaTime);
            if(Mathf.Abs( transform.position.y - targetPos.y) < 0.05f)
                transform.position = targetPos;
        }
        
    }
}
