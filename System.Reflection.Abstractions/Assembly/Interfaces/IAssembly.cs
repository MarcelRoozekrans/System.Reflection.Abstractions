using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Security;

namespace System.Reflection.Abstractions
{
    public interface IAssembly
    {
        /// <summary>
        ///     Gets the location of the assembly as specified originally, for example, in an
        ///     <see cref="T:System.Reflection.Abstractions.AssemblyName"></see> object.
        /// </summary>
        /// <returns>The location of the assembly as specified originally.</returns>
        string CodeBase { get; }

#if NETSTANDARD2_0
/// <summary>Gets a collection that contains this assembly's custom attributes.</summary>
/// <returns>A collection that contains this assembly's custom attributes.</returns>
        IEnumerable<CustomAttributeData> CustomAttributes { get; }

        /// <summary>Gets a collection of the types defined in this assembly.</summary>
        /// <returns>A collection of the types defined in this assembly.</returns>
        IEnumerable<TypeInfo> DefinedTypes { get; }

        /// <summary>Gets a collection of the public types defined in this assembly that are visible outside the assembly.</summary>
        /// <returns>A collection of the public types defined in this assembly that are visible outside the assembly.</returns>
        IEnumerable<Type> ExportedTypes { get; }

        /// <summary>Gets a collection that contains the modules in this assembly.</summary>
        /// <returns>A collection that contains the modules in this assembly.</returns>
        IEnumerable<Module> Modules { get; }
#endif

        /// <summary>Gets the entry point of this assembly.</summary>
        /// <returns>
        ///     An object that represents the entry point of this assembly. If no entry point is found (for example, the
        ///     assembly is a DLL), null is returned.
        /// </returns>
        MethodInfo EntryPoint { get; }

        /// <summary>Gets the URI, including escape characters, that represents the codebase.</summary>
        /// <returns>A URI with escape characters.</returns>
        string EscapedCodeBase { get; }

        /// <summary>Gets the display name of the assembly.</summary>
        /// <returns>The display name of the assembly.</returns>
        string FullName { get; }

        /// <summary>Gets a value indicating whether the assembly was loaded from the global assembly cache.</summary>
        /// <returns>true if the assembly was loaded from the global assembly cache; otherwise, false.</returns>
        bool GlobalAssemblyCache { get; }

        /// <summary>Gets the host context with which the assembly was loaded.</summary>
        /// <returns>
        ///     An <see cref="T:System.Int64"></see> value that indicates the host context with which the assembly was loaded,
        ///     if any.
        /// </returns>
        long HostContext { get; }

        /// <summary>
        ///     Gets a string representing the version of the common language runtime (CLR) saved in the file containing the
        ///     manifest.
        /// </summary>
        /// <returns>The CLR version folder name. This is not a full path.</returns>
        string ImageRuntimeVersion { get; }

        /// <summary>
        ///     Gets a value that indicates whether the current assembly was generated dynamically in the current process by
        ///     using reflection emit.
        /// </summary>
        /// <returns>true if the current assembly was generated dynamically in the current process; otherwise, false.</returns>
        bool IsDynamic { get; }

        /// <summary>Gets a value that indicates whether the current assembly is loaded with full trust.</summary>
        /// <returns>true if the current assembly is loaded with full trust; otherwise, false.</returns>
        bool IsFullyTrusted { get; }

        /// <summary>Gets the full path or UNC location of the loaded file that contains the manifest.</summary>
        /// <returns>
        ///     The location of the loaded file that contains the manifest. If the loaded file was shadow-copied, the location
        ///     is that of the file after being shadow-copied. If the assembly is loaded from a byte array, such as when using the
        ///     <see cref="M:System.Reflection.Assembly.Load(System.Byte[])"></see> method overload, the value returned is an empty
        ///     string ("").
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        ///     The current assembly is a dynamic assembly, represented by an
        ///     <see cref="T:System.Reflection.Emit.AssemblyBuilder"></see> object.
        /// </exception>
        string Location { get; }

