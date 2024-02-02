using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorSelectionButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button UiButton;
    public Image paddleReference;

    public bool isColorPlayer = false;
    public void OnButtonClick()
    {
        paddleReference.color = UiButton.colors.normalColor;

        if (isColorPlayer)
        {
            saveController.Instance.colorPlayer = paddleReference.color;
        }
        else
        {
            saveController.Instance.colorEnemy = paddleReference.color;
        }
    }
}
