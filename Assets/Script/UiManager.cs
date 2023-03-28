using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI expText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI nextExpText;

    // Start is called before the first frame update
    void Start()
    {
        PubSub.Instance.RegisteredFunction("ExpObtained", OnExpObtained);
        PubSub.Instance.RegisteredFunction("LevelGained", OnLevelGained);
        PubSub.Instance.RegisteredFunction("ChangeExp", OnChangeExp);
    }

    private void OnExpObtained(object content)
    {
        if (content is not int)
        {
            return;
        }

        expText.text = "Exp: " + content.ToString();
    }

    private void OnLevelGained(object Content)
    {
        if (Content is not int)
        {
            return;
        }

        levelText.text = "Level: " + Content.ToString();
    }

    private void OnChangeExp(object content)
    {
        if (content is not int)
        {
            return;
        }

        nextExpText.text = "Exp needed: " + content.ToString();
    }
}
