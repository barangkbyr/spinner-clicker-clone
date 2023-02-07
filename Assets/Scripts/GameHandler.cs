using UnityEngine;

namespace Assets.Scripts {
    public class GameHandler : MonoBehaviour {
        public GameObject scoop;
        public Transform pivotPoint;

        private void Start() {
            pivotPoint = GameObject.FindGameObjectWithTag("Pivot").transform;
        }

        private void SpawnAtCenter(GameObject objectToSpawn) {
            Instantiate(objectToSpawn, new Vector3(0, 0, -10), pivotPoint.rotation);
        }

        public void SpawnButton() {
            SpawnAtCenter(scoop);
        }
    }
}