namespace ProjectUtility.Core
{
    public interface IDecision
    {
        string Name { get; }
        float Score { get; }
        IConsideration[] Considerations { get; }
        IAction[] Actions { get; }

        float Evaluate(IContext context);
        void Take(IContext context);
    }
}
