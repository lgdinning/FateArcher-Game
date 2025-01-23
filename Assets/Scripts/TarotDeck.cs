using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TarotDeck : MonoBehaviour
{
    public GameObject gameState;
    public GameObject player;
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public Image i1;
    public Image i2;
    public Image i3;
    public GameObject title;

    public Sprite sword;
    public Sprite cup;
    public Sprite wand;
    public Sprite fool;
    public Sprite magician;
    public Sprite lovers;
    


    public List<string> deck = new List<string>();
    public List<string> descDeck = new List<string>();

    public void CloseCards() {
        card1.SetActive(false);
        card2.SetActive(false);
        card3.SetActive(false);
        title.SetActive(false);
    }

    public void OpenCards() {
        card1.SetActive(true);
        card2.SetActive(true);
        card3.SetActive(true);
        title.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        i1 = card1.GetComponent<Image>();
        i2 = card2.GetComponent<Image>();
        i3 = card3.GetComponent<Image>();

        CloseCards();
        //deck.Add("Pentacle");
        deck.Add("Sword");
        deck.Add("Cup");
        deck.Add("Wand");
        deck.Add("The Fool");
        deck.Add("The Magician");
        deck.Add("The Lovers");
        deck.Add("Judgement");
        deck.Add("Justice");
        deck.Add("The Chariot");
        deck.Add("Strength");
        //descDeck.Add("Gain 100 gold.");
        descDeck.Add("Gain attack power.");
        descDeck.Add("Gain 3 health.");
        descDeck.Add("Decrease spell cooldown.");
        descDeck.Add("Gain two different buffs at random.");
        descDeck.Add("Greatly reduced cooldown of spell, lower bow damage.");
        descDeck.Add("Reduce bow damage slightly, gain 10 health");
        descDeck.Add("Add damage based on how many enemies you've currently defeated.");
        descDeck.Add("Add damage the lower your health currently is.");
        descDeck.Add("Reduced charge time, lower bow damage.");
        descDeck.Add("Shoot an extra arrow with each attack. Lower charge speed.");
    }

    public void setSprite(Image card, string b) {
        switch (b) {
            case "Sword":
                card.sprite = sword;
                break;
            case "Cup":
                card.sprite = cup;
                break;
            case "Wand":
                card.sprite = wand;
                break;
            case "The Fool":
                card.sprite = fool;
                break;
            case "The Magician":
                card.sprite = magician;
                break;
            case "The Lovers":
                card.sprite = lovers;
                break;
            default:
                card.sprite = fool;
                break;
        }
    }

    public void SetCards() {
        int rand = Random.Range(0, deck.Count);
        card1.GetComponent<CardChoice>().SetCard(deck[rand], descDeck[rand]);
        setSprite(i1, deck[rand]);
        rand = Random.Range(0, deck.Count);
        card2.GetComponent<CardChoice>().SetCard(deck[rand], descDeck[rand]);
        setSprite(i2, deck[rand]);
        rand = Random.Range(0, deck.Count);
        card3.GetComponent<CardChoice>().SetCard(deck[rand], descDeck[rand]);
        setSprite(i3, deck[rand]);
    }

    public void Choose(string drawn) {
        int removeIndex = deck.IndexOf(drawn);
        if (removeIndex > 3) {
            deck.RemoveAt(removeIndex);
            descDeck.RemoveAt(removeIndex);
        }
        switch (drawn) {
            case "Pentacle":
                gameState.GetComponent<GameState>().gold += 100;
                break;
            case "Sword":
                player.GetComponent<PlayerBehaviour>().damageMultiplier += 0.2f;
                break;
            case "Cup":
                gameState.GetComponent<GameState>().hp += 3;
                break;
            case "Wand":
                player.GetComponent<PlayerBehaviour>().ChangeCD(-1);
                break;
            case "The Fool":
                int rand = Random.Range(0, deck.Count);
                Choose(deck[rand]);
                rand = Random.Range(0, deck.Count);
                Choose(deck[rand]);
                break;
            case "The Magician":
                player.GetComponent<PlayerBehaviour>().ChangeCD(-8);
                player.GetComponent<PlayerBehaviour>().ChangeDamage(-0.4f);
                break;
            case "The Lovers":
                player.GetComponent<PlayerBehaviour>().ChangeDamage(-0.1f);
                gameState.GetComponent<GameState>().hp += 8;
                break;
            case "Judgement":
                player.GetComponent<PlayerBehaviour>().ChangeDamage(gameState.GetComponent<GameState>().enemiesDefeated * 0.005f);
                break;
            case "Justice":
                int a = 20 - gameState.GetComponent<GameState>().hp;
                if (a > 0) {
                    player.GetComponent<PlayerBehaviour>().ChangeDamage(a);
                }
                break;
            case "The Chariot":
                player.GetComponent<PlayerBehaviour>().ChangeCharge(1f);
                player.GetComponent<PlayerBehaviour>().ChangeDamage(-0.4f);
                break;
            case "Strength":
                player.GetComponent<PlayerBehaviour>().ChangeCharge(-0.3f);
                player.GetComponent<PlayerBehaviour>().strength = true;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
