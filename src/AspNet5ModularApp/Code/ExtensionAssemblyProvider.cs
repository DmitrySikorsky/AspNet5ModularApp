// Used code from https://github.com/stuartleeks/ModularVNext/blob/master/src/ModularVNext/Infrastructure/ModuleAwareAssemblyProvider.cs

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AspNet5ModularApp.Infrastructure;
using Microsoft.AspNet.Mvc.Infrastructure;

namespace AspNet5ModularApp
{
  public class ExtensionAssemblyProvider : IAssemblyProvider
  {
    private readonly DefaultAssemblyProvider defaultAssemblyProvider;

    public ExtensionAssemblyProvider(DefaultAssemblyProvider defaultAssemblyProvider)
    {
      this.defaultAssemblyProvider = defaultAssemblyProvider;
    }

    public IEnumerable<Assembly> CandidateAssemblies
    {
      get
      {
        return this.defaultAssemblyProvider.CandidateAssemblies.Concat(ExtensionManager.Assemblies);
      }
    }
  }
}