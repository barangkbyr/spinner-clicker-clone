using System;
using UnityEngine;

namespace Assets.Scripts {
    public class Ball : MonoBehaviour {
        public static Action OnBallDestroy;

        [SerializeField]
        private GameObject objectToAttach;

        [SerializeField]
        private float followSpeed = 2f;

        public bool _isTouchingScoop;

        private bool _isBallAttached;

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("ScoopTop") && !_isBallAttached) {
                _isBallAttached = true;
                objectToAttach = other.gameObject;
                _isTouchingScoop = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other) {
            if (other.gameObject.CompareTag("ScoopTop")) {
                Destroy(gameObject);
            }
        }

        private void Update() {
            if (_isTouchingScoop) {
                transform.position = Vector2.MoveTowards(transform.position, objectToAttach.transform.position, followSpeed * Time.deltaTime);
            }
        }

        private void OnDestroy() {
            _isTouchingScoop = false;
            OnBallDestroy?.Invoke();
            BallSpawner.activeNumberOfBalls--;
        }
    }
}