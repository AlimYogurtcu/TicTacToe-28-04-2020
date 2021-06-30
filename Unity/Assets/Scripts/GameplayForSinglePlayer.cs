using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class GameplayForSinglePlayer : MonoBehaviour
{

    public int playersTurn; // 0 = X - 1 = O
    public int turnCount;// counts the numbers of turns
    public Sprite[] playIcons;// 0 = x icon and 1 = O icon
    public Button[] spaces;// playable space
    public int[] usedSpaces;// used spaces array number
    public Text winnerText;// shows round winner
    public GameObject winnerPanel, restartButtonPanel;
    public int randomNumber;// random number for computer to play
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
        playersTurn = 0;
        turnCount = 0;
        gameOver = false;
        winnerPanel.gameObject.SetActive(false);
        for (int i = 0; i < spaces.Length; i++)
        {
            spaces[i].interactable = true;
            spaces[i].GetComponent<Image>().sprite = null;
        }
        for (int i = 0; i < usedSpaces.Length; i++)
        {
            usedSpaces[i] = -100;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetRound()
    {
        GameSetup();
    }

    public void nextRoundButton()
    {
        winnerPanel.gameObject.SetActive(false);
        restartButtonPanel.gameObject.SetActive(true);
        GameSetup();
    }

    public void computerTurn(int numberOfGridForComputer)
    {
        if (gameOver)
        {
            Debug.Log("Game is Over For COmputer");
        }
        else
        {

            spaces[numberOfGridForComputer].image.sprite = playIcons[1];
            spaces[numberOfGridForComputer].interactable = false;
            usedSpaces[numberOfGridForComputer] = 2;
            if (turnCount > 4)
            {
                findWinner();
            }
            playersTurn = 0;
            turnCount++;
            Debug.Log("turnCount value of computer = " + turnCount);
        }
    }
    public void button(int numberOfGrid)
    {
        
        spaces[numberOfGrid].image.sprite = playIcons[0];
        spaces[numberOfGrid].interactable = false;


        usedSpaces[numberOfGrid] = 1;
        turnCount++;
        Debug.Log("turnCount value = " + turnCount);

        if (turnCount > 4)
        {
            findWinner();
        }
        playersTurn = 1;
        if (playersTurn == 1)
        {
            if(turnCount < 9)
            {
                while (spaces[randomNumber].interactable == false)
                {
                    randomNumber = Random.Range(0, 9);
                    //Debug.Log(randomNumber);
                }
                computerTurn(randomNumber);

            }

        }
    }

    void findWinner()
    {
        Debug.Log("Findwinner players turn value =" + playersTurn);
        Debug.Log("findWinner is working");
        int l1 = usedSpaces[0] + usedSpaces[1] + usedSpaces[2];
        int l2 = usedSpaces[3] + usedSpaces[4] + usedSpaces[5];
        int l3 = usedSpaces[6] + usedSpaces[7] + usedSpaces[8];
        int l4 = usedSpaces[0] + usedSpaces[3] + usedSpaces[6];
        int l5 = usedSpaces[1] + usedSpaces[4] + usedSpaces[7];
        int l6 = usedSpaces[2] + usedSpaces[5] + usedSpaces[8];
        int l7 = usedSpaces[0] + usedSpaces[4] + usedSpaces[8];
        int l8 = usedSpaces[2] + usedSpaces[4] + usedSpaces[6];
        var solutions = new int[] { l1, l2, l3, l4, l5, l6, l7, l8 };
        for (int i = 0; i < solutions.Length; i++)
        {
            if (solutions[i] == 6)
            {
                
                Debug.Log("Player O won.");
                gameOver = true;
                decideWinner(i);
            }
            else if (solutions[i] == 3)
            {
                Debug.Log("Player X won.");
                gameOver = true;
                decideWinner(i);
            }
        }
    }
    void decideWinner(int indexIn)
    {
        Debug.Log("decideWinner working");
        winnerPanel.gameObject.SetActive(true);
        restartButtonPanel.gameObject.SetActive(false);
        if (playersTurn == 0)
        {
            winnerText.text = "Player 1 Win";
        }
        else if (playersTurn == 1)
        {
            winnerText.text = "Comp. Win";
        }
    }
}
