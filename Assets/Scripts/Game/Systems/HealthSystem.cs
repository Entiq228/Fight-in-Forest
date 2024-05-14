using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public TMP_Text txt_healthCount;
    public int defoultHealthCount;
    public int healthCount;
    public GameObject Lose_Screen;

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

    public void LoseHealth()
    {
        if (healthCount < 1)
        {
            return;
        }
        healthCount--;
        txt_healthCount.text = healthCount.ToString();

        CheckHealthCount();
    }

    void CheckHealthCount()
    {
        if (healthCount < 1)
        {
            Debug.Log("You lost");
            Lose_Screen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}