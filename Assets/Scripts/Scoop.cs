using UnityEngine;

namespace Assets.Scripts {
    public class Scoop : MonoBehaviour {
        public Transform pivotPoint;
        public BaseScoop baseScoop;
        public float _rotationSpeed;

        [SerializeField]
        private float _rotationBuffDuration = 10f;

        private void Start() {
            pivotPoint = GameObject.FindGameObjectWithTag("Pivot").transform;
            _rotationSpeed = baseScoop.rotationSpeed;
        }

        private void Update() {
            gameObject.transform.RotateAround(pivotPoint.position, -Vector3.forward, _rotationSpeed * Time.deltaTime);
        }

        public void TestButton() {
            var activeScoops = GameObject.FindGameObjectsWithTag("Scoop");

            foreach (var activeScoop in activeScoops) {
                activeScoop.GetComponent<Scoop>()._rotationSpeed += 50;
            }

            Invoke(nameof(ReturnBackToDefaultRotateSpeed), _rotationBuffDuration);
        }

        private void ReturnBackToDefaultRotateSpeed() {
            var activeScoops = GameObject.FindGameObjectsWithTag("Scoop");

            foreach (var activeScoop in activeScoops) {
                activeScoop.GetComponent<Scoop>()._rotationSpeed = baseScoop.rotationSpeed;
            }
        }
    }
}