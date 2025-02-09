using ProjectUtility.Core;
using UnityEngine;

namespace ProjectUtility
{
    public class AIAgent : MonoBehaviour
    {
        private AgentBrain _brain;

        public void Setup(IDecision[] decisions, IContext context)
        {
            _brain = new AgentBrain(decisions, context);
        }

        private void Update()
        {
            _brain?.Think();
        }
    }
}