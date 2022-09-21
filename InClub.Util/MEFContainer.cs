using System;
using System.Collections.Generic;
using System.Text;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace InClub.Util
{
    public static class MEFContainer
    {
        private static CompositionHost _container = null;

        public static CompositionHost Container
        {
            get
            {
                if (_container == null)
                {
                    //composition container, which contains all the parts available and performs composition.
                    //Composition is the matching up of imports to exports.
                    var executableLocation = Assembly.GetEntryAssembly().Location;
                    var pathAssembly = Path.GetDirectoryName(executableLocation);

                    //  var assemblies2 = Directory.GetFiles(pathAssembly, "*.dll", SearchOption.TopDirectoryOnly);


                    var assemblies = Directory
                        .GetFiles(pathAssembly, "*.dll", SearchOption.TopDirectoryOnly)
                        .Where(obj => !obj.Contains("View"))
                        .Select(AssemblyLoadContext.GetAssemblyName)
                        .Select(AssemblyLoadContext.Default.LoadFromAssemblyName)
                        .ToList();
                    var configuration = new ContainerConfiguration().WithAssemblies(assemblies);
                    _container = configuration.CreateContainer();
                }
                return _container;
            }
        }
    }
}
