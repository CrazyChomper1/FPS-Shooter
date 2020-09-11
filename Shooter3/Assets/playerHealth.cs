using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float overallHealth = 100;
    public float currentHealth;
    public Image healthbar;

    public float minHealthforDamageScreen = 50;
    public Image damageScreen;
    public float regenWait = 5;
    public float regenTime = 5;
    public bool takenDamage;
    private float currentRegenTime = 0;
    private float currentRegenWaitTime = 0;

    public void takeDamage(float damage)
    {
        takenDamage = true;
        currentHealth -= damage;
        damageScreen.color = new Color(1, 0, 0, Mathf.Clamp(1 - (currentHealth / overallHealth), 0, .6f));



        healthbar.fillAmount = currentHealth / overallHealth;
        if (currentHealth <= 0)
        {
            //Death
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = overallHealth;
        healthbar.fillAmount = currentHealth / overallHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (takenDamage == true)
        {

            if (currentRegenTime <= regenWait)
            {
                currentRegenTime += Time.deltaTime;
            }
            else
            {
                if (currentRegenWaitTime <= regenTime)
                {
                    currentRegenWaitTime += Time.deltaTime;
                    float num = Mathf.Lerp(damageScreen.color.a, 0, Time.deltaTime);
                    damageScreen.color = new Color(1, 0, 0, num);


                    currentHealth = Mathf.Lerp(currentHealth, overallHealth, Time.deltaTime);
                    healthbar.fillAmount = currentHealth / overallHealth;
                }
                else
                {
                    currentHealth = overallHealth;
                    damageScreen.color = new Color(1, 0, 0, 0);
                    currentRegenTime = 0;
                    currentRegenWaitTime = 0;
                    takenDamage = false;
                }

            }
        }
        else
        {

            currentRegenTime = 0;
            currentRegenWaitTime = 0;
        }
    }
}



