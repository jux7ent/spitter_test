using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] private GameObject[] _carSpawners;
    [SerializeField] private GameObject[] _usualCarPrefabs;
    [SerializeField] private GameObject[] _rareCarPrefabs;

    [SerializeField] private float _spawnProbaForRareCar = 0.1f;
    
    public void SpawnCar() {
        GameObject selectedSpawner =
            _carSpawners[Random.Range(0, _carSpawners.Length)];

        float spawnProba = Random.Range(0f, 1f);
        GameObject[] carsList = spawnProba < _spawnProbaForRareCar ? _rareCarPrefabs : _usualCarPrefabs;
        
        int carIndex = Random.Range(0, carsList.Length);
        
        string objPoolTag = GetObjectsPoolTag(spawnProba < _spawnProbaForRareCar, carIndex);

        GameObject carObj = GameManager.instance.objectsPool.Get(objPoolTag);
        if (carObj == null) {
            carObj = Instantiate(carsList[carIndex], selectedSpawner.transform.position, Quaternion.identity);
            carObj.GetComponent<CarController>().SetTagForObjectsPool(objPoolTag);
        } else {
            carObj.transform.position = selectedSpawner.transform.position;
        }
    }

    private string GetObjectsPoolTag(bool isRarelyCar, int carIndex) {
        return (isRarelyCar ? 0 : 1).ToString() + carIndex;
    }
}
