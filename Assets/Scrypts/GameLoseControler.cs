using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoseControler : MonoBehaviour
{
    private Transform player;
    public Button OkButton;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if(player == null)
        {
            OkButton.onClick.AddListener(() => {
                SceneManager.LoadScene("MainMenu");
            });
        }
    }


}
