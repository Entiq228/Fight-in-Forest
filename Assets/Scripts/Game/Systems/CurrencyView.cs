using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TMP_Text currencyTMP;
    [SerializeField] private CurrencySystem currencySystem;

    private void Start()
    {
        currencySystem.currencyChanged += UpdateCurrency;
        UpdateCurrency(currencySystem.currency);
    }

    void UpdateCurrency(int currency)
    {
        currencyTMP.text = currency.ToString();
    }
}