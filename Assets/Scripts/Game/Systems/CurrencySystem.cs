using System;
using TMPro;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    [SerializeField] private int defaultCurrency;
    public int currency;

    public Action<int> currencyChanged;

    public void Init()
    {
        currency = defaultCurrency;
        currencyChanged?.Invoke(currency);
    }
    public void Gain(int val)
    {
        currency += val;
        currencyChanged?.Invoke(currency);
    }
    public bool Use(int val)
    {
        if (EnoughCurrency(val))
        {
            currency -= val;
            currencyChanged?.Invoke(currency);
            return true;
        }
        else{ return false; }
    }
    public bool EnoughCurrency(int val)
    {
        if (val <= currency) { return true; }
        else { return false; }
    }
}