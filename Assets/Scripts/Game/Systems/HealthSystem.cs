using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    //The UI text for the health count
    public TMP_Text txt_healthCount;
    public int defoultHealthCount;
    //Current health count
    public int healthCount;

    //Init the Health System (reset the health count)
    public void Init()
    {
        healthCount = defoultHealthCount;
        txt_healthCount.text = healthCount.ToString();
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
            //Call some reset values and stop the game from the manager
        }
    }
}