        /// <summary>Gets the module that contains the manifest for the current assembly.</summary>
        /// <returns>The module that contains the manifest for the assembly.</returns>
        Module ManifestModule { get; }

        /// <summary>
        ///     Gets a <see cref="T:System.Boolean"></see> value indicating whether this assembly was loaded into the
        ///     reflection-only context.
        /// </summary>
        /// <returns>
        ///     true if the assembly was loaded into the reflection-only context, rather than the execution context;
        ///     otherwise, false.
        /// </returns>
        bool ReflectionOnly { get; }

        /// <summary>
        ///     Gets a value that indicates which set of security rules the common language runtime (CLR) enforces for this
        ///     assembly.
        /// </summary>
        /// <returns>The security rule set that the CLR enforces for this assembly.</returns>
        SecurityRuleSet SecurityRuleSet { get; }

        /// <summary>
        ///     Occurs when the common language runtime class loader cannot resolve a reference to an internal module of an
        ///     assembly through normal means.
        /// </summary>
        /// <returns></returns>
        event ModuleResolveEventHandler ModuleResolve;

        /// <summary>
        ///     Locates the specified type from this assembly and creates an instance of it using the system activator, using
        ///     case-sensitive search.
        /// </summary>
        /// <param name="typeName">The <see cref="P:System.Type.FullName"></see> of the type to locate.</param>
        /// <returns>
        ///     An instance of the specified type created with the default constructor; or null if
        ///     <paramref name="typeName">typeName</paramref> is not found. The type is resolved using the default binder, without
        ///     specifying culture or activation attributes, and with <see cref="T:System.Reflection.BindingFlags"></see> set to
        ///     Public or Instance.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="typeName">typeName</paramref> is an empty string ("") or a
        ///     string beginning with a null character.   -or-   The current assembly was loaded into the reflection-only context.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="typeName">typeName</paramref> is null.</exception>
        /// <exception cref="T:System.MissingMethodException">No matching constructor was found.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="typeName">typeName</paramref> requires a dependent
        ///     assembly that could not be found.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     <paramref name="typeName">typeName</paramref> requires a dependent
        ///     assembly that was found but could not be loaded.   -or-   The current assembly was loaded into the reflection-only
        ///     context, and <paramref name="typeName">typeName</paramref> requires a dependent assembly that was not preloaded.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="typeName">typeName</paramref> requires a dependent
        ///     assembly, but the file is not a valid assembly.   -or-  <paramref name="typeName">typeName</paramref> requires a
        ///     dependent assembly that was compiled for a version of the runtime that is later than the currently loaded version.
        /// </exception>
        object CreateInstance(string typeName);

        /// <summary>
        ///     Locates the specified type from this assembly and creates an instance of it using the system activator, with
        ///     optional case-sensitive search.
        /// </summary>
        /// <param name="typeName">The <see cref="P:System.Type.FullName"></see> of the type to locate.</param>
        /// <param name="ignoreCase">true to ignore the case of the type name; otherwise, false.</param>
        /// <returns>
        ///     An instance of the specified type created with the default constructor; or null if
        ///     <paramref name="typeName">typeName</paramref> is not found. The type is resolved using the default binder, without
        ///     specifying culture or activation attributes, and with <see cref="T:System.Reflection.BindingFlags"></see> set to
        ///     Public or Instance.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="typeName">typeName</paramref> is an empty string ("") or a
        ///     string beginning with a null character.   -or-   The current assembly was loaded into the reflection-only context.
        /// </exception>
        /// <exception cref="T:System.MissingMethodException">No matching constructor was found.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="typeName">typeName</paramref> is null.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="typeName">typeName</paramref> requires a dependent
        ///     assembly that could not be found.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     <paramref name="typeName">typeName</paramref> requires a dependent
        ///     assembly that was found but could not be loaded.   -or-   The current assembly was loaded into the reflection-only
        ///     context, and <paramref name="typeName">typeName</paramref> requires a dependent assembly that was not preloaded.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="typeName">typeName</paramref> requires a dependent
        ///     assembly, but the file is not a valid assembly.   -or-  <paramref name="typeName">typeName</paramref> requires a
        ///     dependent assembly that was compiled for a version of the runtime that is later than the currently loaded version.
        /// </exception>
        object CreateInstance(string typeName, bool ignoreCase);

