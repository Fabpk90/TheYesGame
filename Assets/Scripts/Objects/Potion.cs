using UnityEngine;

namespace Objects
{
    public class Potion : BringableObject
    {
        public int amount;
        public override void Use(Actor actor)
        {
            actor.AddHealth(amount);
        }
    }
}