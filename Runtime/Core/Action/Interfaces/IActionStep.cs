namespace ProjectUtility.Core
{
    /// <summary>
    /// Represents a single step that can be made in order to complete an action execution
    /// </summary>
    public interface IActionStep
    {
        void Start(IContext context, System.Action nextStepCallback);
        void Tick(IContext context, System.Action nextStepCallback);
        void End(IContext context);
    }
}