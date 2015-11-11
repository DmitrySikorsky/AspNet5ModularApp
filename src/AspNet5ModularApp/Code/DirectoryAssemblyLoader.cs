// Used code from https://github.com/aspnet/Entropy/blob/dev/samples/Runtime.CustomLoader/Program.cs

using System.IO;
using System.Reflection;
using Microsoft.Dnx.Runtime;

namespace AspNet5ModularApp
{
  public class DirectoryAssemblyLoader : IAssemblyLoader
  {
    private readonly string path;
    private readonly IAssemblyLoadContext assemblyLoadContext;

    public DirectoryAssemblyLoader(string path, IAssemblyLoadContext assemblyLoadContext)
    {
      this.path = path;
      this.assemblyLoadContext = assemblyLoadContext;
    }

    public Assembly Load(AssemblyName assemblyName)
    {
      return this.assemblyLoadContext.LoadFile(Path.Combine(this.path, assemblyName + ".dll"));
    }
  }
}