using System.Configuration.Assemblies;

namespace System.Reflection.Abstractions
{
    public class AssemblyFactory : IAssemblyFactory
    {
        /// <inheritdoc />
        public string CreateQualifiedName(string assemblyName, string typeName)
        {
            return Assembly.CreateQualifiedName(assemblyName, typeName);
        }

        /// <inheritdoc />
        public IAssembly GetAssembly(Type type)
        {
            return Assembly.GetAssembly(type);
        }

        /// <inheritdoc />
        public IAssembly GetCallingAssembly()
        {
            return Assembly.GetCallingAssembly();
        }

        /// <inheritdoc />
        public IAssembly GetEntryAssembly()
        {
            return Assembly.GetEntryAssembly();
        }

        /// <inheritdoc />
        public IAssembly GetExecutingAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }

        /// <inheritdoc />
        public IAssembly Load(byte[] rawAssembly)
        {
            return Assembly.Load(rawAssembly);
        }

        /// <inheritdoc />
        public IAssembly Load(byte[] rawAssembly, byte[] rawSymbolStore)
        {
            return Assembly.Load(rawAssembly, rawSymbolStore);
        }

        /// <inheritdoc />
        public IAssembly Load(AssemblyName assemblyRef)
        {
            return Assembly.Load(assemblyRef);
        }

        /// <inheritdoc />
        public IAssembly Load(string assemblyString)
        {
            return Assembly.Load(assemblyString);
        }

        /// <inheritdoc />
        public IAssembly LoadFile(string path)
        {
            return Assembly.LoadFile(path);
        }

        /// <inheritdoc />
        public IAssembly LoadFrom(string assemblyFile)
        {
            return Assembly.LoadFrom(assemblyFile);
        }

        /// <inheritdoc />
        public IAssembly LoadFrom(string assemblyFile, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)
        {
            return Assembly.LoadFrom(assemblyFile, hashValue, hashAlgorithm);
        }

        /// <inheritdoc />
        public IAssembly LoadWithPartialName(string partialName)
        {
            return Assembly.LoadWithPartialName(partialName);
        }

        /// <inheritdoc />
        public IAssembly ReflectionOnlyLoad(byte[] rawAssembly)
        {
            return Assembly.ReflectionOnlyLoad(rawAssembly);
        }

        /// <inheritdoc />
        public IAssembly ReflectionOnlyLoad(string assemblyString)
        {
            return Assembly.ReflectionOnlyLoad(assemblyString);
        }

        /// <inheritdoc />
        public IAssembly ReflectionOnlyLoadFrom(string assemblyFile)
        {
            return Assembly.ReflectionOnlyLoad(assemblyFile);
        }

        /// <inheritdoc />
        public IAssembly UnsafeLoadFrom(string assemblyFile)
        {
            return Assembly.ReflectionOnlyLoad(assemblyFile);
        }
    }
}