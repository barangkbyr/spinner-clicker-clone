using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    public class GameHandler : MonoBehaviour {
        public GameObject scoop;
        public Transform pivotPoint;
        public TextMeshProUGUI totalCurrencyText;

        public int totalCurrency = 0;

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

        private void SpawnNewScoop(GameObject objectToSpawn) {
            Instantiate(objectToSpawn, new Vector3(0, 0, -10), pivotPoint.rotation);
        }

        private void RefreshUi() {
            totalCurrencyText.text = totalCurrency.ToString();
        }

        public void SpawnButton() {
            SpawnNewScoop(scoop);
        }

        private void AddPoint() {
            totalCurrency += 10;
        }
    }
}