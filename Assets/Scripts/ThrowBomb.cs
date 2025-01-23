using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject bomb;
    public bool throwCheck;
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
            Instantiate(bomb, transform.position, transform.rotation);
            throwCheck = false;
        }
    }

    IEnumerator ThrowBomb() {
        yield return new WaitForSeconds(3);
        throwCheck = true;
    }
}
