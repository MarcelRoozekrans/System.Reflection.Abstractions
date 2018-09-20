using System.Configuration.Assemblies;

namespace System.Reflection.Abstractions
{
    public interface IAssemblyFactory
    {
        /// <summary>Creates the name of a type qualified by the display name of its assembly.</summary>
        /// <param name="assemblyName">The display name of an assembly.</param>
        /// <param name="typeName">The full name of a type.</param>
        /// <returns>The full name of the type qualified by the display name of the assembly.</returns>
        string CreateQualifiedName(string assemblyName, string typeName);

        /// <summary>Gets the currently loaded assembly in which the specified type is defined.</summary>
        /// <param name="type">An object representing a type in the assembly that will be returned.</param>
        /// <returns>The assembly in which the specified type is defined.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="type">type</paramref> is null.</exception>
        IAssembly GetAssembly(Type type);

        /// <summary>
        ///     Returns the <see cref="T:System.Reflection.Assembly"></see> of the method that invoked the currently executing
        ///     method.
        /// </summary>
        /// <returns>The Assembly object of the method that invoked the currently executing method.</returns>
        IAssembly GetCallingAssembly();


        /// <summary>
        ///     Gets the process executable in the default application domain. In other application domains, this is the first
        ///     executable that was executed by <see cref="M:System.AppDomain.ExecuteAssembly(System.String)"></see>.
        /// </summary>
        /// <returns>
        ///     The assembly that is the process executable in the default application domain, or the first executable that
        ///     was executed by <see cref="M:System.AppDomain.ExecuteAssembly(System.String)"></see>. Can return null when called
        ///     from unmanaged code.
        /// </returns>
        IAssembly GetEntryAssembly();

        /// <summary>Gets the assembly that contains the code that is currently executing.</summary>
        /// <returns>The assembly that contains the code that is currently executing.</returns>
        IAssembly GetExecutingAssembly();

        /// <summary>
        ///     Loads the assembly with a common object file format (COFF)-based image containing an emitted assembly. The
        ///     assembly is loaded into the application domain of the caller.
        /// </summary>
        /// <param name="rawAssembly">A byte array that is a COFF-based image containing an emitted assembly.</param>
        /// <returns>The loaded assembly.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="rawAssembly">rawAssembly</paramref> is null.</exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="rawAssembly">rawAssembly</paramref> is not a valid
        ///     assembly.   -or-   Version 2.0 or later of the common language runtime is currently loaded and
        ///     <paramref name="rawAssembly">rawAssembly</paramref> was compiled with a later version.
        /// </exception>
        IAssembly Load(byte[] rawAssembly);

        /// <summary>
        ///     Loads the assembly with a common object file format (COFF)-based image containing an emitted assembly,
        ///     optionally including symbols for the assembly. The assembly is loaded into the application domain of the caller.
        /// </summary>
        /// <param name="rawAssembly">A byte array that is a COFF-based image containing an emitted assembly.</param>
        /// <param name="rawSymbolStore">A byte array that contains the raw bytes representing the symbols for the assembly.</param>
        /// <returns>The loaded assembly.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="rawAssembly">rawAssembly</paramref> is null.</exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="rawAssembly">rawAssembly</paramref> is not a valid
        ///     assembly.   -or-   Version 2.0 or later of the common language runtime is currently loaded and
        ///     <paramref name="rawAssembly">rawAssembly</paramref> was compiled with a later version.
        /// </exception>
        IAssembly Load(byte[] rawAssembly, byte[] rawSymbolStore);

        /// <summary>Loads an assembly given its <see cref="T:System.Reflection.Abstractions.AssemblyName"></see>.</summary>
        /// <param name="assemblyRef">The object that describes the assembly to be loaded.</param>
        /// <returns>The loaded assembly.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="assemblyRef">assemblyRef</paramref> is null.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException"><paramref name="assemblyRef">assemblyRef</paramref> is not found.</exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     In the [.NET for Windows Store apps](http://go.microsoft.com/fwlink/?LinkID=247912) or the [Portable Class
        ///     Library](~/docs/standard/cross-platform/cross-platform-development-with-the-portable-class-library.md), catch the
        ///     base class exception, <see cref="T:System.IO.IOException"></see>, instead.
        ///     A file that was found could not be loaded.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="assemblyRef">assemblyRef</paramref> is not a valid
        ///     assembly. -or-   Version 2.0 or later of the common language runtime is currently loaded and
        ///     <paramref name="assemblyRef">assemblyRef</paramref> was compiled with a later version.
        /// </exception>
        IAssembly Load(AssemblyName assemblyRef);

