using System;
using UnityEngine;

namespace RPG.Core
{
    public class PeristentObjectSpawner : MonoBehaviour
    {
        [SerializeField] GameObject persistentObjectPrefab;

        static bool hasSpawned = false;
        public bool spawned;
        private void Awake() {
            if (hasSpawned) return;

            SpawnPersistentObjects();


        }

        private void SpawnPersistentObjects()
        {
            GameObject persistentObject = Instantiate(persistentObjectPrefab);
            DontDestroyOnLoad(persistentObject);
            hasSpawned = true;
            spawned = hasSpawned;
        }
    }
}