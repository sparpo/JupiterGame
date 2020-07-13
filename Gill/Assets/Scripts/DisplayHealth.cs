using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gillbert;
    private int health;
    public Text healthText;
    public Slider healthBar;
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        health = gillbert.GetComponent<GillbertStats>().getHealth();
        healthText.text = "Health: " + health + "%";
        healthBar.value = health;
    }
}
