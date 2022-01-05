using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class TimeManager : MonoBehaviour
{

    [SerializeField]
    private Text timerText;
    public float timeToWin = 300f;
    private bool gameOver;
    private GameObject artifact;
    private StringBuilder stringBuilder;
    void Awake()
    {
        artifact = GameObject.FindWithTag("Artifact");
        stringBuilder = new StringBuilder();
    }
    private void Update()
    {
        if (gameOver|| !artifact)
        {
            return;
        }
        timeToWin -= Time.deltaTime;
        if (timeToWin <= 0f)
        {
            timeToWin = 0f;
            gameOver = true;
            Destroy(artifact);

            //show win panel
            GameOverUIController.instance.GameOver("You Win!");
        }
        // timerText.text = "Time Remaining: " + (int)timeToWin; <=== This is inefficient and causes garbage to be collected
        DisplayTime((int)timeToWin);
    }

    void DisplayTime(int time)
    {
        //reset stringbuilder
        stringBuilder.Length = 0;
        stringBuilder.Append("Time Remaining: ");
        stringBuilder.Append(time);
        timerText.text = stringBuilder.ToString();
    }

}
