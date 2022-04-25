using System.Collections.Generic;
using UnityEngine;

public class LaserPool : MonoBehaviour {

    private static LaserPool instance;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> laserList;

    public static LaserPool Instance {
        get { return instance; }
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        AddLasersToPool(poolSize);
    }

    private void AddLasersToPool(int amount) {
        for (int i = 0; i < amount; i++) {
            GameObject laser = Instantiate(laserPrefab);
            laser.SetActive(false);
            laserList.Add(laser);
            laser.transform.parent = transform;
        }
    }

    public GameObject RequestLaser() {
        for (int i = 0; i < laserList.Count; i++) {
            if (!laserList[i].activeSelf) {
                laserList[i].SetActive(true);
                return laserList[i];
            }
        }
        AddLasersToPool(1);
        laserList[^1].SetActive(true);
        return laserList[^1];
    }

}
