using UnityEngine;

namespace Assets.Scripts {
    public class BallDeadZone : MonoBehaviour {
        private void OnCollisionEnter2D(Collision2D other) {
            Destroy(other.gameObject);
        }
    }
}