        /// <summary>
        ///     Locates the specified type from this assembly and creates an instance of it using the system activator, with
        ///     optional case-sensitive search and having the specified culture, arguments, and binding and activation attributes.
        /// </summary>
        /// <param name="typeName">The <see cref="P:System.Type.FullName"></see> of the type to locate.</param>
        /// <param name="ignoreCase">true to ignore the case of the type name; otherwise, false.</param>
        /// <param name="bindingAttr">
        ///     A bitmask that affects the way in which the search is conducted. The value is a combination
        ///     of bit flags from <see cref="T:System.Reflection.BindingFlags"></see>.
        /// </param>
        /// <param name="binder">
        ///     An object that enables the binding, coercion of argument types, invocation of members, and
        ///     retrieval of MemberInfo objects via reflection. If binder is null, the default binder is used.
        /// </param>
        /// <param name="args">
        ///     An array that contains the arguments to be passed to the constructor. This array of arguments must
        ///     match in number, order, and type the parameters of the constructor to be invoked. If the default constructor is
        ///     desired, args must be an empty array or null.
        /// </param>
        /// <param name="culture">
        ///     An instance of CultureInfo used to govern the coercion of types. If this is null, the CultureInfo
        ///     for the current thread is used. (This is necessary to convert a String that represents 1000 to a Double value, for
        ///     example, since 1000 is represented differently by different cultures.)
        /// </param>
        /// <param name="activationAttributes">
        ///     An array of one or more attributes that can participate in activation. Typically, an
        ///     array that contains a single <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute"></see> object that
        ///     specifies the URL that is required to activate a remote object.  This parameter is related to client-activated
        ///     objects. Client activation is a legacy technology that is retained for backward compatibility but is not
        ///     recommended for new development. Distributed applications should instead use Windows Communication Foundation.
        /// </param>
        /// <returns>
        ///     An instance of the specified type, or null if <paramref name="typeName">typeName</paramref> is not found. The
        ///     supplied arguments are used to resolve the type, and to bind the constructor that is used to create the instance.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="typeName">typeName</paramref> is an empty string ("") or a
        ///     string beginning with a null character.   -or-   The current assembly was loaded into the reflection-only context.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="typeName">typeName</paramref> is null.</exception>
        /// <exception cref="T:System.MissingMethodException">No matching constructor was found.</exception>
        /// <exception cref="T:System.NotSupportedException">
        ///     A non-empty activation attributes array is passed to a type that does
        ///     not inherit from <see cref="T:System.MarshalByRefObject"></see>.
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="typeName">typeName</paramref> requires a dependent
        ///     assembly that could not be found.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     <paramref name="typeName">typeName</paramref> requires a dependent
        ///     assembly that was found but could not be loaded.   -or-   The current assembly was loaded into the reflection-only
        ///     context, and <paramref name="typeName">typeName</paramref> requires a dependent assembly that was not preloaded.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="typeName">typeName</paramref> requires a dependent
        ///     assembly, but the file is not a valid assembly.   -or-  <paramref name="typeName">typeName</paramref> requires a
        ///     dependent assembly which that was compiled for a version of the runtime that is later than the currently loaded
        ///     version.
        /// </exception>
        object CreateInstance(string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args,
            CultureInfo culture, object[] activationAttributes);

        /// <summary>Gets all the custom attributes for this assembly.</summary>
        /// <param name="inherit">This argument is ignored for objects of type <see cref="T:System.Reflection.Assembly"></see>.</param>
        /// <returns>An array that contains the custom attributes for this assembly.</returns>
        object[] GetCustomAttributes(bool inherit);

