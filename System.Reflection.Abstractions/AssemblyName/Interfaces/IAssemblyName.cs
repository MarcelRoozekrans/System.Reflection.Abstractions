using System.Configuration.Assemblies;
using System.Globalization;
using System.Runtime.Serialization;

namespace System.Reflection.Abstractions
{
    public interface IAssemblyName
    {
        /// <summary>Gets or sets the location of the assembly as a URL.</summary>
        /// <returns>A string that is the URL location of the assembly.</returns>
        string CodeBase { get; set; }

#if NETSTANDARD2_0
        /// <summary>Gets or sets a value that indicates what type of content the assembly contains.</summary>
        /// <returns>A value that indicates what type of content the assembly contains.</returns>
        AssemblyContentType ContentType { get; set; }

        /// <summary>Gets or sets the name of the culture associated with the assembly.</summary>
        /// <returns>The culture name.</returns>
        string CultureName { get; set; }
#endif
        /// <summary>Gets or sets the culture supported by the assembly.</summary>
        /// <returns>An object that represents the culture supported by the assembly.</returns>
        CultureInfo CultureInfo { get; set; }



        /// <summary>Gets the URI, including escape characters, that represents the codebase.</summary>
        /// <returns>A URI with escape characters.</returns>
        string EscapedCodeBase { get; }

        /// <summary>Gets or sets the attributes of the assembly.</summary>
        /// <returns>A value that represents the attributes of the assembly.</returns>
        AssemblyNameFlags Flags { get; set; }

        /// <summary>Gets the full name of the assembly, also known as the display name.</summary>
        /// <returns>A string that is the full name of the assembly, also known as the display name.</returns>
        string FullName { get; }

        /// <summary>Gets or sets the hash algorithm used by the assembly manifest.</summary>
        /// <returns>The hash algorithm used by the assembly manifest.</returns>
        AssemblyHashAlgorithm HashAlgorithm { get; set; }

        /// <summary>Gets or sets the and private cryptographic key pair that is used to create a strong name signature for the assembly.</summary>
        /// <returns>The and private cryptographic key pair to be used to create a strong name for the assembly.</returns>
        StrongNameKeyPair KeyPair { get; set; }

        /// <summary>Gets or sets the simple name of the assembly. This is usually, but not necessarily, the file name of the manifest file of the assembly, minus its extension.</summary>
        /// <returns>The simple name of the assembly.</returns>
        string Name { get; set; }

        /// <summary>Gets or sets a value that identifies the processor and bits-per-word of the platform targeted by an executable.</summary>
        /// <returns>One of the enumeration values that identifies the processor and bits-per-word of the platform targeted by an executable.</returns>
        ProcessorArchitecture ProcessorArchitecture { get; set; }

        /// <summary>Gets or sets the major, minor, build, and revision numbers of the assembly.</summary>
        /// <returns>An object that represents the major, minor, build, and revision numbers of the assembly.</returns>
        Version Version { get; set; }

        /// <summary>Gets or sets the information related to the assembly's compatibility with other assemblies.</summary>
        /// <returns>A value that represents information about the assembly's compatibility with other assemblies.</returns>
        AssemblyVersionCompatibility VersionCompatibility { get; set; }

        /// <summary>Makes a copy of this <see cref="T:System.Reflection.Abstractions.AssemblyName"></see> object.</summary>
        /// <returns>An object that is a copy of this <see cref="T:System.Reflection.Abstractions.AssemblyName"></see> object.</returns>
        object Clone();

        /// <summary>Gets serialization information with all the data needed to recreate an instance of this AssemblyName.</summary>
        /// <param name="info">The object to be populated with serialization information.</param>
        /// <param name="context">The destination context of the serialization.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="info">info</paramref> is null.</exception>
        void GetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>Gets the key of the assembly.</summary>
        /// <returns>A byte array that contains the key of the assembly.</returns>
        /// <exception cref="T:System.Security.SecurityException">A key was provided (for example, by using the <see cref="M:System.Reflection.Abstractions.AssemblyName.SetPublicKey(System.Byte[])"></see> method), but no key token was provided.</exception>
        byte[] GetPublicKey();

        /// <summary>Gets the key token, which is the last 8 bytes of the SHA-1 hash of the key under which the application or assembly is signed.</summary>
        /// <returns>A byte array that contains the key token.</returns>
        byte[] GetPublicKeyToken();

        /// <summary>Implements the <see cref="T:System.Runtime.Serialization.ISerializable"></see> interface and is called back by the deserialization event when deserialization is complete.</summary>
        /// <param name="sender">The source of the deserialization event.</param>
        void OnDeserialization(object sender);


        /// <summary>Sets the key identifying the assembly.</summary>
        /// <param name="publicKey">A byte array containing the key of the assembly.</param>
        void SetPublicKey(byte[] publicKey);

        /// <summary>Sets the key token, which is the last 8 bytes of the SHA-1 hash of the key under which the application or assembly is signed.</summary>
        /// <param name="publicKeyToken">A byte array containing the key token of the assembly.</param>
        void SetPublicKeyToken(byte[] publicKeyToken);
    }
}