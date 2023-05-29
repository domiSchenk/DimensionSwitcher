using UnityEngine;

namespace Shinjingi
{
    public class CollisionDataRetriever : MonoBehaviour
    {
        [SerializeField] public bool OnGround { get; set; }
        [SerializeField] public bool OnWall { get; set; }
        [SerializeField] public float Friction { get; set; }
        public Vector2 ContactNormal { get; set; }

        private PhysicsMaterial2D _material;

        private void OnCollisionExit2D(Collision2D collision)
        {
            OnGround = false;
            Friction = 0;
            OnWall = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            EvaluateCollision(collision);
            RetrieveFriction(collision);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            EvaluateCollision(collision);
            RetrieveFriction(collision);
        }

        public void EvaluateCollision(Collision2D collision)
        {
            for (int i = 0; i < collision.contactCount; i++)
            {
                ContactNormal = collision.GetContact(i).normal;
                OnGround |= ContactNormal.y >= 0.9f;
                if (!collision.gameObject.CompareTag("PhysicalWall"))
                {
                    OnWall = Mathf.Abs(ContactNormal.x) >= 0.9f;
                }
            }
        }

        private void RetrieveFriction(Collision2D collision)
        {
            _material = collision.rigidbody?.sharedMaterial;

            Friction = 0;

            if (_material != null)
            {
                Friction = _material.friction;
            }
        }
    }
}
