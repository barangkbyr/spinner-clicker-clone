using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class Scoop : MonoBehaviour {
        public Transform pivotPoint;
        public BaseScoop baseScoop;
        public float rotationSpeed;

        public Button rotationBuffButton;

        public GameObject timerText;
        public GameObject timer;

        private float _rotationBuffDuration = 10f;

        private void Start() {
            pivotPoint = GameObject.FindGameObjectWithTag("Pivot").transform;
            rotationSpeed = baseScoop.rotationSpeed;
        }

        private void Update() {
            gameObject.transform.RotateAround(pivotPoint.position, -Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        public void TempRotationBuff() {
            var activeScoops = GameObject.FindGameObjectsWithTag("Scoop");
            rotationBuffButton.interactable = false;
            timerText.SetActive(true);
            timer.SetActive(true);

            foreach (var activeScoop in activeScoops) {
                activeScoop.GetComponent<Scoop>().rotationSpeed += 50;
            }

            Invoke(nameof(ReturnBackToDefaultRotateSpeed), _rotationBuffDuration);
        }

        private void ReturnBackToDefaultRotateSpeed() {
            var activeScoops = GameObject.FindGameObjectsWithTag("Scoop");

            foreach (var activeScoop in activeScoops) {
                activeScoop.GetComponent<Scoop>().rotationSpeed = baseScoop.rotationSpeed;
            }

            timerText.SetActive(false);
            timer.SetActive(false);
            rotationBuffButton.interactable = true;
        }
    }
}