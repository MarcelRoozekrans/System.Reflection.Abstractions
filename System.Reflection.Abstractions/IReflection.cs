namespace System.Reflection.Abstractions
{
    public interface IReflection
    {
        IAssemblyFactory Assembly { get; }
        IAssemblyNameFactory AssemblyName { get; }
    }
}