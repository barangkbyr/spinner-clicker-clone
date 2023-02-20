using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    public class Timer : MonoBehaviour {
        private float _currentTime;
        private float _startingTimer = 10f;

        public static bool isButtonPressed;

        [SerializeField]
        private TextMeshProUGUI countdownText;

        void Start() {
            _currentTime = _startingTimer;
        }

        void Update() {
            if (isButtonPressed) {
                _currentTime -= 1 * Time.deltaTime;
                countdownText.text = _currentTime.ToString("0");

                if (_currentTime <= 0) {
                    _currentTime = _startingTimer;
                }
            }
        }
    }
}