using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{

    public int whoTurn; //0 = x and 1 = o
    public int turnCounter; //count the number turn played
    public GameObject[] turnIcons; //displays whos tunr it is
    public Sprite[] playerIcons; //0 = x icon and 1 = y icon
    public Button[] tictactoeSpaces; // playable space for our game
    public int[] markSpaces; //ID's which space was marked by wich player;
    public Text winnerText; //Hold the text component of the winner text;
    public GameObject[] winningLine; //Hold all the different line for show that ther is a winner
    public GameObject winnerPanel;
    public bool gameIsRun;
    public int xPlayersScore;
    public int oPlayersScore;
    public Text xPlayersScoreText;
    public Text oPlayersScoreText;
    public Button xPlayersButton;
    public Button oPlayersButton;
    public AudioSource buttonClickAudio;
    public AudioSource ClickAudio;

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
        whoTurn = 0;
        turnCounter = 0;
        gameIsRun = true;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for (int i = 0; i < tictactoeSpaces.Length; i++)
        {
            tictactoeSpaces[i].interactable = true;
            tictactoeSpaces[i].GetComponent<Image>().sprite = null;
        }
        for (int i = 0; i < markSpaces.Length; i++)
        {
            markSpaces[i] = -100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TicTacToeButton(int WichNumber)
    {
        xPlayersButton.interactable = false;
        oPlayersButton.interactable = false;
        tictactoeSpaces[WichNumber].image.sprite = playerIcons[whoTurn];
        tictactoeSpaces[WichNumber].interactable = false;

        markSpaces[WichNumber] = whoTurn+1;
        turnCounter++;

        if (turnCounter > 4)
        {
            WinnerCheck();
        }

        if (whoTurn == 0 && gameIsRun)
        {
            whoTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else if (whoTurn == 1 && gameIsRun)
        {
            whoTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }

    void WinnerCheck()
    {
        int s1 = markSpaces[0] + markSpaces[1] + markSpaces[2];
        int s2 = markSpaces[3] + markSpaces[4] + markSpaces[5];
        int s3 = markSpaces[6] + markSpaces[7] + markSpaces[8];
        int s4 = markSpaces[0] + markSpaces[3] + markSpaces[6];
        int s5 = markSpaces[1] + markSpaces[4] + markSpaces[7];
        int s6 = markSpaces[2] + markSpaces[5] + markSpaces[8];
        int s7 = markSpaces[0] + markSpaces[4] + markSpaces[8];
        int s8 = markSpaces[2] + markSpaces[4] + markSpaces[6];
        var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
        for(int i = 0; i < solutions.Length; i++)
        {
            if (solutions[i] == 3*(whoTurn+1))
            {
                WinnerDisplay(i);
                return;
            }
        }

    }

    void WinnerDisplay(int indexIn)
    {
        gameIsRun = false;
        winnerPanel.gameObject.SetActive(true);
        if(whoTurn == 0)
        {
            xPlayersScore++;
            xPlayersScoreText.text = xPlayersScore.ToString();
            winnerText.color = Color.red;
            turnIcons[1].SetActive(false);
            turnIcons[0].SetActive(true);
        }
        else if(whoTurn == 1)
        {
            oPlayersScore++;
            oPlayersScoreText.text = oPlayersScore.ToString();
            winnerText.color = Color.blue;
            turnIcons[1].SetActive(true);
            turnIcons[0].SetActive(false);
        }
        winningLine[indexIn].SetActive(true);

    }

    public void Rematch()
    {
        GameSetup();
        for (int i = 0; i < winningLine.Length; i++)
        {
            winningLine[i].SetActive(false);
        }
        winnerPanel.SetActive(false);
        xPlayersButton.interactable = true;
        oPlayersButton.interactable = true;
    }

    public void Restart()
    {
        Rematch();
        xPlayersScore = 0;
        oPlayersScore = 0;
        xPlayersScoreText.text = "0";
        oPlayersScoreText.text = "0";
    }

    public void SwitchPlayer(int whichPlayer)
    {
        if(whichPlayer == 0)
        {
            whoTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
        else if(whichPlayer == 1)
        {
            whoTurn = 1;
            turnIcons[1].SetActive(true);
            turnIcons[0].SetActive(false);
        }
    }

    public void PlayButtonClick()
    {
        buttonClickAudio.Play();
    }
    public void PlayClick()
    {
        ClickAudio.Play();
    }
}
