using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI uiWinner;
    void Start()
    {
        saveController.Instance.Reset();
        string lastWinner = saveController.Instance.GetLastWinner();

        if (lastWinner != "")
            uiWinner.text = "Último vencedor: " + lastWinner;
        else
            uiWinner.text = "";
    }


    // Update is called once per frame
    void Update()
    {

    }
}
