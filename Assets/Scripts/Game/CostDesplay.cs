using UnityEngine;

public class CostDesplay : MonoBehaviour
{
    //FIELDS
    //TowerID
    public int towerID;
    //Cost value
    public int towerCost;

    //METHODS
    //Init (Fetch the value from the spawner tower list)
    void Start()
    {
        towerCost = GameManager.instance.spawner.TowerCost(towerID);
        GetComponent<UnityEngine.UI.Text>().text = towerCost.ToString();
    }
}
