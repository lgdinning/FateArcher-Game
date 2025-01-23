using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject bigEnemy;
    public GameObject rangedEnemy;
    public GameObject theTower;
    public GameObject theDevil;
    public Vector3 spawnLoc;
    public GameObject gameState;
    public int level;

    public void Spawn(int mob) {
        StartCoroutine(spawner(mob));
    }

    IEnumerator spawner(int i) {
        if (level == 6) {
            Instantiate(theDevil, new Vector3(7, 0, 0), transform.rotation);
            gameState.GetComponent<GameState>().enemiesLeft = 1;
        } else {
            
            if (level == 3) {
                Instantiate(theTower, new Vector3(7, 0, 0), transform.rotation);
                gameState.GetComponent<GameState>().enemiesLeft += 1;
            }
            int j = i;
            int rand = Random.Range(0,100);
            while (j > 0) {
                spawnLoc = new Vector3(9.25f, Random.Range(-4.5f, 4.5f), 0);
                if (rand < 60) {
                    Instantiate(basicEnemy, spawnLoc, transform.rotation);
                } else if (rand < 90) {
                    Instantiate(bigEnemy, spawnLoc, transform.rotation);
                } else if (rand < 100) {
                    Instantiate(rangedEnemy, spawnLoc, transform.rotation);
                }
                yield return new WaitForSeconds(Random.Range(0, 2.05f - (0.15f * level)));
                j -= 1;
                rand = Random.Range(0,100);
            }

        }

        level += 1;


    }

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
