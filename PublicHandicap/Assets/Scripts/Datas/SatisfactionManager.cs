using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatisfactionManager : MonoBehaviour
{
    [SerializeField] private Image satisfactionBar;
    [SerializeField] private int maxSatisfaction = 500;

    public int currentSatisfaction;

    // Start is called before the first frame update
    private void Start()
    {
        currentSatisfaction = 50;

        UpdateVisual();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void UpdateVisual()
    {
        satisfactionBar.fillAmount = (float)currentSatisfaction / 100;
    }

    public void IncreaseSatisfaction(int value)
    {
        if (currentSatisfaction + value <= maxSatisfaction)
        {
            currentSatisfaction += value;

            UpdateVisual();
        }
    }

    public void DecreaseSatisfaction(int value)
    {
        if (currentSatisfaction - value >= 0)
        {
            currentSatisfaction -= value;

            UpdateVisual();
        }
    }
}
