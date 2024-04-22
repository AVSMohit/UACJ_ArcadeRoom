using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudController : MonoBehaviour
{
    public static HudController instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] TMP_Text interactiomText;

    public void EnableInteractionText(string text)
    {
        interactiomText.text = text + "(F)";
        interactiomText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactiomText.gameObject.SetActive(false);
    }
   
}
