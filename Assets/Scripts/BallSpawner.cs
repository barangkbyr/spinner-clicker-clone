using System;
using UnityEngine;

namespace Assets.Scripts {
    public class BallSpawner : MonoBehaviour {
        public GameObject ball;

        public Transform spawnLocation;

        private int _maxNumberOfBalls = 3;
        public static int _activeNumberOfBalls = 0;

        void Update() { }

        private void FixedUpdate() {
            if (_activeNumberOfBalls <= _maxNumberOfBalls) {
                Invoke(nameof(SpawnBalls), 2f);
                _activeNumberOfBalls++;
            }
        }

        private void SpawnBalls() {
            Instantiate(ball, spawnLocation.position, Quaternion.identity);
        }
    }
}