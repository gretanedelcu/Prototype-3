using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public static bool DO_NOT = false;

    [SerializeField]
    public  int state;
    [SerializeField]
    public int cardValue;
    [SerializeField]
    public bool initialized = false;

    private Sprite cardBack;
    private Sprite cardFront;
    private GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGraphics()
    {
        cardBack = manager.GetComponent<GameMan>().getCardBack();
        cardFront = manager.GetComponent<GameMan>().getCardFront(cardValue);

        FlipCard();
    }

    void FlipCard()
    {
        if (state == 0 && !DO_NOT)
        {
            GetComponent<Image>().sprite = cardBack;
        }else if(state == 1 && !DO_NOT)
        {
            GetComponent<Image>().sprite = cardFront;
        }
    }

    public int CardValue
    {
        get { return cardValue; }
        set { cardValue = value; }
    }

    public int State
    {
        get { return state; }
        set { state = value; }
    }

    public bool Initialize
    {
        get { return initialized; }
        set { initialized = value; }
    }

    public void FalseCheck()
    {
        StartCoroutine(pause ());
    }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if (state == 0)
            GetComponent<Image>().sprite = cardBack;
        else if (state == 1)
            GetComponent<Image>().sprite = cardFront;
        DO_NOT = false;
    }
}
