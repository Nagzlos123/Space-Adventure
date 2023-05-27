using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject dataControl = null;
  
    private void Awake()
    {
       
            
        
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteKey("yourKredytNumber");
        PlayerPrefs.DeleteKey("yourCoinsNumber");
        PlayerPrefs.DeleteKey("ShopConponentPointer");
        PlayerPrefs.SetInt("Planet1On", 0);
        PlayerPrefs.SetInt("Planet2On", 0);
        PlayerPrefs.SetInt("Planet3On", 0);
        PlayerPrefs.SetInt("Planet4On", 0);
        PlayerPrefs.SetInt("NewGame", 1);
        PlayerPrefs.SetInt("ArtefactPanel", 0);
        PlayerPrefs.SetInt("ResetAll", 1);
        PlayerPrefs.SetInt("DamageUgrade", 0);
        PlayerPrefs.SetInt("HpUgrade", 0);

    }

    public void StartNewGame()
    {
        
        dataControl.GetComponent<MainMenuData>().SetPlayButtonOn();
    }
}

