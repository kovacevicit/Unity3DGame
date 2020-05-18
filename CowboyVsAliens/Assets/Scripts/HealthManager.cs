using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health=100;
    Text text;
    public GameObject GameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "HP: " + health;
    }
}
