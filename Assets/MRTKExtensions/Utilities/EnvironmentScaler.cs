using Microsoft.MixedReality.Toolkit;
using UnityEngine;

namespace MRTKExtensions.Utilities
{
    public class EnvironmentScaler : EnvironmentHelperBase<float>
    {
        [SerializeField]
        private float _hl1Scale = 1.0f;

        [SerializeField]
        private float _hl2Scale = 0.7f;

        [SerializeField]
        private float _immersiveWmrScale = 1.8f;

        void Start()
        {
            gameObject.transform.localScale *= GetPlatformValue(_hl1Scale, _hl2Scale, _immersiveWmrScale);
        }
    }
}