        /// <summary>Loads an assembly given the long form of its name.</summary>
        /// <param name="assemblyString">The long form of the assembly name.</param>
        /// <returns>The loaded assembly.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="assemblyString">assemblyString</paramref> is null.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="assemblyString">assemblyString</paramref> is a zero-length
        ///     string.
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="assemblyString">assemblyString</paramref> is not
        ///     found.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="assemblyString">assemblyString</paramref> is not a
        ///     valid assembly.   -or-   Version 2.0 or later of the common language runtime is currently loaded and
        ///     <paramref name="assemblyString">assemblyString</paramref> was compiled with a later version.
        /// </exception>
        IAssembly Load(string assemblyString);

        /// <summary>Loads the contents of an assembly file on the specified path.</summary>
        /// <param name="path">The fully qualified path of the file to load.</param>
        /// <returns>The loaded assembly.</returns>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="path">path</paramref> argument is not an absolute
        ///     path.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="path">path</paramref> parameter is null.</exception>
        /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     The <paramref name="path">path</paramref> parameter is an empty
        ///     string ("") or does not exist.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="path">path</paramref> is not a valid assembly.
        ///     -or-   Version 2.0 or later of the common language runtime is currently loaded and
        ///     <paramref name="path">path</paramref> was compiled with a later version.
        /// </exception>
        IAssembly LoadFile(string path);

        /// <summary>Loads an assembly given its file name or path.</summary>
        /// <param name="assemblyFile">The name or path of the file that contains the manifest of the assembly.</param>
        /// <returns>The loaded assembly.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="assemblyFile">assemblyFile</paramref> is null.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="assemblyFile">assemblyFile</paramref> is not found,
        ///     or the module you are trying to load does not specify a filename extension.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="assemblyFile">assemblyFile</paramref> is not a valid
        ///     assembly; for example, a 32-bit assembly in a 64-bit process. See the exception topic for more information.   -or-
        ///     Version 2.0 or later of the common language runtime is currently loaded and
        ///     <paramref name="assemblyFile">assemblyFile</paramref> was compiled with a later version.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">
        ///     A codebase that does not start with "file://" was specified
        ///     without the required <see cref="T:System.Net.WebPermission"></see>.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="assemblyFile">assemblyFile</paramref> parameter is an
        ///     empty string ("").
        /// </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The assembly name is longer than MAX_PATH characters.</exception>
        IAssembly LoadFrom(string assemblyFile);

        /// <summary>Loads an assembly given its file name or path, hash value, and hash algorithm.</summary>
        /// <param name="assemblyFile">The name or path of the file that contains the manifest of the assembly.</param>
        /// <param name="hashValue">The value of the computed hash code.</param>
        /// <param name="hashAlgorithm">The hash algorithm used for hashing files and for generating the strong name.</param>
        /// <returns>The loaded assembly.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="assemblyFile">assemblyFile</paramref> is null.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="assemblyFile">assemblyFile</paramref> is not found,
        ///     or the module you are trying to load does not specify a file name extension.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="assemblyFile">assemblyFile</paramref> is not a valid
        ///     assembly; for example, a 32-bit assembly in a 64-bit process. See the exception topic for more information.   -or-
        ///     <paramref name="assemblyFile">assemblyFile</paramref> was compiled with a later version of the common language
        ///     runtime than the version that is currently loaded.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">
        ///     A codebase that does not start with "file://" was specified
        ///     without the required <see cref="T:System.Net.WebPermission"></see>.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="assemblyFile">assemblyFile</paramref> parameter is an
        ///     empty string ("").
        /// </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The assembly name is longer than MAX_PATH characters.</exception>
        IAssembly LoadFrom(string assemblyFile, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm);

        /// <summary>Loads an assembly from the application directory or from the global assembly cache using a partial name.</summary>
        /// <param name="partialName">The display name of the assembly.</param>
        /// <returns>
        ///     The loaded assembly. If <paramref name="partialName">partialName</paramref> is not found, this method returns
        ///     null.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     The <paramref name="partialName">partialName</paramref> parameter is
        ///     null.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="assemblyFile">assemblyFile</paramref> is not a valid
        ///     assembly.   -or-   Version 2.0 or later of the common language runtime is currently loaded and
        ///     <paramref name="partialName">partialName</paramref> was compiled with a later version.
        /// </exception>
        [Obsolete(
            "This method has been deprecated. Please use Assembly.Load() instead. http://go.microsoft.com/fwlink/?linkid=14202")]
        IAssembly LoadWithPartialName(string partialName);

