using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// JULIEN

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerDisplayer;
    [SerializeField] private float timerRef;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerRef;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            DataSaver.Instance.satisfactionValue = FindObjectOfType<SatisfactionManager>().currentSatisfaction;

            SceneManager.LoadScene("EndGame");
        }

        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        timerDisplayer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
