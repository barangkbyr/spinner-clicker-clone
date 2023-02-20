using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    public class GameHandler : MonoBehaviour {
        [SerializeField]
        private TextMeshProUGUI _totalCurrencyText;

        [SerializeField]
        private TextMeshProUGUI _currencyMultiplierText;

        [SerializeField]
        private TextMeshProUGUI _earningsPerSecondText;

        private float totalEarnedSinceStart;

        public static int totalCurrency;
        public static int currencyMultiplier = 1;

        private void Awake() {
            Ball.OnBallDestroy += OnBallDestroy;
            Upgrades.OnUpgradeBought += OnUpgradeBought;
            RefreshUi();
        }

        private void OnUpgradeBought() {
            RefreshUi();
        }

        private void Start() {
            _totalCurrencyText.text = totalCurrency.ToString();
        }

        private void Update() {
            CalculateEarningsPerSecond();
        }

        private void CalculateEarningsPerSecond() {
            var timeFromStart = Time.timeSinceLevelLoad;
            var earningsPerSecond = totalEarnedSinceStart / timeFromStart;
            _earningsPerSecondText.text = earningsPerSecond.ToString("N1") + " per/sec";
        }

        private void OnBallDestroy() {
            AddPoint(10);
            RefreshUi();
        }

        private void RefreshUi() {
            _totalCurrencyText.text = totalCurrency.ToString();
            _currencyMultiplierText.text = currencyMultiplier + "x";
        }

        private void AddPoint(int point) {
            totalCurrency += point * currencyMultiplier;
            totalEarnedSinceStart += point * currencyMultiplier;
        }

        public void CheatAdd() {
            AddPoint(1000);
            RefreshUi();
        }
    }
}