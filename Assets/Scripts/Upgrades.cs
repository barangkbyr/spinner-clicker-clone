using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts {
    public class Upgrades : MonoBehaviour {
        public static Action OnUpgradeBought;

        private int _ballUpgradeCost = 250;
        private int _scoopAddCost = 300;
        private int _currencyMultiplierCost = 2500;
        private int _mergeCost = 200;

        [SerializeField]
        private TextMeshProUGUI ballUpgradeCostText;

        [SerializeField]
        private TextMeshProUGUI scoopAddCostText;

        [SerializeField]
        private TextMeshProUGUI currencyMultiplierCostText;

        [SerializeField]
        private TextMeshProUGUI mergeCostText;

        [SerializeField]
        private GameObject scoopObject;

        [SerializeField]
        private List<Scoop> scoopList;

        [SerializeField]
        private BaseScoop _baseScoop;

        private bool recentlyTouched;

        [SerializeField]
        private float _buffTimer;

        void Start() {
            scoopList = GameObject.FindObjectsOfType<Scoop>().ToList();
            RefreshUi();
        }

        private void Update() {
            CheckForTimer();
        }

        private void SpawnScoop(GameObject objectToSpawn) {
            Instantiate(objectToSpawn, new Vector3(0, 0, -10), Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
            scoopList = GameObject.FindObjectsOfType<Scoop>().ToList();
        }

        public void MergeScoops() {
            var currency = GameHandler.totalCurrency;

            if (currency >= _mergeCost) {
                GameHandler.totalCurrency = currency - _mergeCost;
                OnUpgradeBought?.Invoke();

                var scoopByLevel = scoopList.GroupBy(item => item._scoopLevel);

                foreach (var scoops in scoopByLevel) {
                    if (scoops.Count() < 2) {
                        continue;
                    } else {
                        scoops.First().LevelUp();
                        var scoopToDelete = scoops.ToList()[1];
                        scoopList.Remove(scoopToDelete);
                        GameObject.Destroy(scoopToDelete.gameObject);
                    }
                }

                _mergeCost *= 2;
                RefreshUi();
            }
        }

        public void UpgradeBallNumber() {
            var currency = GameHandler.totalCurrency;

            if (currency >= _ballUpgradeCost) {
                GameHandler.totalCurrency = currency - _ballUpgradeCost;
                BallSpawner.maxNumberOfBalls++;
                OnUpgradeBought?.Invoke();
                _ballUpgradeCost *= 2;
                RefreshUi();
            }
        }

        public void AddNewScoop() {
            var currency = GameHandler.totalCurrency;

            if (currency >= _scoopAddCost) {
                GameHandler.totalCurrency = currency - _scoopAddCost;
                SpawnScoop(scoopObject);
                OnUpgradeBought?.Invoke();
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

        private void CheckForTimer() {
            if (recentlyTouched) {
                _buffTimer += Time.deltaTime;
                if (_buffTimer >= 5) {
                    _buffTimer = 0;
                    recentlyTouched = false;

                    foreach (var scoop in scoopList) {
                        var rotSpeed = _baseScoop.rotationSpeed * scoop._scoopLevel;
                        scoop._rotationSpeed = rotSpeed;
                    }
                }
            }
        }

        public void TouchBuff() {
            recentlyTouched = true;

            foreach (var scoops in scoopList) {
                scoops._rotationSpeed += 20;
            }
        }

        private void RefreshUi() {
            ballUpgradeCostText.text = _ballUpgradeCost.ToString();
            scoopAddCostText.text = _scoopAddCost.ToString();
            currencyMultiplierCostText.text = _currencyMultiplierCost.ToString();
            mergeCostText.text = _mergeCost.ToString();
        }
    }
}