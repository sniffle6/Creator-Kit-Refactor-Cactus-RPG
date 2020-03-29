using UnityEngine;

// Destroy owning GameObject if any collider with a specific tag is trespassing
namespace Navmesh.Examples.Scripts
{
    public class DestroyOnTrigger : MonoBehaviour
    {
        public string m_Tag = "Player";

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == m_Tag)
                Destroy(gameObject);
        }
    }
}