        /// <summary>Gets the custom attributes for this assembly as specified by type.</summary>
        /// <param name="attributeType">The type for which the custom attributes are to be returned.</param>
        /// <param name="inherit">This argument is ignored for objects of type <see cref="T:System.Reflection.Assembly"></see>.</param>
        /// <returns>
        ///     An array that contains the custom attributes for this assembly as specified by
        ///     <paramref name="attributeType">attributeType</paramref>.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="attributeType">attributeType</paramref> is null.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="attributeType">attributeType</paramref> is not a runtime
        ///     type.
        /// </exception>
        object[] GetCustomAttributes(Type attributeType, bool inherit);

        /// <summary>
        ///     Returns information about the attributes that have been applied to the current
        ///     <see cref="T:System.Reflection.Assembly"></see>, expressed as
        ///     <see cref="T:System.Reflection.CustomAttributeData"></see> objects.
        /// </summary>
        /// <returns>
        ///     A generic list of <see cref="T:System.Reflection.CustomAttributeData"></see> objects representing data about
        ///     the attributes that have been applied to the current assembly.
        /// </returns>
        IList<CustomAttributeData> GetCustomAttributesData();

        /// <summary>Gets the public types defined in this assembly that are visible outside the assembly.</summary>
        /// <returns>An array that represents the types defined in this assembly that are visible outside the assembly.</returns>
        /// <exception cref="T:System.NotSupportedException">The assembly is a dynamic assembly.</exception>
        Type[] GetExportedTypes();

        /// <summary>
        ///     Gets a <see cref="T:System.IO.FileStream"></see> for the specified file in the file table of the manifest of
        ///     this assembly.
        /// </summary>
        /// <param name="name">The name of the specified file. Do not include the path to the file.</param>
        /// <returns>A stream that contains the specified file, or null if the file is not found.</returns>
        /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="name">name</paramref> parameter is null.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="name">name</paramref> parameter is an empty string
        ///     ("").
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException"><paramref name="name">name</paramref> was not found.</exception>
        /// <exception cref="T:System.BadImageFormatException"><paramref name="name">name</paramref> is not a valid assembly.</exception>
        FileStream GetFile(string name);

        /// <summary>Gets the files in the file table of an assembly manifest.</summary>
        /// <returns>An array of streams that contain the files.</returns>
        /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">A file was not found.</exception>
        /// <exception cref="T:System.BadImageFormatException">A file was not a valid assembly.</exception>
        FileStream[] GetFiles();

        /// <summary>Gets the files in the file table of an assembly manifest, specifying whether to include resource modules.</summary>
        /// <param name="getResourceModules">true to include resource modules; otherwise, false.</param>
        /// <returns>An array of streams that contain the files.</returns>
        /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">A file was not found.</exception>
        /// <exception cref="T:System.BadImageFormatException">A file was not a valid assembly.</exception>
        FileStream[] GetFiles(bool getResourceModules);


        /// <summary>Gets all the loaded modules that are part of this assembly.</summary>
        /// <returns>An array of modules.</returns>
        Module[] GetLoadedModules();

        /// <summary>Gets all the loaded modules that are part of this assembly, specifying whether to include resource modules.</summary>
        /// <param name="getResourceModules">true to include resource modules; otherwise, false.</param>
        /// <returns>An array of modules.</returns>
        Module[] GetLoadedModules(bool getResourceModules);

        /// <summary>Returns information about how the given resource has been persisted.</summary>
        /// <param name="resourceName">The case-sensitive name of the resource.</param>
        /// <returns>
        ///     An object that is populated with information about the resource's topology, or null if the resource is not
        ///     found.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="resourceName">resourceName</paramref> is null.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="resourceName">resourceName</paramref> parameter is an
        ///     empty string ("").
        /// </exception>
        ManifestResourceInfo GetManifestResourceInfo(string resourceName);

        /// <summary>Returns the names of all the resources in this assembly.</summary>
        /// <returns>An array that contains the names of all the resources.</returns>
        string[] GetManifestResourceNames();

