using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefactPanel : MonoBehaviour
{
    public GameObject[] artefacts;
    [SerializeField] private int currentIndex;
    private int artefactIndex = 0;
    public StoreData storeData;
    // Start is called before the first frame update
    void Start()
    {
        //artefactIndex = currentIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOkButtonClic()
    {
        
        if(currentIndex<5)
        {
            storeData.artefact1PanelActive = false;
            storeData.artefact2PanelActive = false;
            storeData.artefact3PanelActive = false;
            storeData.artefact4PanelActive = false;
            //storeData.playButtonOn = false;
        }
        for (int artefactIndex = 0; artefactIndex <= 5; artefactIndex++)
        {
            if (artefactIndex != currentIndex)
            {
                artefacts[artefactIndex].SetActive(false);
            }
            else
            {
                PlayerPrefs.SetInt("ArtefactPanel", artefactIndex);
                artefacts[artefactIndex].SetActive(true);

            }
        }

      
        
            
        
        

    }
}
