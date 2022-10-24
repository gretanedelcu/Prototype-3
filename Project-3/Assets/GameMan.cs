using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Sprite[] cardFront;
    public Sprite cardBack;
    public GameObject[] Cards;
    public Text matchText;
    private bool Init = false;
    private int Matches = 12;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Init)
        {
            InitializeCards();
        }
        if (Input.GetMouseButtonUp(0))
        {
            CheckCards();
        }
    }

    void InitializeCards()
    {
        for (int id = 0; id < 2; id++)
        {
            for (int i = 1; i < 14; i++)
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = Random.Range(0, Cards.Length);
                    test = !(Cards[choice].GetComponent<Card>().initialized);

                }
                Cards[choice].GetComponent<Card>().cardValue = i;
                Cards[choice].GetComponent<Card>().initialized = true;
            }
        }
        foreach (GameObject c in Cards)
            c.GetComponent<Card>().SetGraphics();

        if (!Init)
            Init = true;
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }
    public Sprite getCardFront(int i)
    {
        return cardFront[i - 1];
    }

    void CheckCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < Cards.Length; i++)
        {
            if (Cards[i].GetComponent<Card>().state == 1)
                c.Add(i);
        }
        if (c.Count == 2)
        {
            cardComparison(c);
        }
    }

    void cardComparison(List<int> c)
    {
        Card.DO_NOT = true;
        int X = 0;
        if (Cards[c[0]].GetComponent<Card>().cardValue == Cards[c[1]].GetComponent<Card>().cardValue)
        {
            X = 2;
            Matches--;
            matchText.text = "Number of Matches: " + Matches;
            if (Matches == 0)
                SceneManager.LoadScene("Menu");

        }

        for (int i = 0; i < c.Count; i++)
        {
            Cards[c[i]].GetComponent<Card>().state = X;
            Cards[c[i]].GetComponent<Card>().FalseCheck();
        }

    }
}
