using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class Upgrades : MonoBehaviour {
        public static Action OnUpgradeBought;

        private int _ballUpgradeCost = 200;
        private int _scoopAddCost = 250;
        private int _currencyMultiplierCost = 2000;

        public TextMeshProUGUI ballUpgradeCostText;
        public TextMeshProUGUI scoopAddCostText;
        public TextMeshProUGUI currencyMultiplierCostText;

        public GameObject scoop;

        void Start() {
            RefreshUi();
        }

        public void UpgradeBallNumber() {
            var currency = GameHandler.totalCurrency;
            
            if (currency >= _ballUpgradeCost) {
                GameHandler.totalCurrency = currency - _ballUpgradeCost;
                BallSpawner._maxNumberOfBalls++;
                OnUpgradeBought?.Invoke();
                _ballUpgradeCost *= 2;
                RefreshUi();
            }
        }

        public void AddNewScoop() {
            var currency = GameHandler.totalCurrency;

            if (currency >= _scoopAddCost) {
                GameHandler.totalCurrency = currency - _scoopAddCost;
                GameHandler.SpawnNewScoop(scoop);
                _scoopAddCost *= 2;
                RefreshUi();
            }
        }

        public void UpgradePointMultiplier() {
            var currency = GameHandler.totalCurrency;

            if (currency >= _currencyMultiplierCost) {
                GameHandler.totalCurrency = currency - _currencyMultiplierCost;
                GameHandler.currencyMultiplier++;
                OnUpgradeBought?.Invoke();
                _currencyMultiplierCost *= 2;
                RefreshUi();
            }
        }

        private void RefreshUi() {
            ballUpgradeCostText.text = _ballUpgradeCost.ToString();
            scoopAddCostText.text = _scoopAddCost.ToString();
            currencyMultiplierCostText.text = _currencyMultiplierCost.ToString();
        }
    }
}