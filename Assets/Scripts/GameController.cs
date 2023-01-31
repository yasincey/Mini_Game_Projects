using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{

    public int whoTurn; //0 = x and 1 = o
    public int turnCounter; //count the number turn played
    public GameObject[] turnIcons; //displays whos tunr it is
    public Sprite[] playerIcons; //0 = x icon and 1 = y icon
    public Button[] tictactoeSpaces; // playable space for our game

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
        whoTurn = 0;
        turnCounter = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for (int i = 0; i < tictactoeSpaces.Length; i++)
        {
            tictactoeSpaces[i].interactable = true;
            tictactoeSpaces[i].GetComponent<Image>().sprite = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
