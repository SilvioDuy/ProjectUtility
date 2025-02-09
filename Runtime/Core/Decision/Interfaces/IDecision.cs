namespace ProjectUtility.Core
{
    public interface IDecision
    {
        string Name { get; }
        IConsideration[] Considerations { get; }
        IAction[] Actions { get; }

        float Evaluate(IContext context);
        void Make(IContext context);
    }
}
