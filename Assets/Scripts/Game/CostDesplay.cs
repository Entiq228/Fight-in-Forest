using UnityEngine;

public class CostDesplay : MonoBehaviour
{
    [SerializeField] private int towerID;
    [SerializeField] private int towerCost;

    void Start()
    {
        towerCost = GameManager.instance.spawner.TowerCost(towerID);
        GetComponent<UnityEngine.UI.Text>().text = towerCost.ToString();
    }
}
