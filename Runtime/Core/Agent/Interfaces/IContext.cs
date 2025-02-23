using System;

namespace ProjectUtility.Core
{
    public interface IContext 
    {
        bool TryGetResource(string dataType, out float data);
        float GetResource(string dataType);
    }
}