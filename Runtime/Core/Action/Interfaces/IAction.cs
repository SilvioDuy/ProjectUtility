using System;

namespace ProjectUtility.Core
{
    public interface IAction
    {
        string Name { get; }
        float Cooldown { get; }
        bool InCooldown { get; }

        Action OnEnd { get; set; }

        void Execute(IContext context);
        void Tick(IContext context);
    }
}