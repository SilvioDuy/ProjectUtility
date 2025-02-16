using ProjectUtility.Core;
using ProjectUtility.Data;
using UnityEngine;

namespace ProjectUtility
{
    public class AIAgent : MonoBehaviour
    {
        [SerializeField] private BrainData _brainData;

        private AgentBrain _brain;

        //TODO: External setup

        public void Setup(IContext context)
        {
            if (!_brainData)
                return;

            DecisionBase[] decisions = new DecisionBase[_brainData.Decisions.Length];

            for (int i = 0; i < decisions.Length; i++)
            {
                decisions[i] = new DecisionBase(_brainData.Decisions[i]);
            }

            _brain = new AgentBrain(decisions, context);
        }

        private void Update()
        {
            _brain?.Think();
        }
    }
}