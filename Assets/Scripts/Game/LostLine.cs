using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostLine : MonoBehaviour
{
    public GameObject DeathScreen;
    void Start()
    {
        DeathScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            DeathScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
