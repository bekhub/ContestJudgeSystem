namespace Models.Interfaces
{
    public interface IFileProvider
    {
        public string RootPath { get; }

        public string Checkers { get; }
        
        public string Inputs { get; }
        
        public string Outputs { get; }
        
        public string RealOutputs { get; }

        public string Sources { get; }
    }
}
