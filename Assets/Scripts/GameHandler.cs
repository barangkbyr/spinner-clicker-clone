using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    public class GameHandler : MonoBehaviour {
        private static Transform pivotPoint;

        public TextMeshProUGUI totalCurrencyText;
        
        public static int totalCurrency;
        public static int currencyMultiplier = 1;

        private void Awake() {
            Ball.OnBallDestroy += OnBallDestroy;
        }

        private void Start() {
            pivotPoint = GameObject.FindGameObjectWithTag("Pivot").transform;
            totalCurrencyText.text = totalCurrency.ToString();
        }

        private void OnBallDestroy() {
            AddPoint();
            RefreshUi();
        }

        public static void SpawnNewScoop(GameObject objectToSpawn) {
            Instantiate(objectToSpawn, new Vector3(0, 0, -10), pivotPoint.rotation);
        }

        private void RefreshUi() {
            totalCurrencyText.text = totalCurrency.ToString();
        }

        private void AddPoint() {
            totalCurrency += 10 * currencyMultiplier;
        }
    }
}