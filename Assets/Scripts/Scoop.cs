using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class Scoop : MonoBehaviour {
        [SerializeField]
        private Transform _pivotPoint;

        [SerializeField]
        private BaseScoop _baseScoop;

        [SerializeField]
        private float _rotationSpeed;

        public int _scoopLevel;

        [SerializeField]
        private Button _rotationBuffButton;

        private float _rotationBuffDuration = 10f;

        private void Start() {
            Init();
        }

        private void Update() {
            gameObject.transform.RotateAround(_pivotPoint.position, -Vector3.forward, _rotationSpeed * Time.deltaTime);
        }

        private void Init() {
            _rotationSpeed = _baseScoop.rotationSpeed * _baseScoop.scoopLevel;
            _scoopLevel = _baseScoop.scoopLevel;
            _pivotPoint = GameObject.FindGameObjectWithTag("Pivot").transform;
        }

        public void LevelUp() {
            _scoopLevel++;
            _rotationSpeed = _baseScoop.rotationSpeed * _scoopLevel;
        }

        public void TempRotationBuff() {
            Timer.isButtonPressed = true;
            var activeScoops = GameObject.FindGameObjectsWithTag("Scoop");
            _rotationBuffButton.interactable = false;

            foreach (var activeScoop in activeScoops) {
                activeScoop.GetComponent<Scoop>()._rotationSpeed += 50;
            }

            Invoke(nameof(ReturnBackToDefaultRotateSpeed), _rotationBuffDuration);
        }

        private void ReturnBackToDefaultRotateSpeed() {
            var activeScoops = GameObject.FindGameObjectsWithTag("Scoop");

            foreach (var activeScoop in activeScoops) {
                activeScoop.GetComponent<Scoop>()._rotationSpeed = _baseScoop.rotationSpeed;
            }

            _rotationBuffButton.interactable = true;
            Timer.isButtonPressed = false;
        }
    }
}