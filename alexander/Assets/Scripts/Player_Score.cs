using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour
{

    public float timeLeft = 120;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Scrore: " + (int)playerScore);
        if (timeLeft < 0.1)
        {
            SceneManager.LoadScene("grassy scene");
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "EndLevel")
        {
            CountScore();
        }

        if (trigger.gameObject.tag == "coin")
        {
            playerScore = playerScore + 1000;
            Destroy(trigger.gameObject);
        }
        
    }

    void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft*10);
        Debug.Log(playerScore);
    }
}
