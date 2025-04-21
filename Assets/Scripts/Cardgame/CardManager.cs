using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<CardData> deckCards = new List<CardData>();
    public List<CardData> handCards = new List<CardData>();
    public List<CardData> discardCards = new List<CardData>();

    public GameObject cardPrefab;
    public Transform deckPosition;
    public Transform handPosition;
    public Transform discardPosition;

    // Start is called before the first frame update
    void Start()
    {
        ShuffleDeck();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DrawCard();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ReturnDiscardsToDeck();
        }

        Arrangehand();
    }

    public void ShuffleDeck()
    {
        List<CardData> tempDeck = new List<CardData>(deckCards);
        deckCards.Clear();

        while (tempDeck.Count > 0)
        {
            int randlndex = Random.Range(0, tempDeck.Count);
            deckCards.Add(tempDeck[randlndex]);
            tempDeck.RemoveAt(randlndex);
        }
    }

    public void DrawCard()
    {
        if (handCards.Count >= 6)
        {
            Debug.Log("손패가 가득 찼습니다. ! (최대 6장)");
            return;
        }

        if (deckCards.Count == 0)
        {
            Debug.Log("덱에 카드가 없습니다.");
            return;
        }

        CardData cardData = deckCards[0];
        deckCards.Remove(0);

        handCards.Add(cardData);

        GameObject cardObj = Instantiate(cardPrefab, deckPosition.position, Quaternion.identity);

        CardDisplay cardDisplay = cardObj.GetComponent<CardDisplay>();

        if (CardDisplay != null)
        {
            cardDisplay.SetupCard(cardData);
            cardDisplay.cardIndex = handCards.Count;
            cardObjects.Add(cardObj);
        }

        Arrangehand();

    }


    public void Arrangehand()
    {
        if (handCards.Count == 0) return;

        float cardWidth = 1.2f;
        float spacing = cardWidth + 1.8f;
        float totalWidth = (handCards.Count - 1) * spacing;
        float startX = -totalWidth / 2f;

        for (int i = 0; i<cardObjects>)
    }


    public void DiscardCard(int handIndex)
    {
        if(handIndex < 0 ll handIndex >= handCards.Count)
        {
            Debug.Log("유효하지 않은 카드 인덱스 입니다");
            return;
        }

        CardData cardData = handCards[handIndex];
        handCards.RemoveAt(handIndex);


    }

    public void ReturnDiscardsToDeck()
    {
        if (discardCards.Count == 0)
        {
            Debug.Log("버린 카드 더미가 비어 있습니다. ");
            return;
        }

        deckCards.AddRange(discardCards);
        discardCards.Clear();
        ShuffleDeck();

        Debug.Log("버린 카드" + deckCards.Count + "장을 덱으로 되돌리고 섞었습니다. ");
    }

}
