using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text DieScoreText;
    [SerializeField] private GameObject DiePanel;

    float score;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Points : " + ((int)player.position.z / 2).ToString();
    }

    public void Restart()
    {
        DiePanel.SetActive(false);
        Time.timeScale = 1;

    }
    public void Die()
    {
        DiePanel.SetActive(true);
        score = ((int)player.position.z / 2);
        DieScoreText.text = "You score :" + score;
        Time.timeScale = 0;

    }
}
