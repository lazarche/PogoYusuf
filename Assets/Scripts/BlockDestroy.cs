using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    [SerializeField] int max_hp = 3,hp = 3;
    [SerializeField] Material[] dest;

    [SerializeField] GameObject destroyParticle, hitParticle;

    void Start() {
        if(hp != max_hp)
        GetComponent<MeshRenderer>().material = dest[Mathf.FloorToInt((dest.Length-1) * hp/max_hp)];
    }

    public bool TakeHit() {
        hp--;
        Instantiate(hitParticle, transform.position, Quaternion.identity);
        GetComponent<MeshRenderer>().material = dest[Mathf.FloorToInt((dest.Length-1) * hp/max_hp)];

        bool ret = false;
        if(hp <= 0)
            ret = true;
        

        if(ret) {
            Instantiate(destroyParticle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
            
        return ret;
    }
}
