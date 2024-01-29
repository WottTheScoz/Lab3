using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3 : MonoBehaviour
{

    public int amountOfPay = 0;
    //Initial input that can be edited for a different total payment
    void Start()
    {
        //Allows for editing to be made in the inspector
        CalculateBreakdown(amountOfPay);
    }

    void CalculateBreakdown(int amount)
    {
        //Breaks down the payment into different amounts.
        int hundredBills = amount / 100;
        amount %= 100;

        int fiftyBills = amount / 50;
        amount %= 50;

        int twentyBills = amount / 20;
        amount %= 20;

        int tenBills = amount / 10;
        amount %= 10;

        int fiveBills = amount / 5;
        amount %= 5;

        int oneBills = amount;

        Debug.Log($"You have been paid:");
        Debug.Log($"{hundredBills} x hundred dollar bills");
        Debug.Log($"{fiftyBills} x fifty dollar bills");
        Debug.Log($"{twentyBills} x twenty dollar bills");
        Debug.Log($"{tenBills} x ten dollar bills");
        Debug.Log($"{fiveBills} x five dollar bills");
        Debug.Log($"{oneBills} x one dollar bills");
    }
}


