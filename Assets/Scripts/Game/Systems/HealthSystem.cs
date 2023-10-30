using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    //The UI text for the health count
    public TMP_Text txt_healthCount;
    public int defoultHealthCount;
    //Current health count
    public int healthCount;
    public GameObject Lose_Screen;

    //Init the Health System (reset the health count)
    public void Init()
    {
        healthCount = defoultHealthCount;
        txt_healthCount.text = healthCount.ToString();
    }

    void Start()
    {
        Lose_Screen.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            LoseHealth();
        }
    }

    //Lose health count
    public void LoseHealth()
    {
        if(healthCount < 1)
        {
            return;
        }
        healthCount--;
        txt_healthCount.text = healthCount.ToString();

        CheckHealthCount();
    }

    //Check health count for losing
    void CheckHealthCount()
    {
        if(healthCount < 1)
        {
            Debug.Log("You lost");
            Lose_Screen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}