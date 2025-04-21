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
            Debug.Log("���а� ���� á���ϴ�. ! (�ִ� 6��)");
            return;
        }

        if (deckCards.Count == 0)
        {
            Debug.Log("���� ī�尡 �����ϴ�.");
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
            Debug.Log("��ȿ���� ���� ī�� �ε��� �Դϴ�");
            return;
        }

        CardData cardData = handCards[handIndex];
        handCards.RemoveAt(handIndex);


    }

    public void ReturnDiscardsToDeck()
    {
        if (discardCards.Count == 0)
        {
            Debug.Log("���� ī�� ���̰� ��� �ֽ��ϴ�. ");
            return;
        }

        deckCards.AddRange(discardCards);
        discardCards.Clear();
        ShuffleDeck();

        Debug.Log("���� ī��" + deckCards.Count + "���� ������ �ǵ����� �������ϴ�. ");
    }

}
