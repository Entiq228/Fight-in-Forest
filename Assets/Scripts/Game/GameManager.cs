using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake() { instance = this; }
    public Spawner spawner;
    public HealthSystem healthSystem;
    public CurrencySystem currency;

    private void Start()
    {
        GetComponent<HealthSystem>().Init();
        GetComponent<CurrencySystem>().Init();

        StartCoroutine(WaveStartDelay());
    }
    IEnumerator WaveStartDelay()
    {
        yield return new WaitForSeconds(2f);
        GetComponent <EnemySpawner>().StartSpawning();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
