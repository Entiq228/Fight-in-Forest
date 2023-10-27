using TMPro;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    //Currency txt UI
    public TMP_Text txt_Currency;
    //Default currency value
    public int defaultCurrency;
    //Current currency value
    public int currency;

    //Init (set the default values)
    public void Init()
    {
        currency = defaultCurrency;
        UpdateUI();
    }
    //Gain currency (init of value)
    public void Gain(int val)
    {
        currency += val;
        UpdateUI();
    }
    //Lose currency (input of value)
    public bool Use(int val)
    {
        if (EnoughCurrency(val))
        {
            currency -= val;
            UpdateUI();
            return true;
        }
        else{ return false; }
    }
    //Check avalability of currency
    public bool EnoughCurrency(int val)
    {
        //Check if the val is equal or more than currency
        if (val <= currency) { return true; }
        else { return false; }
    }
    //Update txt UI
    void UpdateUI() { txt_Currency.text = currency.ToString(); }
}