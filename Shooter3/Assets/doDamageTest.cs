using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doDamage_Test : MonoBehaviour
{
    public float damageAmount = 60;
    public float afterSeconds = 5;
    public bool takeDamage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startDamage());
    }

    IEnumerator startDamage()
    {
        yield return new WaitForSeconds(afterSeconds);
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>().takeDamage(damageAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (takeDamage)
        {
            takeDamage = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>().takeDamage(damageAmount);
        }
    }
}


