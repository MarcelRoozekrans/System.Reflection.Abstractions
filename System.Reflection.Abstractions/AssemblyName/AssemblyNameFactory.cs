namespace System.Reflection.Abstractions
{
    public class AssemblyNameFactory : IAssemblyNameFactory
    {
        public IAssemblyName AssemblyName()
        {
            return new AssemblyName(new System.Reflection.AssemblyName());
        }

        public IAssemblyName AssemblyName(string assemblyName)
        {
            return new AssemblyName(new System.Reflection.AssemblyName(assemblyName));
        }

        public bool ReferenceMatchesDefinition(IAssemblyName reference, IAssemblyName definition)
        {
            return Abstractions.AssemblyName.ReferenceMatchesDefinition(reference, definition);
        }

        public IAssemblyName GetAssemblyName(string assemblyFile)
        {
            return Abstractions.AssemblyName.GetAssemblyName(assemblyFile);
        }
    }
}