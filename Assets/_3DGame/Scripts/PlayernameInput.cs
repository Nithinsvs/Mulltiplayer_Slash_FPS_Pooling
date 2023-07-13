using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(InputField))]
public class PlayernameInput : MonoBehaviour
{
    const string playerNamePrefKey = "PlayerName";
    InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<InputField>();
        inputField.text = PlayerPrefs.GetString(playerNamePrefKey);
    }

    public void SetPlayerName(string value)
    {
        PlayerPrefs.SetString(playerNamePrefKey, value);
    }
}
