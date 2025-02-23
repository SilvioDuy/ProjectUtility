using ProjectUtility.Data;
using System;
using System.Diagnostics;

namespace ProjectUtility.Core
{
    public class DecisionBase : IDecision
    {
        private string _name;
        private float _score;
        private IConsideration[] _considerations;
        private IAction _action;

        public string Name => _name;
        
        public IConsideration[] Considerations => _considerations;

        public IAction Action => _action;

        public Action OnActionExecuted { get; set; }

        public DecisionBase(string name, IConsideration[] considerations, IAction action)
        {
            _name = name;
            _considerations = considerations;
            _action = action;
        }

        public DecisionBase(DecisionData data)
        {
            _name = data.Name;
            _considerations = new IConsideration[data.Considerations.Length];
            for (int i = 0; i < _considerations.Length; i++)
            {
                _considerations[i] = new ConsiderationBase(data.Considerations[i]);
            }
            
            _action = (IAction)Activator.CreateInstance(data.Action);
        }

        public float Evaluate(IContext context)
        {
            float score = 1f;
            float modFactor = 1 - (1 / Considerations.Length);

            for (int i = 0; i < Considerations.Length; i++)
            {
                float considerationScore = Considerations[i].Consider(context);
                float makeupValue = (1 - considerationScore) * modFactor;
                float finalScore = considerationScore + (makeupValue * considerationScore);

                score *= finalScore;

                if (score == 0f)
                {
                    _score = 0;
                    return score;
                }
            }

            return _score = score;
        }

        public void Make(IContext context)
        {
            if (_action == null)
                return;

            //if (_action.InCooldown)
            //    return;

            _action.Execute(context);
            _action.OnEnd += OnActionEnd;
        }

        public void Tick(IContext context)
        {
            //if (_action.InCooldown)
            //    return;

            _action?.Tick(context);
        }

        private void OnActionEnd()
        {
            _action.OnEnd -= OnActionEnd;
            OnActionExecuted?.Invoke();
        }
    }
}