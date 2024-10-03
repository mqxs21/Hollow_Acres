using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    public int currencyAmount = 0;
    public TextMeshProUGUI currencyText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = currencyAmount.ToString();
    }
    public void addCurrency(int amount){
        currencyAmount+=amount;
    }
    public void removeCurrency(int amount){
        currencyAmount-=amount;
    }
}
