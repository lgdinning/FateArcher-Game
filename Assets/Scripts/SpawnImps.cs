using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnImps : MonoBehaviour
{
    public GameObject bomb;
    public bool throwCheck;
    public Vector3 rand;
    // Start is called before the first frame update
    void Start()
    {
        throwCheck = false;
        StartCoroutine(ThrowBomb());
    }

    // Update is called once per frame
    void Update()
    {  
        if (throwCheck) {
            rand = new Vector3(transform.position.x, Random.Range(-4.5f, 4.5f), 0);
            Instantiate(bomb, rand, transform.rotation);
            throwCheck = false;
        }
    }

    IEnumerator ThrowBomb() {
        yield return new WaitForSeconds(2);
        throwCheck = true;
        StartCoroutine(ThrowBomb());
    }
}
