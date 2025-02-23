using System.Diagnostics;

namespace ProjectUtility.Core
{
    public class AgentBrain
    {
        private IDecision[] _decisions;
        private IContext _context;

        private IDecision _bestDecision;
        private bool _shouldDecide;

        public AgentBrain(IDecision[] decisions, IContext context)
        {
            _decisions = decisions;
            _context = context;
            _shouldDecide = true;
        }

        public void Think()
        {
            if (!_shouldDecide)
            {
                _bestDecision?.Tick(_context);
                return;
            }

            float bestScore = float.MinValue;

            for (int i = 0; i < _decisions.Length; i++)
            {
                float decisionScore = _decisions[i].Evaluate(_context);
                if (decisionScore > bestScore)
                {
                    bestScore = decisionScore;
                    _bestDecision = _decisions[i];
                }
            }

            _bestDecision.Make(_context);
            _shouldDecide = false;
            _bestDecision.OnActionExecuted += OnActionsExecuted;
        }

        private void OnActionsExecuted()
        {
            _bestDecision.OnActionExecuted -= OnActionsExecuted;
            _shouldDecide = true;
        }
    }
}