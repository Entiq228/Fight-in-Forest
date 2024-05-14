using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> towersPrefabs;
    [SerializeField] private GameObject spawnTowerRoot;
    [SerializeField] private List<Image> towersUI;
    [SerializeField] private int spawnID = -1;
    [SerializeField] private Tilemap spawnTilemap;

    void Update()
    {
        if (spawnID != -1)
        {
            DetectSpawnPoint();
        }
    }

    void DetectSpawnPoint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);
            if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                if (GameManager.instance.currency.EnoughCurrency(TowerCost(spawnID)))
                {
                    GameManager.instance.currency.Use(TowerCost(spawnID));
                    SpawnTower(cellPosCentered);
                    spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                }
                else
                {
                    Debug.Log("Not Enough Currency");
                }
            }
        }
    }

    public int TowerCost(int id)
    {
        switch (id)
        {
            case 0: return towersPrefabs[id].GetComponent<IncomeTower>().cost;
            case 1: return towersPrefabs[id].GetComponent<DefenceTower>().cost;
            case 2: return towersPrefabs[id].GetComponent<LazerTower>().cost;
            case 3: return towersPrefabs[id].GetComponent<AttackTower>().cost;
            default: return -1;
        }
    }

    void SpawnTower(Vector3 position)
    {
        GameObject tower = Instantiate(towersPrefabs[spawnID]);
        tower.transform.position = position;

        DeselectTower();
    }

    public void SelectTower(int id)
    {
        DeselectTower();
        spawnID = id;
        towersUI[spawnID].color = Color.white;
    }

    public void DeselectTower()
    {
        spawnID = -1;
        foreach (var t in towersUI)
        {
            t.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }
}