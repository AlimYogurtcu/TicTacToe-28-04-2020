using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{

    public int playersTurn; // 0 = X - 1 = O
    public int turnCount;// counts the numbers of turns
    public Sprite[] playIcons;// 0 = x icon and 1 = O icon
    public Button[] spaces;// playable space
    public int[] usedSpaces;// used spaces array number
    public Text winnerText;// shows round winner
    public GameObject winnerPanel,restartButtonPanel,player1Panel,player1PanelBlur,player2Panel,player2PanelBlur;
    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
        playersTurn = 0;
        turnCount = 0;
        winnerPanel.gameObject.SetActive(false);
        chageBlur(0);
        for (int i = 0; i < spaces.Length; i++)
        {
            spaces[i].interactable = true;
            spaces[i].GetComponent<Image>().sprite = null;
        }
        for(int i = 0; i < usedSpaces.Length; i++)
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

    public void chageBlur(int turn)
    {
        if (turn == 0)
        {
            player1Panel.gameObject.SetActive(true);
            player2Panel.gameObject.SetActive(false);
            player1PanelBlur.gameObject.SetActive(false);
            player2PanelBlur.gameObject.SetActive(true);
        }
        else if (turn == 1)
        {
            player1Panel.gameObject.SetActive(false);
            player2Panel.gameObject.SetActive(true);
            player1PanelBlur.gameObject.SetActive(true);
            player2PanelBlur.gameObject.SetActive(false);
        }
    }

    public void button(int numberOfGrid)
    {
        spaces[numberOfGrid].image.sprite = playIcons[playersTurn];
        spaces[numberOfGrid].interactable = false;




        usedSpaces[numberOfGrid] = playersTurn+1;
        turnCount++;

        if(turnCount > 4)
        {
            findWinner();
        }
        if(playersTurn == 0)
        {
            chageBlur(1);
            playersTurn = 1;
        }
        else
        {
            chageBlur(0);
            playersTurn = 0;
        }
    }
    

    void findWinner()
    {
        int l1 = usedSpaces[0] + usedSpaces[1] + usedSpaces[2];
        int l2 = usedSpaces[3] + usedSpaces[4] + usedSpaces[5];
        int l3 = usedSpaces[6] + usedSpaces[7] + usedSpaces[8];
        int l4 = usedSpaces[0] + usedSpaces[3] + usedSpaces[6];
        int l5 = usedSpaces[1] + usedSpaces[4] + usedSpaces[7];
        int l6 = usedSpaces[2] + usedSpaces[5] + usedSpaces[8];
        int l7 = usedSpaces[0] + usedSpaces[4] + usedSpaces[8];
        int l8 = usedSpaces[2] + usedSpaces[4] + usedSpaces[6];
        var solutions = new int[] { l1, l2, l3, l4, l5, l6, l7, l8 };
        for(int i = 0; i < solutions.Length; i++)
        {
            if(solutions[i] == 3 * (playersTurn + 1))
            {
                Debug.Log("Player " + playersTurn + " won.");
                chageBlur(playersTurn);
                decideWinner(i);
            }
        }
    }
    void decideWinner(int indexIn)
    {
        winnerPanel.gameObject.SetActive(true);
        restartButtonPanel.gameObject.SetActive(false);
        if (playersTurn == 0)
        {
            winnerText.text = "Player 1 Win";
        }
        else if(playersTurn == 1)
        {
            winnerText.text = "Player 2 Win";
        }

    }
}
