using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Player : MonoBehaviour, IVirtualButtonEventHandler
{

    public int maxHealth = 100;

    public int initialDamage = 10;

    public float throwingPower = 20f;

    public GameObject weapon;

    public Transform projectileSpawn;

    public GameObject attackButton;

    private int currentHealth;

    private int currentDamage;

    private int money = 0;


    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        currentDamage = initialDamage;

        attackButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Attack()
    {
        GameObject projectileWeapon = Instantiate(weapon, projectileSpawn.position, new Quaternion(0, 0, 0, 0));
        projectileWeapon.transform.SetParent(projectileSpawn);
        Vector3 force = projectileSpawn.forward * throwingPower;
        projectileWeapon.GetComponent<Rigidbody>().AddForce(force);
        Debug.Log("Attack!");
    }

    public void AddMoney(int money)
    {
        this.money += money;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void Die()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Pressed");
        Attack();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Released");
    }
}
