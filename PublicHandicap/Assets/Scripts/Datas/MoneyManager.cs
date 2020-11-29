using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyDisplayer;
    [SerializeField] public int money;

    // Start is called before the first frame update
    private void Start()
    {
        money = 10;
        UpdateVisual();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void UpdateVisual()
    {
        moneyDisplayer.text = money.ToString() + " $";
    }

    public void WinMoney(int value)
    {
        money += value;

        UpdateVisual();
    }

    // Return true if player can pay for upgrade
    public bool Pay(int value)
    {
        if (value > money)
        {
            return false;
        }
        else
        {
            money -= value;
            UpdateVisual();
            return true;
        }
    }
}
