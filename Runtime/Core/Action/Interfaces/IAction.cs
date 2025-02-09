namespace ProjectUtility.Core
{
    public interface IAction
    {
        string Name { get; }
        float Cooldown { get; }
        bool InCooldown { get; }

        void Execute(IContext context);
    }
}