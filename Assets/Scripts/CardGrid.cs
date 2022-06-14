using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardGrid : MonoBehaviour
{
    public GameObject cardPrefab;

    public int boardSizeX;
    public int boardSizeY;
    
    public GameObject[,] board;

    public TMP_Text ranksTotal;
    
    private void Start()
    {
        board = new GameObject[boardSizeX, boardSizeY];
        
        InitializeBoard();

        //ranksTotal.text = "The sum of all ranks is " + BoardSum() + ".";
        ranksTotal.text = "";
    }
    
    private void InitializeBoard()
    {
        float cardSizeX = 115f;
        float cardSizeY = 150f;

        int boardXLength = board.GetLength(0);
        int boardYLength = board.GetLength(1);
        
        for (int i = 0; i < boardXLength; i++)
        {
            for (int j = 0; j < boardYLength; j++)
            {
                float xPos = cardSizeX * (i + 0.5f) - cardSizeX * boardXLength / 2;
                float yPos = cardSizeY * (j + 0.5f) - cardSizeY * boardYLength / 2;
                float zPos = 0f;
                
                Vector3 pos = new Vector3(xPos, yPos, zPos);
                
                GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity, transform);
                //newCard.GetComponent<Card>().SetRankAndSuit((i + j * boardXLength) % 13,j % 4);
                newCard.GetComponent<Card>().SetRankAndSuitAtRandom();
                board[i, j] = newCard;
            }
        }
    }
    
    private int BoardSum()
    {
        int temp = 0;
        
        foreach (var cardObj in board)
        {
            temp += (int)cardObj.GetComponent<Card>().rank + 1;
        }

        return temp;
    }
}
