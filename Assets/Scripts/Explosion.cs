using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<EnemyBehaviour>() != null) {
            other.gameObject.GetComponent<EnemyBehaviour>().reduceHealth(50);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Explode() {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
