using ProjectUtility.Data;
using UnityEngine;

namespace ProjectUtility.Core
{
    public class ConsiderationBase : IConsideration
    {
        private string _name;
        private float _weight;
        private string _inputDataName;
        private AnimationCurve _curve;

        public string Name => _name;
        public float Weight => _weight;

        public ConsiderationBase(ConsiderationData data)
        {
            _name = data.name;
            _weight = 1;
            _inputDataName = data.InputDataName;
            _curve = data.Curve;
        }

        public float Consider(IContext context)
        {
            if (!context.TryGetData(_inputDataName, out var inputData))
                return 0f;

            return _curve.Evaluate(Mathf.Clamp01(inputData / 100f));
        }
    }
}