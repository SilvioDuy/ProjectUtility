using System;

namespace ProjectUtility.Core
{
    public interface IDecision
    {
        string Name { get; }
        IConsideration[] Considerations { get; }
        IAction Action { get; }
        Action OnActionExecuted { get; set; }

        float Evaluate(IContext context);
        void Make(IContext context);
        void Tick(IContext context);
    }
}
