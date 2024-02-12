using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    //list of towers (prefabs) that will instatiate
    public List<GameObject> towersPrefabs;
    //Transform of the spawning towers (Root object)
    public GameObject spawnTowerRoot;
    //list of towers (UI)
    public List<Image> towersUI;
    //id of tower to spawn
    int spawnID = -1;
    //SpawnPoints Tilemap
    public Tilemap spawnTilemap;

    void Update()
    {
        if (spawnID != -1)
        {
            DetectSpawnPoint();
        }
    }

    void DetectSpawnPoint()
    {
        //Detect when mouse is clicked (first touch clicked)
        if (Input.GetMouseButtonDown(0))
        {
            //get the world space position of the map
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //get the position of the cell in the tilemap
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
            //get the center position of the cell
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);
            //check if we can spawn in that cell (collider)
            if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                //Check if currency is enough to spawn
                if (GameManager.instance.currency.EnoughCurrency(TowerCost(spawnID)))
                {
                    //Use the amount of cost from the currency available
                    GameManager.instance.currency.Use(TowerCost(spawnID));
                    //Spawn the tower
                    SpawnTower(cellPosCentered);
                    //Disable the collider
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
        //Set the spawnID
        spawnID = id;
        //Highlight the tower
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