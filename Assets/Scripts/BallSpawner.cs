using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    public class BallSpawner : MonoBehaviour {
        public GameObject ball;

        public Transform spawnLocation;

        public TextMeshProUGUI numberOfBallsText;

        public static int _maxNumberOfBalls = 4;
        public static int _activeNumberOfBalls;

        private void Awake() {
            numberOfBallsText.text = _maxNumberOfBalls.ToString();
            Upgrades.OnUpgradeBought += OnUpgradeBought;
        }

        private void OnUpgradeBought() {
            numberOfBallsText.text = _maxNumberOfBalls.ToString();
        }

        private void FixedUpdate() {
            if (_activeNumberOfBalls < _maxNumberOfBalls) {
                Invoke(nameof(SpawnBalls), 2f);
                _activeNumberOfBalls++;
            }
        }

        private void SpawnBalls() {
            Instantiate(ball, spawnLocation.position, Quaternion.identity);
        }
    }
}