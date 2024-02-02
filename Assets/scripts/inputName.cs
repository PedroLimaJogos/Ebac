using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inputName : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPlayer;

    public TMP_InputField inputField;
    void Start()
    {
        inputField.onValueChanged.AddListener(UpdateName);
    }

    // Update is called once per frame
    public void UpdateName(string name)
    {
        if (isPlayer)
        {
            saveController.Instance.namePlayer = name;
        }
        else
        {
            saveController.Instance.nameEnemy = name;
        }
    }

}
