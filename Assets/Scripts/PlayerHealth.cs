using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    // private EnemyAnimation enemyAnim;
    // private NavMeshAgent navAgent;
    // private EnemyController enemyController;

    [SerializeField]
    float playerHealth = 100f;
    public float maxPlayerHealth;

    public float healthIncrease;

    public Slider healthBar;

    //public bool isPlayer, isEnemy;
    //private PlayerStats playerStats;




    // Start is called before the first frame update
    private void OnEnable()
    {
        playerHealth = maxPlayerHealth;

        healthBar.maxValue = maxPlayerHealth;

        UpdateUI();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    //health Increases

    public void Health(float increaseObject)
    {
        playerHealth += healthIncrease;
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    //Update Health 
    public void UpdateUI()
    {
        playerHealth = Mathf.Clamp(playerHealth, 0f, 100f);
       
        healthBar.value = playerHealth;
        
    }
}
