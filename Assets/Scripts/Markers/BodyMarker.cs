using UnityEngine;

namespace Markers
{
    [DefaultPrefab("SnakeElement")]
    public class BodyMarker : MonoBehaviour
    {
        [SerializeField] private Collider _collider;

        public void SetEnabled(bool enabled)
        {
            _collider.enabled = enabled;
        }
    }
}