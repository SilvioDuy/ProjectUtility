namespace ProjectUtility.Core
{
    public interface IAction
    {
        string Name { get; }
        bool Cooldown { get; set; }
        bool InCooldown { get; }

        void Execute(IContext context);
    }
}