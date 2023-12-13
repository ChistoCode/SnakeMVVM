using UnityEngine;

namespace Markers
{
    public class BodyMarker : MonoBehaviour
    {
        [SerializeField] private Collider _collider;

        public void SetEnabled(bool enabled)
        {
            _collider.enabled = enabled;
        }
    }
}