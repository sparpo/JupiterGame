using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GillbertStats : MonoBehaviour
{
    public int health;
    private const int maxHealth = 100; // cannot be changed

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health>maxHealth) {
            health = maxHealth;
        }
        if(Input.GetKeyDown(KeyCode.Space)) {
            health--;
        }
    }
    
    public void setHealth(int h) {
        health = h;
    }
    public int getHealth() {
        return health;
    }
    public void changeHealth(int amount) {
        health+= amount;
    }
}
