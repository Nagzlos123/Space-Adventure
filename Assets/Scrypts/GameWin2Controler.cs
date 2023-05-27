using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWin2Controler : MonoBehaviour
{
    public Button OkButton;
    private float kredytAmount;
    //public SaveObject saveObject;
    [SerializeField] Text coinWinNumber = null;
    private float coinAmountWin;


    // Start is called before the first frame update
    void Start()
    {
        //coinWinNumber = GameObject.Find("CoinWinNumber").GetComponent<Text>();
        coinWinNumber.text = PlayerPrefs.GetFloat("coinAmountWin").ToString();

       

        //yourKredytNumber.text = 0 + kredytWinNumber.text;
        OkButton.onClick.AddListener(() => {


            PlayerPrefs.SetFloat("yourCoinsNumber", PlayerPrefs.GetFloat("yourCoinsNumber") + PlayerPrefs.GetFloat("coinAmountWin"));

            //saveObject = SaveManager.Load();

            //Debug.Log(saveObject);


        });


    }


}

