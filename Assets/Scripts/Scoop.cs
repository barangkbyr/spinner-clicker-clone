using UnityEngine;

namespace Assets.Scripts {
    public class Scoop : MonoBehaviour {
        [SerializeField]
        private Transform _pivotPoint;

        [SerializeField]
        private BaseScoop _baseScoop;

        public float _rotationSpeed;

        public int _scoopLevel;

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
    }
}