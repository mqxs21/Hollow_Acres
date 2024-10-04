using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeStandController : MonoBehaviour
{
    public DayController dayController;
    public bool enemyCanGo = true;
    public Animator upgradeAnimator;
    public int weaponAttackDamage = 10;
    public FirstPersonController firstPersonController;
    public TextMeshProUGUI damageText;
    public EnemyAI enemyAI;
    public int upgradeDamageAmount = 10;
    public CurrencyController currencyController;
    public int maxHp;
    public int costUpgrade = 10;
    public InventoryController inventoryController;
    public int TomatoCost = 4;
    public int PepperCost = 3;
    public TextMeshProUGUI tomatoTextAmount;
    public TextMeshProUGUI pepperTextAmount;
    void Start()
    {
        this.maxHp = enemyAI.maxHp;
        inventoryController = FindObjectOfType<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        pepperTextAmount.text = "Current amount: " + (inventoryController.PepperAmount).ToString();
        tomatoTextAmount.text = "Current amount: " + (inventoryController.TomatoAmount).ToString();
        if (weaponAttackDamage != maxHp && int.Parse(damageText.text) <maxHp)
        {
            damageText.text = weaponAttackDamage.ToString();
        }else{
            damageText.text = enemyAI.maxHp.ToString() + "(MAX)";
        }
    }
    public void OpenUpMenu(){
        upgradeAnimator.SetBool("PopUp",true);
        enemyCanGo = false;
        dayController.dayNightCycleWork = false;
        firstPersonController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        

    }
    public void CloseMenu(){
        upgradeAnimator.SetBool("PopUp",false);
        firstPersonController.enabled = true;
        enemyCanGo = true;
        dayController.dayNightCycleWork = true;
        
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void UpgradeDamage(){
        if (weaponAttackDamage != maxHp && int.Parse(damageText.text) <maxHp && currencyController.currencyAmount>=costUpgrade)
        {
            //damageText.text = (int.Parse(damageText.text)+upgradeDamageAmount).ToString();
            currencyController.currencyAmount-=costUpgrade;
            weaponAttackDamage+=upgradeDamageAmount;
        }
    }
    public void BuyTomatoSeed(){
        if (currencyController.currencyAmount >= TomatoCost)
        {
            currencyController.currencyAmount -= TomatoCost;
            inventoryController.TomatoAmount ++;
        }
    }
    public void BuyPepperSeed(){
        if (currencyController.currencyAmount >= PepperCost)
        {
            currencyController.currencyAmount -= PepperCost;
            inventoryController.PepperAmount ++;
        }
    }
}
