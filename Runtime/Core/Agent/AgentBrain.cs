namespace ProjectUtility.Core
{
    public class AgentBrain
    {
        private IDecision[] _decisions;
        private IContext _context;

        private IDecision _bestDecision;

        public AgentBrain(IDecision[] decisions, IContext context)
        {
            _decisions = decisions;
            _context = context;
        }

        public void Think()
        {
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
        }
    }
}