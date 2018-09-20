using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;

namespace System.Reflection.Abstractions
{
    public class Assembly : IAssembly
    {
        private readonly System.Reflection.Assembly _inner;

        public Assembly(System.Reflection.Assembly inner)
        {
            _inner = inner;
            _inner.ModuleResolve += OnModuleResolve;
        }
        
        /// <inheritdoc />
        public string CodeBase => _inner.CodeBase;
#if NETSTANDARD2_0
        /// <inheritdoc />
        public IEnumerable<CustomAttributeData> CustomAttributes => _inner.CustomAttributes;
        /// <inheritdoc />
        public IEnumerable<Type> ExportedTypes => _inner.ExportedTypes;
        /// <inheritdoc />
        public IEnumerable<TypeInfo> DefinedTypes => _inner.DefinedTypes;
        /// <inheritdoc />
        public IEnumerable<Module> Modules => _inner.Modules;
#endif
        /// <inheritdoc />
        public MethodInfo EntryPoint => _inner.EntryPoint;

        /// <inheritdoc />
        public string EscapedCodeBase => _inner.EscapedCodeBase;

        /// <inheritdoc />
        public string FullName => _inner.FullName;

        /// <inheritdoc />
        public bool GlobalAssemblyCache => _inner.GlobalAssemblyCache;

        /// <inheritdoc />
        public long HostContext => _inner.HostContext;

        /// <inheritdoc />
        public string ImageRuntimeVersion => _inner.ImageRuntimeVersion;

        /// <inheritdoc />
        public bool IsDynamic => _inner.IsDynamic;

        /// <inheritdoc />
        public bool IsFullyTrusted => _inner.IsFullyTrusted;

        /// <inheritdoc />
        public string Location => _inner.Location;

        /// <inheritdoc />
        public Module ManifestModule => _inner.ManifestModule;

        /// <inheritdoc />
        public bool ReflectionOnly => _inner.ReflectionOnly;

        /// <inheritdoc />
        public SecurityRuleSet SecurityRuleSet => _inner.SecurityRuleSet;

        /// <inheritdoc />
        public event ModuleResolveEventHandler ModuleResolve;

        private Module OnModuleResolve(object sender, ResolveEventArgs e)
        {
            return ModuleResolve?.Invoke(sender, e);
        }

        /// <inheritdoc />
        public object CreateInstance(string typeName)
        {
            return _inner.CreateInstance(typeName);
        }

        /// <inheritdoc />
        public object CreateInstance(string typeName, bool ignoreCase)
        {
            return _inner.CreateInstance(typeName, ignoreCase);
        }

        /// <inheritdoc />
        public object CreateInstance(string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder,
            object[] args,
            CultureInfo culture, object[] activationAttributes)
        {
            return _inner.CreateInstance(typeName, ignoreCase, bindingAttr, binder, args, culture,
                activationAttributes);
        }

        /// <inheritdoc />
        public object[] GetCustomAttributes(bool inherit)
        {
            return _inner.GetCustomAttributes(inherit);
        }

        /// <inheritdoc />
        public object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            return _inner.GetCustomAttributes(attributeType, inherit);
        }

        /// <inheritdoc />
        public IList<CustomAttributeData> GetCustomAttributesData()
        {
            return _inner.GetCustomAttributesData();
        }

        /// <inheritdoc />
        public Type[] GetExportedTypes()
        {
            return _inner.GetExportedTypes();
        }

        /// <inheritdoc />
        public FileStream GetFile(string name)
        {
            return _inner.GetFile(name);
        }

        /// <inheritdoc />
        public FileStream[] GetFiles()
        {
            return _inner.GetFiles();
        }

        /// <inheritdoc />
        public FileStream[] GetFiles(bool getResourceModules)
        {
            return _inner.GetFiles(getResourceModules);
        }

        /// <inheritdoc />
        public Module[] GetLoadedModules()
        {
            return _inner.GetLoadedModules();
        }

        /// <inheritdoc />
        public Module[] GetLoadedModules(bool getResourceModules)
        {
            return _inner.GetLoadedModules(getResourceModules);
        }

        /// <inheritdoc />
        public ManifestResourceInfo GetManifestResourceInfo(string resourceName)
        {
            return _inner.GetManifestResourceInfo(resourceName);
        }

        /// <inheritdoc />
        public string[] GetManifestResourceNames()
        {
            return _inner.GetManifestResourceNames();
        }

