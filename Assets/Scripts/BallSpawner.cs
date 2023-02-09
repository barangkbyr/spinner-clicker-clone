using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    public class BallSpawner : MonoBehaviour {
        public GameObject ball;

        public Transform spawnLocation;

        public TextMeshProUGUI numberOfBallsText;

        public static int maxNumberOfBalls = 4;
        public static int activeNumberOfBalls;

        private void Awake() {
            numberOfBallsText.text = maxNumberOfBalls.ToString();
            Upgrades.OnUpgradeBought += OnUpgradeBought;
        }

        private void OnUpgradeBought() {
            numberOfBallsText.text = maxNumberOfBalls.ToString();
        }

        private void FixedUpdate() {
            if (activeNumberOfBalls < maxNumberOfBalls) {
                Invoke(nameof(SpawnBalls), 2f);
                activeNumberOfBalls++;
            }
        }

        private void SpawnBalls() {
            Instantiate(ball, spawnLocation.position, Quaternion.identity);
        }
    }
}