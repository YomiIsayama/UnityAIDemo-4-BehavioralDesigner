using UnityEngine;

namespace BehaviorDesigner.Runtime
{
    [System.Serializable]
    public class SharedTransform : SharedVariable<Transform>
    {
        internal Transform position;

        public static implicit operator SharedTransform(Transform value) { return new SharedTransform { mValue = value }; }
    }
}