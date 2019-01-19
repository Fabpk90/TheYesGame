using UnityEngine;

namespace Objects
{
    public abstract class BringableObject : MonoBehaviour
    {
        public abstract void Use(Actor actor);
    }
}