using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    private int curHealth;
    [SerializeField]
    [Range(1, 5)]
    private int maxHealth;
    public bool isAlive = true;

    void Start()
    {

        curHealth = maxHealth;
    }


    void Update()
    {
        if(isAlive)
        {
            if (curHealth > maxHealth)
            {
                curHealth = maxHealth; 
            }
            if (curHealth <= 0)
            {
                Die();
            }
        }
    }

    public int getCurrentHealth()
    {
        return curHealth;
    }


    void Die()
    {
        isAlive = false;
        SceneManager.LoadScene(1);
    }

    public void hit()
    {
        curHealth--;
    }

}
