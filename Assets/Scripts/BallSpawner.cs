using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    public class BallSpawner : MonoBehaviour {
        [SerializeField]
        private GameObject ball;

        [SerializeField]
        private Transform spawnLocation;

        [SerializeField]
        private TextMeshProUGUI numberOfBallsText;

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
                Invoke(nameof(SpawnBalls), 0.2f);
                activeNumberOfBalls++;
            }
        }

        private void SpawnBalls() {
            Instantiate(ball, spawnLocation.position, Quaternion.identity);
        }
    }
}