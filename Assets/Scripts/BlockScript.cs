using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] GameObject hitParticle;
    public void TakeHit() {
        Instantiate(hitParticle, transform.position, Quaternion.identity);
    }
}
