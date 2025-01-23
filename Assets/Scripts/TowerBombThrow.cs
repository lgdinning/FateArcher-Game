using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBombThrow : MonoBehaviour
{
    public GameObject projectile;
    public bool throwCheck;

    // Start is called before the first frame update
    void Start()
    {
        throwCheck = true;
        StartCoroutine(ThrowCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        if (throwCheck) {
            Instantiate(projectile, transform.position, transform.rotation);
            throwCheck = false;
        }
    }

    IEnumerator ThrowCooldown() {
        yield return new WaitForSeconds(0.6f);
        throwCheck = true;
        StartCoroutine(ThrowCooldown());
    }
}
