using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitCreator : MonoBehaviour
{
    int depth = 0;
    [SerializeField] GameObject floor;
    [SerializeField] GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        depth = floor.transform.childCount * 5 + 1;
        Debug.Log("Child Count: " + floor.transform.childCount);    
        for (int i = -10; i < depth; i++)
        {
            Instantiate(block, new Vector3(-3, -i), Quaternion.identity);
            Instantiate(block, new Vector3(3, -i), Quaternion.identity);
        }

        for(int i = depth-5; i < depth+6; i++){
            Instantiate(block, new Vector3(-2,-i), Quaternion.identity);
            Instantiate(block, new Vector3(-1,-i), Quaternion.identity);
            Instantiate(block, new Vector3(0,-i), Quaternion.identity);
            Instantiate(block, new Vector3(1,-i), Quaternion.identity);
            Instantiate(block, new Vector3(2,-i), Quaternion.identity);
        }
    }

}
