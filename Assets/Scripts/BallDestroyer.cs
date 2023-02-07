using UnityEngine;

namespace Assets.Scripts {
    public class BallDestroyer : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Ball")) {
                Destroy(other.gameObject);
            }
        }
    }
}
