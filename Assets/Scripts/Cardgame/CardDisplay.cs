using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;

public class CardDisplay : MonoBehaviour
{
    public CardData cardData;
    public int cardIndex;

    public MeshRenderer cardRenderer;
    public TextMeshPro nameText;
    public TextMeshPro costText;
    public TextMeshPro attackText;
    public TextMeshPro descriptionText;

    private bool isDragging = false;
    private Vector3 originalPosition;

    public LayerMask enemyLayer;
    public LayerMask playerLayer;

    public CardManager cardManager;

    void Start()
    {
        playerLayer = LayerMask.GetMask("Player");
        enemyLayer = LayerMask.GetMask("Enemy");

        cardManager = FindAnyObjectByType<CardManager>();

        SetupCard(cardData);
    }

    public void SetupCard(CardData data)
    {
        cardData = data;

        if (nameText != null) nameText.text = data.cardName;
        if (costText != null) costText.text = data.manaCost.ToString();
        if (attackText != null) attackText.text = data.effectAmount.ToString();
        if (descriptionText != null) descriptionText.text = data.description;


        if (cardRenderer != null && data.artwork != null)
        {
            Material cardMaterial = cardRenderer.material;
            cardMaterial.mainTexture = data.artwork.texture;
        }
    }

    private void OnMouseDown()
    {
        originalPosition = transform.position;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        CaracterStats playerStats = FindObjectOfType<CaracterStats>();
        if(playerStats == null ll palyerStats.currentMana <CardData.manacost)
        {
            Debug.Log($"마나가 부족합니다! (필요 : {cardData})");
        }


        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(worldPos.x, worldPos.y, worldPos.z);
    }

    private void OnMouseUp()
    {
        isDragging = false;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        bool carUsed = false;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemyLayer));
        {
            
        }
        else if (Physics.Raycast(ray, out hit, Mathf.Infinity, playerLayer))
        {
          //CaracterStats playerStats = hit.collider.GetComponent<CaracterStats>();
            if (cardData.cardType == CardData.CardType.Heal)
            {
                playerStats.Heal(cardData.effectAmount);
                Debug.Log($"{cardData.cardName} 카드로 플레이어의 체력을 {cardData.effectAmount} 회복했습니다!");
                cardUsed = true;
            }
            else
            {
                Debug.Log("이 카드는 플레이어에게 사용할 수 없습니다.");
            }
        }
        else if (cardManager != null)
        {
            float distToDiscard = Vector3.Distance(transform.);
        }


        if (!cardUsed)
        {
            transform.position = originalPosition;
            cardManager.Arrangehand();
        }
        else
        {
            if (cardManager != null)
                cardManager.DiscardCard(cardIndex);
        }
    }





}
