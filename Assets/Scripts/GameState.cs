using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public bool readyForCards;
    public int gold;
    public int hp;
    public int enemiesLeft;
    public int waveSize;
    public int enemiesDefeated;
    public int level;

    public TMP_Text hpText;
    public TMP_Text goldText;
    public TMP_Text enemiesText;

    public GameObject SpawnManager;
    public GameObject TarotDeck;

    public void StartWave() {
        waveSize += 20;
        enemiesLeft = waveSize;
        readyForCards = true;
        SpawnManager.GetComponent<SpawnManager>().Spawn(waveSize);
    }

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        enemiesDefeated = 0;
        readyForCards = false;
        gold = 100;
        hp = 20;
        waveSize = 0;
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "" + hp;
        goldText.text = "" + gold;
        enemiesText.text = "" + enemiesLeft;
        if ((enemiesLeft <= 0) && (readyForCards)) {
            readyForCards = false;
            TarotDeck.GetComponent<TarotDeck>().SetCards();
            TarotDeck.GetComponent<TarotDeck>().OpenCards();
            level += 1;
        }
        if (hp < 1) {
            SceneManager.LoadScene("LossScreen", LoadSceneMode.Single);
        }
        if (level > 6) {
            SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
        }
    }
}
