using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text DieScoreText;
    [SerializeField] private GameObject DiePanel;

    float score;
    void Start()
    {
        
    }

    void Update()
    {
        scoreText.text = "Points : " + ((int)player.position.z / 2).ToString();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Die()
    {
        DiePanel.SetActive(true);
        score = ((int)player.position.z / 2);
        DieScoreText.text = "You score :" + score;
        Time.timeScale = 0;

    }
}
