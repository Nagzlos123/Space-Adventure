using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel = null;

    public void ActivePanel()
    {
        panel.gameObject.SetActive(true);
    }
  
}
