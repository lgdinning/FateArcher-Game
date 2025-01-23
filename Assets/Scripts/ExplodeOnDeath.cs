using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnDeath : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        GameObject e = Instantiate(explosion, transform.position, transform.rotation);
        e.transform.localScale -= new Vector3(1.5f,1.5f,0);
    }
}
