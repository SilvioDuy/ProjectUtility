using UnityEngine;

namespace ProjectUtility.Data
{
    [CreateAssetMenu(fileName = "ConsiderationData", menuName = "UtilityAI/ConsiderationData")]
    public class ConsiderationData : ScriptableObject
    {
        [SerializeField] private string _inputDataName;
        [SerializeField] private AnimationCurve _curve;

        public string InputDataName => _inputDataName;
        public AnimationCurve Curve => _curve;
    }
}