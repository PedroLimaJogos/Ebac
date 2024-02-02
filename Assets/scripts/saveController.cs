using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    public static saveController _instance;

    public string namePlayer;
    public string nameEnemy;



    public static saveController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<saveController>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(saveController).Name);
                    _instance = singletonObject.AddComponent<saveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public string getName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void saveWinner(string winner)
    {
        PlayerPrefs.SetString("SavedWinner", winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString("SavedWinner");
    }

    public void clearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
