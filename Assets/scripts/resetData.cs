using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetData : MonoBehaviour
{
    public void clearData()
    {
        saveController.Instance.clearSave();
    }
}
