namespace System.Reflection.Abstractions
{
    public class Reflection : IReflection
    {
        public IAssemblyFactory Assembly => new AssemblyFactory();
        public IAssemblyNameFactory AssemblyName => new AssemblyNameFactory();
    }
}