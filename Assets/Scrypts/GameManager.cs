using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> GameStateChanged;
    [SerializeField] private Button P1Button = null;
    [SerializeField] private Button P2Button = null;
    [SerializeField] private Button P3Button = null;
    [SerializeField] private Button P4Button = null;
   


    void Awake()
    {
        Instance = this;
        
    }
    
    void Start()
    {
        //UpdateGameState(GameState.NewGame);
        //UpdateGameState(GameState.Planet4On);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.Purge:
                Purge();
                break;
            case GameState.NewGame:
                NewGame();
                break;
            case GameState.Planet1On:
                Planet1On();
                break;
            case GameState.Planet2On:
                Planet2On();
                break;
            case GameState.Planet3On:
                Planet3On();
                break;
            case GameState.Planet4On:
                Planet4On();
                break;
            
            default:
                break;
        }
        GameStateChanged?.Invoke(newState);
    }

    public enum GameState
    {
        Purge,
        NewGame,
        Planet1On,
        Planet2On,
        Planet3On,
        Planet4On,
       

    }
    public void Purge()
    {

        PlayerPrefs.DeleteKey("yourKredytNumber");
        PlayerPrefs.DeleteKey("yourCoinsNumber");
        PlayerPrefs.DeleteKey("ShopConponentPointer");
       
    }
    public void NewGame()
    {
        P1Button.interactable = false;
        P2Button.interactable = false;
        P3Button.interactable = false;
        P4Button.interactable = false;
        
    }
    public void Planet1On()
    {
        P1Button.interactable = true;
        P2Button.interactable = false;
        P3Button.interactable = false;
        P4Button.interactable = false;
    }
    public void Planet2On()
    {
        P1Button.interactable = true;
        P2Button.interactable = true;
        P3Button.interactable = false;
        P4Button.interactable = false;
    }

    public void Planet3On()
    {
        P1Button.interactable = true;
        P2Button.interactable = true;
        P3Button.interactable = true;
        P4Button.interactable = false;
    }

    public void Planet4On()
    {
        P1Button.interactable = true;
        P2Button.interactable = true;
        P3Button.interactable = true;
        P4Button.interactable = true;
    }

}
