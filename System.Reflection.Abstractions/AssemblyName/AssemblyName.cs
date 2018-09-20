using System.Configuration.Assemblies;
using System.Globalization;
using System.Runtime.Serialization;

namespace System.Reflection.Abstractions
{
    public class AssemblyName : IAssemblyName
    {
        internal readonly System.Reflection.AssemblyName _inner;

        public AssemblyName(System.Reflection.AssemblyName inner)
        {
            _inner = inner;
        }

        /// <summary>Returns the full name of the assembly, also known as the display name.</summary>
        /// <returns>The full name of the assembly, or the class name if the full name cannot be determined.</returns>
        public override string ToString()
        {
            return _inner.ToString();
        }

        /// <inheritdoc />
        public string CodeBase
        {
            get => _inner.CodeBase;
            set => _inner.CodeBase = value;
        }
#if NETSTANDARD2_0
        /// <inheritdoc />
        public AssemblyContentType ContentType
        {
            get => _inner.ContentType;
            set => _inner.ContentType = value;
        }
        /// <inheritdoc />
        public string CultureName
        {
            get => _inner.CultureName;
            set => _inner.CultureName = value;
        }
#endif
        /// <inheritdoc />
        public CultureInfo CultureInfo
        {
            get => _inner.CultureInfo;
            set => _inner.CultureInfo = value;
        }



        /// <inheritdoc />
        public string EscapedCodeBase => _inner.EscapedCodeBase;

        /// <inheritdoc />
        public AssemblyNameFlags Flags
        {
            get => _inner.Flags;
            set => _inner.Flags = value;
        }

        /// <inheritdoc />
        public string FullName => _inner.FullName;

        /// <inheritdoc />
        public AssemblyHashAlgorithm HashAlgorithm
        {
            get => _inner.HashAlgorithm;
            set => _inner.HashAlgorithm = value;
        }

        /// <inheritdoc />
        public StrongNameKeyPair KeyPair
        {
            get => _inner.KeyPair;
            set => _inner.KeyPair = value;
        }

        /// <inheritdoc />
        public string Name
        {
            get => _inner.Name;
            set => _inner.Name = value;
        }

        /// <inheritdoc />
        public ProcessorArchitecture ProcessorArchitecture
        {
            get => _inner.ProcessorArchitecture;
            set => _inner.ProcessorArchitecture = value;
        }

        /// <inheritdoc />
        public Version Version
        {
            get => _inner.Version;
            set => _inner.Version = value;
        }

        /// <inheritdoc />
        public AssemblyVersionCompatibility VersionCompatibility
        {
            get => _inner.VersionCompatibility;
            set => _inner.VersionCompatibility = value;
        }

        /// <inheritdoc />
        public object Clone()
        {
            return _inner.Clone();
        }

        /// <inheritdoc />
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _inner.GetObjectData(info, context);
        }

        /// <inheritdoc />
        public byte[] GetPublicKey()
        {
            return _inner.GetPublicKey();
        }

        /// <inheritdoc />
        public byte[] GetPublicKeyToken()
        {
            return _inner.GetPublicKeyToken();
        }

        /// <inheritdoc />
        public void OnDeserialization(object sender)
        {
            _inner.OnDeserialization(sender);
        }

        /// <inheritdoc />
        public void SetPublicKey(byte[] publicKey)
        {
            _inner.SetPublicKey(publicKey);
        }

        /// <inheritdoc />
        public void SetPublicKeyToken(byte[] publicKeyToken)
        {
            _inner.SetPublicKeyToken(publicKeyToken);
        }

        /// <summary>Returns a value indicating whether two assembly names are the same. The comparison is based on the simple assembly names.</summary>
        /// <param name="reference">The reference assembly name.</param>
        /// <param name="definition">The assembly name that is compared to the reference assembly.</param>
        /// <returns>true if the simple assembly names are the same; otherwise, false.</returns>
        public static bool ReferenceMatchesDefinition(IAssemblyName reference, IAssemblyName definition)
        {
            return System.Reflection.AssemblyName.ReferenceMatchesDefinition((reference as AssemblyName)?._inner, (definition as AssemblyName)?._inner);
        }


        /// <summary>Gets the <see cref="T:System.Reflection.Abstractions.AssemblyName"></see> for a given file.</summary>
        /// <param name="assemblyFile">The path for the assembly whose <see cref="T:System.Reflection.Abstractions.AssemblyName"></see> is to be returned.</param>
        /// <returns>An object that represents the given assembly file.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="assemblyFile">assemblyFile</paramref> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="assemblyFile">assemblyFile</paramref> is invalid, such as an assembly with an invalid culture.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException"><paramref name="assemblyFile">assemblyFile</paramref> is not found.</exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have path discovery permission.</exception>
        /// <exception cref="T:System.BadImageFormatException"><paramref name="assemblyFile">assemblyFile</paramref> is not a valid assembly.</exception>
        /// <exception cref="T:System.IO.FileLoadException">An assembly or module was loaded twice with two different sets of evidence.</exception>
        public static IAssemblyName GetAssemblyName(string assemblyFile)
        {
            return new AssemblyName(System.Reflection.AssemblyName.GetAssemblyName(assemblyFile));
        }
    }
}