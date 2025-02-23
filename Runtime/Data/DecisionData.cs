using ProjectUtility.Core;
using ProjectUtility.Utils;
using UnityEngine;

namespace ProjectUtility.Data
{
    [CreateAssetMenu(fileName = "DecisionData", menuName = "UtilityAI/DecisionData")]
    public class DecisionData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private ConsiderationData[] _considerations;
        [TypeFilter(typeof(IAction))] [SerializeField] private SerializableType _action;

        public string Name => _name;
        public ConsiderationData[] Considerations => _considerations;
        public SerializableType Action => _action;
    }
}