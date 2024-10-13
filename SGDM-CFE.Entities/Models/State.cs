namespace SGDM_CFE.Entities.Models
{
    public class State
    {
        public int IdState { get; set; }
        public bool HasFailures { get; set; }
        public bool FailuresDescription { get; set; }
        public bool IsFunctional { get; set; }
        public string? ReviewNotes { get; set; }

        public State() { }

        public State(int idState, bool hasFailures, bool failuresDescription, bool isFunctional, string? reviewNotes)
        {
            IdState = idState;
            HasFailures = hasFailures;
            FailuresDescription = failuresDescription;
            IsFunctional = isFunctional;
            ReviewNotes = reviewNotes;
        }
    }
}