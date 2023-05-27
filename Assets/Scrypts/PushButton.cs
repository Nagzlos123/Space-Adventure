using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    // Assign both of these in the editor.
    public int kredytAmoundToBuy;
    Text text;
    Text descriptionText;
    private string description;
    public GameObject Part1Image;
    public GameObject Part2Image;
    public GameObject Part3Image;
    public GameObject Part4Image;
    public GameObject Up1Image;
    public GameObject Up2Image;
    public GameObject Up3Image;
    public GameObject Up4Image;
    public Button Part1Button;
    public Button Part2Button;
    public Button Part3Button;
    public Button Part4Button;
    public Button Up1Button;
    public Button Up2Button;
    public Button Up3Button;
    public Button Up4Button;
    public Button PartsButton;
    public Button UpgradeButton;
    void Start()
    {
        text = GameObject.Find("KredytAmoundToBuy").GetComponent<Text>();
        descriptionText = GameObject.Find("DescriptionText").GetComponent<Text>();

        PartsButton.onClick.AddListener(() => {
            Up1Image.SetActive(false);
            Up2Image.SetActive(false);
            Up3Image.SetActive(false);
            Up4Image.SetActive(false);
        });
        UpgradeButton.onClick.AddListener(() => {
            Part1Image.SetActive(false);
            Part2Image.SetActive(false);
            Part3Image.SetActive(false);
            Part4Image.SetActive(false);
        });
        Part1Button.onClick.AddListener(() => {
            Part1Image.SetActive(true);
            Part2Image.SetActive(false);
            Part3Image.SetActive(false);
            Part4Image.SetActive(false);
            
        });
        Part2Button.onClick.AddListener(() => {
            Part1Image.SetActive(false);
            Part2Image.SetActive(true);
            Part3Image.SetActive(false);
            Part4Image.SetActive(false);
            
            //text.text = kredytAmoundToBuy.ToString();
        });
        Part3Button.onClick.AddListener(() => {
            Part1Image.SetActive(false);
            Part2Image.SetActive(false);
            Part3Image.SetActive(true);
            Part4Image.SetActive(false);
        });
        Part4Button.onClick.AddListener(() => {
            Part1Image.SetActive(false);
            Part2Image.SetActive(false);
            Part3Image.SetActive(false);
            Part4Image.SetActive(true);
        });
        Up1Button.onClick.AddListener(() => {
            Up1Image.SetActive(true);
            Up2Image.SetActive(false);
            Up3Image.SetActive(false);
            Up4Image.SetActive(false);
        });
        Up2Button.onClick.AddListener(() => {
            Up1Image.SetActive(false);
            Up2Image.SetActive(true);
            Up3Image.SetActive(false);
            Up4Image.SetActive(false);
        });
        Up3Button.onClick.AddListener(() => {
            Up1Image.SetActive(false);
            Up2Image.SetActive(false);
            Up3Image.SetActive(true);
            Up4Image.SetActive(false);
        });
        Up4Button.onClick.AddListener(() => {
            Up1Image.SetActive(false);
            Up2Image.SetActive(false);
            Up3Image.SetActive(false);
            Up4Image.SetActive(true);
        });
    }
    void Update()
    { 
        if( Part1Image.activeSelf)
        {
            kredytAmoundToBuy = 1000;
            text.text = kredytAmoundToBuy.ToString();
            description = "Gives you ability to travel to Planet1.";
            descriptionText.text = description;
            PlayerPrefs.SetFloat("KredytAmoundToBuy", kredytAmoundToBuy);
        }
        else
        {
            kredytAmoundToBuy = 0;
            text.text = kredytAmoundToBuy.ToString();
        }

        if (Part2Image.activeSelf)
        {
            kredytAmoundToBuy = 2000;
            text.text = kredytAmoundToBuy.ToString();
            description = "Gives you ability to travel to Planet2.";
            descriptionText.text = description;
            PlayerPrefs.SetFloat("KredytAmoundToBuy", kredytAmoundToBuy);
        }

        if (Part3Image.activeSelf)
        {
            kredytAmoundToBuy = 3000;
            text.text = kredytAmoundToBuy.ToString();
            description = "Gives you ability to travel to Planet3.";
            descriptionText.text = description;
            PlayerPrefs.SetFloat("KredytAmoundToBuy", kredytAmoundToBuy);
        }

        if (Part4Image.activeSelf)
        {
            kredytAmoundToBuy = 4000;
            text.text = kredytAmoundToBuy.ToString();
            description = "Gives you ability to travel to Planet4.";
            descriptionText.text = description;
            PlayerPrefs.SetFloat("KredytAmoundToBuy", kredytAmoundToBuy);
        }

        if (Up1Image.activeSelf)
        {
            kredytAmoundToBuy = 100;
            text.text = kredytAmoundToBuy.ToString();
            description = "Opis Up1";
            descriptionText.text = description;
            PlayerPrefs.SetFloat("KredytAmoundToBuy", kredytAmoundToBuy);
        }

        if (Up2Image.activeSelf)
        {
            kredytAmoundToBuy = 200;
            text.text = kredytAmoundToBuy.ToString();
            description = "Opis Up2";
            descriptionText.text = description;
            PlayerPrefs.SetFloat("KredytAmoundToBuy", kredytAmoundToBuy);
        }

        if (Up3Image.activeSelf)
        {
            kredytAmoundToBuy = 300;
            text.text = kredytAmoundToBuy.ToString();
            description = "Opis Up3";
            descriptionText.text = description;
            PlayerPrefs.SetFloat("KredytAmoundToBuy", kredytAmoundToBuy);
        }

        if (Up4Image.activeSelf)
        {
            kredytAmoundToBuy = 150;
            text.text = kredytAmoundToBuy.ToString();
            description = "Opis Up4";
            descriptionText.text = description;
            PlayerPrefs.SetFloat("KredytAmoundToBuy", kredytAmoundToBuy);
        }
    }
}
