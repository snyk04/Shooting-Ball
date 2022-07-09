using UnityEngine;

namespace ShootingBall.Common
{
    public abstract class Component<T> : MonoBehaviour
    {
        public T Object
        { 
            get 
            {
                if (_object == null)
                {
                    _object = CreateObject();
                }

                return _object;
            } 
        }
        private T _object;

        private void Awake()
        {
            _object = CreateObject();
        }

        protected abstract T CreateObject();
    }
}