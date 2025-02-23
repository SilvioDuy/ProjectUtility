using System;
using UnityEngine;

namespace ProjectUtility.Core
{
    public class ActionSFSM : IDisposable
    {
        private IActionStep[] _steps;
        private int _currentStepIndex;
        private IContext _context;

        public bool IsPaused { get; set; }
        public Action OnCompleted { get; set; }

        public ActionSFSM(IActionStep[] steps, IContext context)
        {
            _steps = steps;
            _context = context;
            _currentStepIndex = -1;
        }

        public void Start()
        {
            if (_context == null)
            {
                Debug.LogWarning("Context is null");
                return;
            }

            if (_steps == null || _steps.Length == 0)
            {
                Debug.LogWarning("There are no states in the Action SFSM");
                return;
            }

            _currentStepIndex = 0;
            _steps[_currentStepIndex].Start(_context, NextStep);
        }

        public void Stop()
        {
            _currentStepIndex = -1;
        }

        public void Tick()
        {
            if (IsPaused)
                return;

            if (_currentStepIndex < 0 || _context == null)
                return;

            _steps[_currentStepIndex].Tick(_context, NextStep);
        }

        public void NextStep()
        {
            _steps[_currentStepIndex].End(_context);
            _currentStepIndex++;

            if (_currentStepIndex >= _steps.Length)
            {
                Stop();
                OnCompleted?.Invoke();
                return;
            }

            _steps[_currentStepIndex].Start(_context, NextStep);
        }

        public void Dispose()
        {
            OnCompleted = null;
            _steps = null;
        }
    }
}