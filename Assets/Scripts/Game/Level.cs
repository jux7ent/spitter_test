using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] private GameObject[] _carSpawners;
    [SerializeField] private GameObject[] _usualCarPrefabs;
    [SerializeField] private GameObject[] _rareCarPrefabs;

    [SerializeField] private float _spawnProbaForRareCar = 0.1f;

    public float spawnDelaySec = 3f;
    
    public void SpawnCar() { // это бы вынести в отдельный спавнер
        int spawnerId = Random.Range(0, _carSpawners.Length);
        GameObject selectedSpawner = _carSpawners[spawnerId];

        float spawnProba = Random.Range(0f, 1f);
        if (spawnerId == 0) { // временный костыль
            spawnProba = 1f;
        }
        GameObject[] carsList = spawnProba < _spawnProbaForRareCar ? _rareCarPrefabs : _usualCarPrefabs;
        
        int carIndex = Random.Range(0, carsList.Length);
        
        string objPoolTag = GetObjectsPoolTag(spawnProba < _spawnProbaForRareCar, carIndex);

        GameObject carObj = GameManager.instance.objectsPool.Get(objPoolTag);
        if (carObj == null) {
            carObj = Instantiate(carsList[carIndex]);
            carObj.GetComponent<CarController>().SetTagForObjectsPool(objPoolTag);
        }

        carObj.transform.position = selectedSpawner.transform.position;
    }

    private string GetObjectsPoolTag(bool isRarelyCar, int carIndex) {
        return (isRarelyCar ? 0 : 1).ToString() + carIndex;
    }
}
