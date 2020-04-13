using UnityEngine;

namespace MRTKExtensions.Utilities
{
    public class EnvironmentSwitcher : EnvironmentHelperBase<MonoBehaviour>
    {
        [SerializeField]
        private MonoBehaviour _hl1Behaviour;

        [SerializeField]
        private MonoBehaviour _hl2Behaviour;

        [SerializeField]
        private MonoBehaviour _immersiveWmrBehaviour;

        void Start()
        {
            var selectedBehaviour = GetPlatformValue(_hl1Behaviour, _hl2Behaviour, 
                                                            _immersiveWmrBehaviour);
            foreach (var behaviour in new[] {_hl1Behaviour, _hl2Behaviour, _immersiveWmrBehaviour})
            {
                if (behaviour != selectedBehaviour)
                {
                    Destroy(behaviour);
                }
            }
        }
    }
}

