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

    public float score;

    void Update()
    {
        scoreText.text = (((int)player.position.z / 2)).ToString();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void Die()
    {
        score = ((int)player.position.z / 2);
        DiePanel.SetActive(true);
        DieScoreText.text = "You score :" + score;
        Time.timeScale = 0;
        int LastRunScore = int.Parse(scoreText.text.ToString());
        PlayerPrefs.SetInt("lastRunScore",LastRunScore);

    }
}
