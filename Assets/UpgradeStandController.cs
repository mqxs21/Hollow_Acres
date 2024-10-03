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
    public int maxHp;
    void Start()
    {
        this.maxHp = enemyAI.maxHp;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (weaponAttackDamage != maxHp && int.Parse(damageText.text) <maxHp)
        {
            //damageText.text = (int.Parse(damageText.text)+upgradeDamageAmount).ToString();
            weaponAttackDamage+=upgradeDamageAmount;
        }
    }
}
