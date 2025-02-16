using UnityEngine;

namespace ProjectUtility.Core
{
    public interface IConsideration
    {
        string Name { get; }
        float Weight { get; }

        float Consider(IContext context);
    }
}