        /// <summary>Loads the specified manifest resource from this assembly.</summary>
        /// <param name="name">The case-sensitive name of the manifest resource being requested.</param>
        /// <returns>
        ///     The manifest resource; or null if no resources were specified during compilation or if the resource is not
        ///     visible to the caller.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="name">name</paramref> parameter is null.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="name">name</paramref> parameter is an empty string
        ///     ("").
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     In the [.NET for Windows Store apps](http://go.microsoft.com/fwlink/?LinkID=247912) or the [Portable Class
        ///     Library](~/docs/standard/cross-platform/cross-platform-development-with-the-portable-class-library.md), catch the
        ///     base class exception, <see cref="T:System.IO.IOException"></see>, instead.
        ///     A file that was found could not be loaded.
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException"><paramref name="name">name</paramref> was not found.</exception>
        /// <exception cref="T:System.BadImageFormatException"><paramref name="name">name</paramref> is not a valid assembly.</exception>
        /// <exception cref="T:System.NotImplementedException">
        ///     Resource length is greater than
        ///     <see cref="F:System.Int64.MaxValue"></see>.
        /// </exception>
        Stream GetManifestResourceStream(string name);

        /// <summary>Loads the specified manifest resource, scoped by the namespace of the specified type, from this assembly.</summary>
        /// <param name="type">The type whose namespace is used to scope the manifest resource name.</param>
        /// <param name="name">The case-sensitive name of the manifest resource being requested.</param>
        /// <returns>
        ///     The manifest resource; or null if no resources were specified during compilation or if the resource is not
        ///     visible to the caller.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="name">name</paramref> parameter is null.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="name">name</paramref> parameter is an empty string
        ///     ("").
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException"><paramref name="name">name</paramref> was not found.</exception>
        /// <exception cref="T:System.BadImageFormatException"><paramref name="name">name</paramref> is not a valid assembly.</exception>
        /// <exception cref="T:System.NotImplementedException">
        ///     Resource length is greater than
        ///     <see cref="F:System.Int64.MaxValue"></see>.
        /// </exception>
        Stream GetManifestResourceStream(Type type, string name);

        /// <summary>Gets the specified module in this assembly.</summary>
        /// <param name="name">The name of the module being requested.</param>
        /// <returns>The module being requested, or null if the module is not found.</returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="name">name</paramref> parameter is null.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="name">name</paramref> parameter is an empty string
        ///     ("").
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException"><paramref name="name">name</paramref> was not found.</exception>
        /// <exception cref="T:System.BadImageFormatException"><paramref name="name">name</paramref> is not a valid assembly.</exception>
        Module GetModule(string name);

        /// <summary>Gets all the modules that are part of this assembly.</summary>
        /// <returns>An array of modules.</returns>
        /// <exception cref="T:System.IO.FileNotFoundException">The module to be loaded does not specify a file name extension.</exception>
        Module[] GetModules();

        /// <summary>Gets all the modules that are part of this assembly, specifying whether to include resource modules.</summary>
        /// <param name="getResourceModules">true to include resource modules; otherwise, false.</param>
        /// <returns>An array of modules.</returns>
        Module[] GetModules(bool getResourceModules);

        /// <summary>Gets an <see cref="T:System.Reflection.Abstractions.AssemblyName"></see> for this assembly.</summary>
        /// <returns>An object that contains the fully parsed display name for this assembly.</returns>
        IAssemblyName GetName();

        /// <summary>
        ///     Gets an <see cref="T:System.Reflection.Abstractions.AssemblyName"></see> for this assembly, setting the codebase as
        ///     specified by <paramref name="copiedName">copiedName</paramref>.
        /// </summary>
        /// <param name="copiedName">
        ///     true to set the <see cref="P:System.Reflection.Assembly.CodeBase"></see> to the location of
        ///     the assembly after it was shadow copied; false to set <see cref="P:System.Reflection.Assembly.CodeBase"></see> to
        ///     the original location.
        /// </param>
        /// <returns>An object that contains the fully parsed display name for this assembly.</returns>
        IAssemblyName GetName(bool copiedName);

        /// <summary>Gets serialization information with all of the data needed to reinstantiate this assembly.</summary>
        /// <param name="info">The object to be populated with serialization information.</param>
        /// <param name="context">The destination context of the serialization.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="info">info</paramref> is null.</exception>
        void GetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        ///     Gets the <see cref="T:System.Reflection.Abstractions.AssemblyName"></see> objects for all the assemblies referenced by this
        ///     assembly.
        /// </summary>
        /// <returns>An array that contains the fully parsed display names of all the assemblies referenced by this assembly.</returns>
        IAssemblyName[] GetReferencedAssemblies();

        /// <summary>Gets the satellite assembly for the specified culture.</summary>
        /// <param name="culture">The specified culture.</param>
        /// <returns>The specified satellite assembly.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="culture">culture</paramref> is null.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The assembly cannot be found.</exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     The satellite assembly with a matching file name was found, but the
        ///     CultureInfo did not match the one specified.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">The satellite assembly is not a valid assembly.</exception>
        IAssembly GetSatelliteAssembly(CultureInfo culture);

        /// <summary>Gets the specified version of the satellite assembly for the specified culture.</summary>
        /// <param name="culture">The specified culture.</param>
        /// <param name="version">The version of the satellite assembly.</param>
        /// <returns>The specified satellite assembly.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="culture">culture</paramref> is null.</exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     The satellite assembly with a matching file name was found, but the
        ///     CultureInfo or the version did not match the one specified.
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The assembly cannot be found.</exception>
        /// <exception cref="T:System.BadImageFormatException">The satellite assembly is not a valid assembly.</exception>
        IAssembly GetSatelliteAssembly(CultureInfo culture, Version version);

        Type GetType(string name);

        /// <summary>
        ///     Gets the <see cref="T:System.Type"></see> object with the specified name in the assembly instance and
        ///     optionally throws an exception if the type is not found.
        /// </summary>
        /// <param name="name">The full name of the type.</param>
        /// <param name="throwOnError">true to throw an exception if the type is not found; false to return null.</param>
        /// <returns>An object that represents the specified class.</returns>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="name">name</paramref> is invalid.   -or-   The length of
        ///     <paramref name="name">name</paramref> exceeds 1024 characters.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="name">name</paramref> is null.</exception>
        /// <exception cref="T:System.TypeLoadException">
        ///     <paramref name="throwOnError">throwOnError</paramref> is true, and the
        ///     type cannot be found.
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="name">name</paramref> requires a dependent assembly
        ///     that could not be found.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     <paramref name="name">name</paramref> requires a dependent assembly
        ///     that was found but could not be loaded.   -or-   The current assembly was loaded into the reflection-only context,
        ///     and <paramref name="name">name</paramref> requires a dependent assembly that was not preloaded.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="name">name</paramref> requires a dependent assembly,
        ///     but the file is not a valid assembly.   -or-  <paramref name="name">name</paramref> requires a dependent assembly
        ///     which was compiled for a version of the runtime later than the currently loaded version.
        /// </exception>
        Type GetType(string name, bool throwOnError);

        /// <summary>
        ///     Gets the <see cref="T:System.Type"></see> object with the specified name in the assembly instance, with the
        ///     options of ignoring the case, and of throwing an exception if the type is not found.
        /// </summary>
        /// <param name="name">The full name of the type.</param>
        /// <param name="throwOnError">true to throw an exception if the type is not found; false to return null.</param>
        /// <param name="ignoreCase">true to ignore the case of the type name; otherwise, false.</param>
        /// <returns>An object that represents the specified class.</returns>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="name">name</paramref> is invalid.   -or-   The length of
        ///     <paramref name="name">name</paramref> exceeds 1024 characters.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="name">name</paramref> is null.</exception>
        /// <exception cref="T:System.TypeLoadException">
        ///     <paramref name="throwOnError">throwOnError</paramref> is true, and the
        ///     type cannot be found.
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="name">name</paramref> requires a dependent assembly
        ///     that could not be found.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     <paramref name="name">name</paramref> requires a dependent assembly
        ///     that was found but could not be loaded.   -or-   The current assembly was loaded into the reflection-only context,
        ///     and <paramref name="name">name</paramref> requires a dependent assembly that was not preloaded.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="name">name</paramref> requires a dependent assembly,
        ///     but the file is not a valid assembly.   -or-  <paramref name="name">name</paramref> requires a dependent assembly
        ///     which was compiled for a version of the runtime later than the currently loaded version.
        /// </exception>
        Type GetType(string name, bool throwOnError, bool ignoreCase);

        /// <summary>Gets the types defined in this assembly.</summary>
        /// <returns>An array that contains all the types that are defined in this assembly.</returns>
        /// <exception cref="T:System.Reflection.ReflectionTypeLoadException">
        ///     The assembly contains one or more types that cannot
        ///     be loaded. The array returned by the <see cref="P:System.Reflection.ReflectionTypeLoadException.Types"></see>
        ///     property of this exception contains a <see cref="T:System.Type"></see> object for each type that was loaded and
        ///     null for each type that could not be loaded, while the
        ///     <see cref="P:System.Reflection.ReflectionTypeLoadException.LoaderExceptions"></see> property contains an exception
        ///     for each type that could not be loaded.
        /// </exception>
        Type[] GetTypes();

        /// <summary>Indicates whether or not a specified attribute has been applied to the assembly.</summary>
        /// <param name="attributeType">The type of the attribute to be checked for this assembly.</param>
        /// <param name="inherit">This argument is ignored for objects of this type.</param>
        /// <returns>true if the attribute has been applied to the assembly; otherwise, false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="attributeType">attributeType</paramref> is null.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="attributeType">attributeType</paramref> uses an invalid
        ///     type.
        /// </exception>
        bool IsDefined(Type attributeType, bool inherit);

        /// <summary>
        ///     Loads the module, internal to this assembly, with a common object file format (COFF)-based image containing an
        ///     emitted module, or a resource file.
        /// </summary>
        /// <param name="moduleName">
        ///     The name of the module. This string must correspond to a file name in this assembly's
        ///     manifest.
        /// </param>
        /// <param name="rawModule">A byte array that is a COFF-based image containing an emitted module, or a resource.</param>
        /// <returns>The loaded module.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="moduleName">moduleName</paramref> or
        ///     <paramref name="rawModule">rawModule</paramref> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="moduleName">moduleName</paramref> does not match a file
        ///     entry in this assembly's manifest.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="rawModule">rawModule</paramref> is not a valid
        ///     module.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
        Module LoadModule(string moduleName, byte[] rawModule);

        /// <summary>
        ///     Loads the module, internal to this assembly, with a common object file format (COFF)-based image containing an
        ///     emitted module, or a resource file. The raw bytes representing the symbols for the module are also loaded.
        /// </summary>
        /// <param name="moduleName">
        ///     The name of the module. This string must correspond to a file name in this assembly's
        ///     manifest.
        /// </param>
        /// <param name="rawModule">A byte array that is a COFF-based image containing an emitted module, or a resource.</param>
        /// <param name="rawSymbolStore">
        ///     A byte array containing the raw bytes representing the symbols for the module. Must be
        ///     null if this is a resource file.
        /// </param>
        /// <returns>The loaded module.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="moduleName">moduleName</paramref> or
        ///     <paramref name="rawModule">rawModule</paramref> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="moduleName">moduleName</paramref> does not match a file
        ///     entry in this assembly's manifest.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="rawModule">rawModule</paramref> is not a valid
        ///     module.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
        Module LoadModule(string moduleName, byte[] rawModule, byte[] rawSymbolStore);
    }
}