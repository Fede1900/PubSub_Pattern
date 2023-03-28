using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int level = 1;
    private int currentExp = 0;
    private int expNextLevel = 0;
    public int baseNextLevel = 300;

    private static Player _instance;

    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
                _instance = playerObject.GetComponent<Player>();
            }

            return _instance;
        }
    }

    public int Exp
    {
        get => currentExp;
        set
        {
            currentExp += value;

            PubSub.Instance.SendMessage("ExpObtained", currentExp);

            while (currentExp >= NextLevel)
            {
                Level++;
                Debug.Log("sono salito di livello");
            }
        }
    }

    public int Level
    {
        get => level;
        set
        {
            level = value;

            NextLevel += (baseNextLevel * level);

            PubSub.Instance.SendMessage("LevelGained", level);
        }
    }

    public int NextLevel
    {
        get => expNextLevel;
        set
        {
            expNextLevel = value;

            PubSub.Instance.SendMessage("ChangeExp", expNextLevel);
        }
    }

    private void Start()
    {
        Level = level;
        Exp = currentExp;
    }
}
