using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float hp;
    public float speed;
    public GameObject gameState;

    public void reduceHealth(float damage) {
        Debug.Log(hp);
        hp -= damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameState");
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) {
            if (gameObject.name != "Bomb 1(Clone)" && gameObject.name != "Imp(Clone)") {
                gameState.GetComponent<GameState>().enemiesLeft -= 1;
                gameState.GetComponent<GameState>().enemiesDefeated += 1;
            }
            Destroy(gameObject);
        } else if (transform.position.x < -3.7) {
            gameState.GetComponent<GameState>().hp -= 1;
            if (gameObject.name != "Bomb 1(Clone)") {
                gameState.GetComponent<GameState>().enemiesLeft -= 1;
            }
            //gameState.GetComponent<GameState>().enemiesLeft -= 1;
            Destroy(gameObject);
        }
        transform.position -= transform.right * Time.deltaTime * speed;
    }
}
