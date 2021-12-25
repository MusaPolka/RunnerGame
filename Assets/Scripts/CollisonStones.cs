using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonStones : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth;
    public static bool IsLose = false;
    public HealthBar healthBar;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Log" || collision.gameObject.tag == "Stone") 
        {
            Destroy(collision.gameObject);
            TakeDamage(20);
        }
    }

    
    void Start()
    {
        curHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); ;
        IsLose = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth == 0)
        {
            IsLose = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void TakeDamage(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }
}