        /// <summary>
        ///     Loads the assembly from a common object file format (COFF)-based image containing an emitted assembly. The
        ///     assembly is loaded into the reflection-only context of the caller's application domain.
        /// </summary>
        /// <param name="rawAssembly">A byte array that is a COFF-based image containing an emitted assembly.</param>
        /// <returns>The loaded assembly.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="rawAssembly">rawAssembly</paramref> is null.</exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="rawAssembly">rawAssembly</paramref> is not a valid
        ///     assembly.   -or-   Version 2.0 or later of the common language runtime is currently loaded and
        ///     <paramref name="rawAssembly">rawAssembly</paramref> was compiled with a later version.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException"><paramref name="rawAssembly">rawAssembly</paramref> cannot be loaded.</exception>
        IAssembly ReflectionOnlyLoad(byte[] rawAssembly);

        /// <summary>Loads an assembly into the reflection-only context, given its display name.</summary>
        /// <param name="assemblyString">
        ///     The display name of the assembly, as returned by the
        ///     <see cref="P:System.Reflection.Abstractions.AssemblyName.FullName"></see> property.
        /// </param>
        /// <returns>The loaded assembly.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="assemblyString">assemblyString</paramref> is null.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="assemblyString">assemblyString</paramref> is an empty
        ///     string ("").
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="assemblyString">assemblyString</paramref> is not
        ///     found.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     <paramref name="assemblyString">assemblyString</paramref> is found, but
        ///     cannot be loaded.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="assemblyString">assemblyString</paramref> is not a
        ///     valid assembly.   -or-   Version 2.0 or later of the common language runtime is currently loaded and
        ///     <paramref name="assemblyString">assemblyString</paramref> was compiled with a later version.
        /// </exception>
        IAssembly ReflectionOnlyLoad(string assemblyString);

        /// <summary>Loads an assembly into the reflection-only context, given its path.</summary>
        /// <param name="assemblyFile">The path of the file that contains the manifest of the assembly.</param>
        /// <returns>The loaded assembly.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="assemblyFile">assemblyFile</paramref> is null.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="assemblyFile">assemblyFile</paramref> is not found,
        ///     or the module you are trying to load does not specify a file name extension.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     <paramref name="assemblyFile">assemblyFile</paramref> is found, but
        ///     could not be loaded.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="assemblyFile">assemblyFile</paramref> is not a valid
        ///     assembly.   -or-   Version 2.0 or later of the common language runtime is currently loaded and
        ///     <paramref name="assemblyFile">assemblyFile</paramref> was compiled with a later version.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">
        ///     A codebase that does not start with "file://" was specified
        ///     without the required <see cref="T:System.Net.WebPermission"></see>.
        /// </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The assembly name is longer than MAX_PATH characters.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="assemblyFile">assemblyFile</paramref> is an empty string
        ///     ("").
        /// </exception>
        IAssembly ReflectionOnlyLoadFrom(string assemblyFile);

        /// <summary>Loads an assembly into the load-from context, bypassing some security checks.</summary>
        /// <param name="assemblyFile">The name or path of the file that contains the manifest of the assembly.</param>
        /// <returns>The loaded assembly.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="assemblyFile">assemblyFile</paramref> is null.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="assemblyFile">assemblyFile</paramref> is not found,
        ///     or the module you are trying to load does not specify a filename extension.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="assemblyFile">assemblyFile</paramref> is not a valid
        ///     assembly.   -or-  <paramref name="assemblyFile">assemblyFile</paramref> was compiled with a later version of the
        ///     common language runtime than the version that is currently loaded.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">
        ///     A codebase that does not start with "file://" was specified
        ///     without the required <see cref="T:System.Net.WebPermission"></see>.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="assemblyFile">assemblyFile</paramref> parameter is an
        ///     empty string ("").
        /// </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The assembly name is longer than MAX_PATH characters.</exception>
        IAssembly UnsafeLoadFrom(string assemblyFile);
    }
}