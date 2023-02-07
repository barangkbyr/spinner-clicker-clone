using System;
using UnityEngine;

namespace Assets.Scripts {
    public class Ball : MonoBehaviour {
        [SerializeField]
        private GameObject objectToAttach;

        [SerializeField]
        private float followSpeed = 2f;

        private bool _isTouchingScoop;

        private void Start() {
            
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("ScoopTop")) {
                objectToAttach = other.gameObject;
                _isTouchingScoop = true;
            }
        }

        private void Update() {
            if (_isTouchingScoop) {
                transform.position = Vector2.MoveTowards(transform.position, objectToAttach.transform.position, followSpeed * Time.deltaTime);
            }
        }

        private void OnDestroy() {
            _isTouchingScoop = false;
            BallSpawner._activeNumberOfBalls--;
        }
    }
}