using UnityEngine;

namespace Assets.Scripts {
    [CreateAssetMenu(fileName = "NewScoop", menuName = "Scoop")]
    public class BaseScoop : ScriptableObject {
        public int scoopLevel;
        public float rotationSpeed; 
    }
}
