using Microsoft.MixedReality.Toolkit;
using UnityEngine;

namespace MRTKExtensions.Utilities
{
    public abstract class EnvironmentHelperBase<T> : MonoBehaviour
    {
        [SerializeField]
        private EditorEnvironmentType _editorEnvironmentType = EditorEnvironmentType.Hololens2;

        protected T GetPlatformValue(T hl1Value, T hl2Value, T wmrHeadsetValue)
        {
#if !UNITY_EDITOR
            if (CoreServices.CameraSystem.IsOpaque)
            {
                return wmrHeadsetValue;
            }

            var capabilityChecker = CoreServices.InputSystem as IMixedRealityCapabilityCheck;

            return capabilityChecker.CheckCapability(MixedRealityCapability.ArticulatedHand) ? hl2Value : hl1Value;
#else
            return GetTestPlatformValue(hl1Value, hl2Value, wmrHeadsetValue);
#endif
        }

        private T GetTestPlatformValue(T hl1Value, T hl2Value, T wmrHeadsetValue)
        {
            switch (_editorEnvironmentType)
            {
                case EditorEnvironmentType.Hololens2: return hl2Value;
                case EditorEnvironmentType.Hololens1: return hl1Value;
                default: return wmrHeadsetValue;
            }
        }
    }
}