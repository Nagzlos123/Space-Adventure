using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuData : MonoBehaviour
{
    public StoreData storeData;


    public void SetPlayButtonOn()
    {
        storeData.playButtonOn = true;
    }
}
