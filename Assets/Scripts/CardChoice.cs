using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardChoice : MonoBehaviour
{
    public Button thisButton;

    public GameObject gameState;
    public GameObject deck;

    public string id;
    public TMP_Text description;

    void OnClickTask() {
        deck.GetComponent<TarotDeck>().Choose(id);
        gameState.GetComponent<GameState>().StartWave();
        deck.GetComponent<TarotDeck>().CloseCards();
        
    }

    public void SetCard(string name, string desc) {
        id = name;
        description.text = desc;
    }

    // Start is called before the first frame update
    void Start()
    {
        thisButton.onClick.AddListener(OnClickTask);
        description = transform.GetChild(1).GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
