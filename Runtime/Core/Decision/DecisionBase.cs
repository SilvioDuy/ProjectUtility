using ProjectUtility.Data;
using System;
using UnityEngine;

namespace ProjectUtility.Core
{
    public class DecisionBase : IDecision
    {
        private string _name;
        private float _score;
        private IConsideration[] _considerations;
        private IAction[] _actions;

        public string Name => _name;
        
        public IConsideration[] Considerations => _considerations;

        public IAction[] Actions => _actions;

        public DecisionBase(string name, IConsideration[] considerations, IAction[] actions)
        {
            _name = name;
            _considerations = considerations;
            _actions = actions;
        }

        public DecisionBase(DecisionData data)
        {
            _name = data.Name;
            _considerations = new IConsideration[data.Considerations.Length];
            for (int i = 0; i < _considerations.Length; i++)
            {
                _considerations[i] = new ConsiderationBase(data.Considerations[i]);
            }
            
            _actions = new IAction[data.Actions.Length];
            for (int i = 0; i < _actions.Length; i++)
            {
                _actions[i] = (IAction)Activator.CreateInstance(data.Actions[i]);
            }
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
            foreach (var action in Actions)
            {
                action.Execute(context);
            }
        }
    }
}