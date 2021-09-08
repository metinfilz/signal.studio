namespace Signal.Studio.Core.Repositories {
    internal class GeneralState : IGeneralState {
        public string GeneralPath { get; set; }
    }
    public interface IGeneralState {
        string GeneralPath { get; set; }
    }
}