        /// <inheritdoc />
        public Stream GetManifestResourceStream(string name)
        {
            return _inner.GetManifestResourceStream(name);
        }

        /// <inheritdoc />
        public Stream GetManifestResourceStream(Type type, string name)
        {
            return _inner.GetManifestResourceStream(type, name);
        }

        /// <inheritdoc />
        public Module GetModule(string name)
        {
            return _inner.GetModule(name);
        }

        /// <inheritdoc />
        public Module[] GetModules()
        {
            return _inner.GetModules();
        }

        /// <inheritdoc />
        public Module[] GetModules(bool getResourceModules)
        {
            return _inner.GetModules(getResourceModules);
        }

        /// <inheritdoc />
        public IAssemblyName GetName()
        {
            return new AssemblyName(_inner.GetName());
        }

        /// <inheritdoc />
        public IAssemblyName GetName(bool copiedName)
        {
            return new AssemblyName(_inner.GetName(copiedName));
        }

        /// <inheritdoc />
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _inner.GetObjectData(info, context);
        }

        /// <inheritdoc />
        public IAssemblyName[] GetReferencedAssemblies()
        {
            return _inner.GetReferencedAssemblies().Select(x => new AssemblyName(x)).ToArray<IAssemblyName>();
        }

        /// <inheritdoc />
        public IAssembly GetSatelliteAssembly(CultureInfo culture)
        {
            return new Assembly(_inner.GetSatelliteAssembly(culture));
        }

        /// <inheritdoc />
        public IAssembly GetSatelliteAssembly(CultureInfo culture, Version version)
        {
            return new Assembly(_inner.GetSatelliteAssembly(culture, version));
        }

        /// <inheritdoc />
        public Type GetType(string name)
        {
            return _inner.GetType();
        }

        /// <inheritdoc />
        public Type GetType(string name, bool throwOnError)
        {
            return _inner.GetType(name, throwOnError);
        }

        /// <inheritdoc />
        public Type GetType(string name, bool throwOnError, bool ignoreCase)
        {
            return _inner.GetType(name, throwOnError, ignoreCase);
        }

        /// <inheritdoc />
        public Type[] GetTypes()
        {
            return _inner.GetTypes();
        }

        /// <inheritdoc />
        public bool IsDefined(Type attributeType, bool inherit)
        {
            return _inner.IsDefined(attributeType, inherit);
        }

        /// <inheritdoc />
        public Module LoadModule(string moduleName, byte[] rawModule)
        {
            return _inner.LoadModule(moduleName, rawModule);
        }

        /// <inheritdoc />
        public Module LoadModule(string moduleName, byte[] rawModule, byte[] rawSymbolStore)
        {
            return _inner.LoadModule(moduleName, rawModule, rawSymbolStore);
        }

        /// <summary>Determines whether this assembly and the specified object are equal.</summary>
        /// <param name="o">The object to compare with this instance.</param>
        /// <returns>true if <paramref name="o">o</paramref> is equal to this instance; otherwise, false.</returns>
        public override bool Equals(object o)
        {
            return _inner.Equals(o);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return _inner.GetHashCode();
        }

        /// <summary>Returns the full name of the assembly, also known as the display name.</summary>
        /// <returns>The full name of the assembly, or the class name if the full name of the assembly cannot be determined.</returns>
        public override string ToString()
        {
            return _inner.ToString();
        }

        /// <summary>Indicates whether two <see cref="T:System.Reflection.Assembly"></see> objects are equal.</summary>
        /// <param name="left">The assembly to compare to right.</param>
        /// <param name="right">The assembly to compare to left.</param>
        /// <returns>
        ///     true if <paramref name="left">left</paramref> is equal to <paramref name="right">right</paramref>; otherwise,
        ///     false.
        /// </returns>
        public static bool operator ==(Assembly left, Assembly right)
        {
            return left?._inner != right?._inner;
        }

        /// <summary>Indicates whether two <see cref="T:System.Reflection.Assembly"></see> objects are not equal.</summary>
        /// <param name="left">The assembly to compare to right.</param>
        /// <param name="right">The assembly to compare to left.</param>
        /// <returns>
        ///     true if <paramref name="left">left</paramref> is not equal to <paramref name="right">right</paramref>;
        ///     otherwise, false.
        /// </returns>
        public static bool operator !=(Assembly left, Assembly right)
        {
            return left?._inner != right?._inner;
        }

        /// <summary>Creates the name of a type qualified by the display name of its assembly.</summary>
        /// <param name="assemblyName">The display name of an assembly.</param>
        /// <param name="typeName">The full name of a type.</param>
        /// <returns>The full name of the type qualified by the display name of the assembly.</returns>
        public static string CreateQualifiedName(string assemblyName, string typeName)
        {
            return System.Reflection.Assembly.CreateQualifiedName(assemblyName, typeName);
        }

        /// <summary>Gets the currently loaded assembly in which the specified type is defined.</summary>
        /// <param name="type">An object representing a type in the assembly that will be returned.</param>
        /// <returns>The assembly in which the specified type is defined.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="type">type</paramref> is null.</exception>
        public static IAssembly GetAssembly(Type type)
        {
            return new Assembly(System.Reflection.Assembly.GetAssembly(type));
        }

        /// <summary>
        ///     Returns the <see cref="T:System.Reflection.Assembly"></see> of the method that invoked the currently executing
        ///     method.
        /// </summary>
        /// <returns>The Assembly object of the method that invoked the currently executing method.</returns>
        public static IAssembly GetCallingAssembly()
        {
            return new Assembly(System.Reflection.Assembly.GetCallingAssembly());
        }

        /// <summary>
        ///     Gets the process executable in the default application domain. In other application domains, this is the first
        ///     executable that was executed by <see cref="M:System.AppDomain.ExecuteAssembly(System.String)"></see>.
        /// </summary>
        /// <returns>
        ///     The assembly that is the process executable in the default application domain, or the first executable that
        ///     was executed by <see cref="M:System.AppDomain.ExecuteAssembly(System.String)"></see>. Can return null when called
        ///     from unmanaged code.
        /// </returns>
        public static IAssembly GetEntryAssembly()
        {
            return new Assembly(System.Reflection.Assembly.GetEntryAssembly());
        }

        /// <summary>Gets the assembly that contains the code that is currently executing.</summary>
        /// <returns>The assembly that contains the code that is currently executing.</returns>
        public static IAssembly GetExecutingAssembly()
        {
            return new Assembly(System.Reflection.Assembly.GetExecutingAssembly());
        }

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
        public static IAssembly Load(byte[] rawAssembly)
        {
            return new Assembly(System.Reflection.Assembly.Load(rawAssembly));
        }

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
        public static IAssembly Load(byte[] rawAssembly, byte[] rawSymbolStore)
        {
            return new Assembly(System.Reflection.Assembly.Load(rawAssembly, rawSymbolStore));
        }

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
        public static IAssembly Load(IAssemblyName assemblyRef)
        {
            if (assemblyRef is AssemblyName castAssemblyName) {
                return new Assembly(System.Reflection.Assembly.Load(castAssemblyName._inner));
            }
            throw new ArgumentNullException(nameof(assemblyRef));
        }

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
        public static IAssembly Load(string assemblyString)
        {
            return new Assembly(System.Reflection.Assembly.Load(assemblyString));
        }

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
        public static IAssembly LoadFile(string path)
        {
            return new Assembly(System.Reflection.Assembly.LoadFile(path));
        }

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
        public static IAssembly LoadFrom(string assemblyFile)
        {
            return new Assembly(System.Reflection.Assembly.LoadFile(assemblyFile));
        }

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
        public static IAssembly LoadFrom(string assemblyFile, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)
        {
            return new Assembly(System.Reflection.Assembly.LoadFrom(assemblyFile, hashValue, hashAlgorithm));
        }

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
        public static IAssembly LoadWithPartialName(string partialName)
        {
            return new Assembly(System.Reflection.Assembly.LoadWithPartialName(partialName));
        }

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
        public static IAssembly ReflectionOnlyLoad(byte[] rawAssembly)
        {
            return new Assembly(System.Reflection.Assembly.ReflectionOnlyLoad(rawAssembly));
        }

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
        public static IAssembly ReflectionOnlyLoad(string assemblyString)
        {
            return new Assembly(System.Reflection.Assembly.ReflectionOnlyLoad(assemblyString));
        }

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
        public static IAssembly ReflectionOnlyLoadFrom(string assemblyFile)
        {
            return new Assembly(System.Reflection.Assembly.ReflectionOnlyLoadFrom(assemblyFile));
        }


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
        public static IAssembly UnsafeLoadFrom(string assemblyFile)
        {
            return new Assembly(System.Reflection.Assembly.UnsafeLoadFrom(assemblyFile));
        }
    }
}