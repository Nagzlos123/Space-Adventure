using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Text yourKredytNumber;
    [SerializeField] private Text kredytAmoundToBuy;
    [SerializeField] private Text yourCoins;
    [SerializeField] private Text descriptionText;
    [SerializeField] private TextMeshProUGUI shopElementName;
    [SerializeField] private GameObject buyButton;
    //public SaveObject saveObject;
  
    public ShopList listOfShopConponents;
    public Button CheatsButton;
    private float cheatsKredytAmount;
    private float currentKredytAmount;
    public int shopConponentPointer = 0;

    private void Awake()
    {
        
        PlayerPrefs.SetInt("ShopConponentPointer",0);
       

        GameObject childObject = (listOfShopConponents.shopElemnts[shopConponentPointer]) as GameObject;
        childObject.SetActive(true);


        getInfo();
      
        yourCoins.text = PlayerPrefs.GetFloat("yourCoinsNumber").ToString("");
    }
  


    public void rightButton()
    {
        if (shopConponentPointer < listOfShopConponents.shopElemnts.Length - 1)
        {
            GameObject.FindGameObjectWithTag("ShopComponent").SetActive(false);
            shopConponentPointer++;
            PlayerPrefs.SetInt("ShopConponentPointer", shopConponentPointer);
            Debug.Log("Ponter is working!" + shopConponentPointer);
            GameObject childObject = (listOfShopConponents.shopElemnts[shopConponentPointer]) as GameObject;
            childObject.SetActive(true);
            getInfo();
        }
    }

    public void leftButton()
    {
        if (shopConponentPointer > 0)
        {
            GameObject.FindGameObjectWithTag("ShopComponent").SetActive(false);
            shopConponentPointer--;
            PlayerPrefs.SetInt("ShopConponentPointer", shopConponentPointer);
            GameObject childObject = (listOfShopConponents.shopElemnts[shopConponentPointer]) as GameObject;
            childObject.SetActive(true);
            getInfo();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void GameManagerGameStateChanged(GameManager.GameState state)
    {

    }
    public void CheatButton()
    {
        cheatsKredytAmount = 100;

        PlayerPrefs.SetFloat("CheatsKredytAmount", cheatsKredytAmount);
        PlayerPrefs.SetFloat("yourKredytNumber", PlayerPrefs.GetFloat("yourKredytNumber") + PlayerPrefs.GetFloat("CheatsKredytAmount"));
        yourKredytNumber.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString("");
      
    }

    public void NewBuyButton()
    {


        if (PlayerPrefs.GetFloat("yourKredytNumber") >= listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().kredytAmoundToBuy)
        {
            PlayerPrefs.SetFloat("yourKredytNumber", PlayerPrefs.GetFloat("yourKredytNumber") - listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().kredytAmoundToBuy);
            yourKredytNumber.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString("");


            PlayerPrefs.SetString(listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().descriptionText.ToString(),
                                  listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().descriptionText.ToString());

            PlayerPrefs.SetInt("ResetAll", 0);

            if (listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().nameText == 
                listOfShopConponents.shopElemnts[0].GetComponent<ShopComponent>().nameText)
            {
                
                PlayerPrefs.SetInt("Planet1On", 1);
                PlayerPrefs.SetInt("NewGame", 0);
                
                KosmosData.Instance.LoadGameState();
            }
            if (listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().nameText ==
              listOfShopConponents.shopElemnts[1].GetComponent<ShopComponent>().nameText)
            {
                
               
                PlayerPrefs.SetInt("Planet2On", 1);
                PlayerPrefs.SetInt("NewGame", 0);
                KosmosData.Instance.LoadGameState();
            }
            if (listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().nameText ==
              listOfShopConponents.shopElemnts[2].GetComponent<ShopComponent>().nameText)
            {
                
                
                PlayerPrefs.SetInt("Planet3On", 1);
                PlayerPrefs.SetInt("NewGame", 0);
                KosmosData.Instance.LoadGameState();
            }
            if (listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().nameText ==
              listOfShopConponents.shopElemnts[3].GetComponent<ShopComponent>().nameText)
            {
                
               
                PlayerPrefs.SetInt("Planet4On", 1);
                PlayerPrefs.SetInt("NewGame", 0);
                KosmosData.Instance.LoadGameState();
            }
            if (listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().nameText ==
           listOfShopConponents.shopElemnts[4].GetComponent<ShopComponent>().nameText)
            {


                PlayerPrefs.SetInt("DamageUgrade", 1);
                
                KosmosData.Instance.LoadGameState();
            }
            if (listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().nameText ==
                listOfShopConponents.shopElemnts[5].GetComponent<ShopComponent>().nameText)
            {


                PlayerPrefs.SetInt("DamageUgrade", 2);

                KosmosData.Instance.LoadGameState();
            }

            if (listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().nameText ==
                listOfShopConponents.shopElemnts[6].GetComponent<ShopComponent>().nameText)
            {


                PlayerPrefs.SetInt("DamageUgrade", 3);

                KosmosData.Instance.LoadGameState();
            }

            if (listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().nameText ==
                listOfShopConponents.shopElemnts[7].GetComponent<ShopComponent>().nameText)
            {


                PlayerPrefs.SetInt("HpUgrade", 1);

                KosmosData.Instance.LoadGameState();
            }
            getInfo();
        }

    }

    public void Resete()
    {
        
        PlayerPrefs.DeleteKey(listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().descriptionText.ToString());
        getInfo();
    }
    public void ReseteAll()
    {
        PlayerPrefs.SetInt("ShopConponentPointer", 0);
        shopConponentPointer = PlayerPrefs.GetInt("ShopConponentPointer");

        for (int shopPointer = 0; shopPointer < 8; shopPointer++)
        {
            PlayerPrefs.SetInt("ShopConponentPointer", shopPointer);
            shopConponentPointer = PlayerPrefs.GetInt("ShopConponentPointer");
            PlayerPrefs.DeleteKey(listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().descriptionText.ToString());
            shopConponentPointer--;
            getInfo();
        }

        PlayerPrefs.SetInt("ShopConponentPointer", 0);
        shopConponentPointer = PlayerPrefs.GetInt("ShopConponentPointer");
        getInfo();
        
    }
    public void BuyButton()
    {


        if (PlayerPrefs.GetFloat("yourKredytNumber") >= PlayerPrefs.GetFloat("KredytAmoundToBuy"))
        {
            PlayerPrefs.SetFloat("yourKredytNumber", PlayerPrefs.GetFloat("yourKredytNumber") - PlayerPrefs.GetFloat("KredytAmoundToBuy"));
            yourKredytNumber.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString("");
            
        }

    }

    public void getInfo()
    {
        if (listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().descriptionText.ToString() ==
            PlayerPrefs.GetString(listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().descriptionText.ToString()))
        {
            descriptionText.text = "Owned";

            buyButton.SetActive(false);
            yourKredytNumber.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString("");

            return;

        }
        yourKredytNumber.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString("");

        kredytAmoundToBuy.text = listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().kredytAmoundToBuy.ToString();

        descriptionText.text = listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().descriptionText.ToString();
        shopElementName.text = listOfShopConponents.shopElemnts[PlayerPrefs.GetInt("ShopConponentPointer")].GetComponent<ShopComponent>().nameText.ToString();



        buyButton.SetActive(buyButton);

    }

}
