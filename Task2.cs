using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2 : MonoBehaviour
{
    //Determine the book cover price and quantity sold respectively.
    public float XCoverPrice;
    public int YCopiesSold;

    //How much the bookstore pays to buy Y copies of a book with X cover price.
    float BookstoreCost;

    //How much the bookstore profits from selling Y copies of a book with X cover price.
    float BookstoreProfit;

    //The discount bookstores receive on the cover price.
    float BookstoreDiscount = 0.40f;

    //The shipping costs of the first and any additional books respectively.
    float ShippingCostFirstBook = 3;
    float ShippingCostAdditionalBooks = 0.75f;

    void Start()
    {
        CalculateAll();

        Debug.Log("If the bookstore buys " + YCopiesSold + " copies of a book that costs $" + XCoverPrice + ", they must pay: $" + BookstoreCost);
        Debug.Log("If the bookstore sells " + YCopiesSold + " copies of a book that costs $" + XCoverPrice + ", they make a profit of: $" + BookstoreProfit);
    }

    //Checks if no copies were bought/sold and calculate's both the bookstore's cost and profit.
    void CalculateAll()
    {
        if (YCopiesSold < 1)
        {
            //No copies sold means no cost/profit. CalculateMoney formula does not work with a number < 1.
            BookstoreCost = 0;
            BookstoreProfit = 0;
        }
        else
        {
            //Calculates what the bookstore pays to buy Y amount of books at X price.
            CalculateMoney(ref BookstoreCost, BookstoreDiscount);

            //Calculates what the bookstore earns from selling Y amount of books at X price.
            CalculateMoney(ref BookstoreProfit, 0);
        }
    }

    //Calculates a quantity based on the book's price (X), quantity bought/sold (Y), shipping costs, and any discount on the cover price.
    void CalculateMoney(ref float Result, float Discount)
    {
        Result = YCopiesSold * (XCoverPrice - (XCoverPrice * Discount)) + (ShippingCostFirstBook + (YCopiesSold - 1) * ShippingCostAdditionalBooks);
    }
}
