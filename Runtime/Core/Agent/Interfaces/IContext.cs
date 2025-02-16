using System;

namespace ProjectUtility.Core
{
    public interface IContext 
    {
        bool TryGetData(string dataType, out float data);
        float GetData(string dataType);
    }
}