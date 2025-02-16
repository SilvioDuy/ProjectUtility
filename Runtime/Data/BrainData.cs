using UnityEngine;

namespace ProjectUtility.Data
{
    [CreateAssetMenu(fileName = "BrainData", menuName = "UtilityAI/BrainData")]
    public class BrainData : ScriptableObject
    {
        [SerializeField] private DecisionData[] _decisions;

        public DecisionData[] Decisions => _decisions;
    }
}