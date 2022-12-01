using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text presentsText;

    [SerializeField] private Text recordText;
    // Start is called before the first frame update
    void Start()
    {
        int LastRunScore = PlayerPrefs.GetInt("lastRunScore");
        int record = PlayerPrefs.GetInt("recordScore");
        int present = PlayerPrefs.GetInt("presents");
        presentsText.text = present.ToString();
        if(LastRunScore > record)
        {
            record = LastRunScore;
            PlayerPrefs.SetInt("recordScore",record);
            recordText.text = "HighScore " + record.ToString();
        }
        else
        {
            recordText.text = "HighScore " + record.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
