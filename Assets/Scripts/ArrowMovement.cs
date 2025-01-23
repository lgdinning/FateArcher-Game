using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speed = 0.2f;
    public float damage = 1.0f;
    public bool passThrough = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        transform.position += transform.right * Time.deltaTime * speed * 0.3f;
        if (transform.position.x > 10 || transform.position.x < -10) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<EnemyBehaviour>() != null) {
            if (!passThrough) {
                Destroy(gameObject);
            }
            other.gameObject.GetComponent<EnemyBehaviour>().reduceHealth(damage);
        }

    }
}
