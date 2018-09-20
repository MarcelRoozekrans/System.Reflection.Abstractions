using System.Configuration.Assemblies;

namespace System.Reflection.Abstractions
{
    public interface IAssemblyNameFactory
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Reflection.Abstractions.AssemblyName"></see> class.</summary>
        IAssemblyName AssemblyName();

        /// <summary>Initializes a new instance of the <see cref="T:System.Reflection.Abstractions.AssemblyName"></see> class with the specified display name.</summary>
        /// <param name="assemblyName">The display name of the assembly, as returned by the <see cref="P:System.Reflection.Abstractions.AssemblyName.FullName"></see> property.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="assemblyName">assemblyName</paramref> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="assemblyName">assemblyName</paramref> is a zero length string.</exception>
        /// <exception cref="T:System.IO.FileLoadException">
        /// In the [.NET for Windows Store apps](http://go.microsoft.com/fwlink/?LinkID=247912) or the [Portable Class Library](~/docs/standard/cross-platform/cross-platform-development-with-the-portable-class-library.md), catch the base class exception, <see cref="T:System.IO.IOException"></see>, instead.
        /// 
        /// The referenced assembly could not be found, or could not be loaded.</exception>
        IAssemblyName AssemblyName(string assemblyName);
        
        /// <summary>Returns a value indicating whether two assembly names are the same. The comparison is based on the simple assembly names.</summary>
        /// <param name="reference">The reference assembly name.</param>
        /// <param name="definition">The assembly name that is compared to the reference assembly.</param>
        /// <returns>true if the simple assembly names are the same; otherwise, false.</returns>
        bool ReferenceMatchesDefinition(IAssemblyName reference, IAssemblyName definition);


        /// <summary>Gets the <see cref="T:System.Reflection.Abstractions.AssemblyName"></see> for a given file.</summary>
        /// <param name="assemblyFile">The path for the assembly whose <see cref="T:System.Reflection.Abstractions.AssemblyName"></see> is to be returned.</param>
        /// <returns>An object that represents the given assembly file.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="assemblyFile">assemblyFile</paramref> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="assemblyFile">assemblyFile</paramref> is invalid, such as an assembly with an invalid culture.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException"><paramref name="assemblyFile">assemblyFile</paramref> is not found.</exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have path discovery permission.</exception>
        /// <exception cref="T:System.BadImageFormatException"><paramref name="assemblyFile">assemblyFile</paramref> is not a valid assembly.</exception>
        /// <exception cref="T:System.IO.FileLoadException">An assembly or module was loaded twice with two different sets of evidence.</exception>
        IAssemblyName GetAssemblyName(string assemblyFile);
    }
}