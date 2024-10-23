using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Configuration;
namespace ConsoleApp;
//Install configuration manager with NuGet
class Program
{
    static void Main(string[] args)
    {
        string libname = System.Configuration.ConfigurationManager.AppSettings["library_name"];
        //!!!!WAZNE!!!!! change to args[0] on Windows
        //args[1];
        Assembly assembly = Assembly.UnsafeLoadFrom(libname);
        Type typeToCreate = null;
        //Console.WriteLine(Configuration) //Here somehow access dao.config file
        foreach ( var t in assembly.GetTypes())
        {
            if ( t.IsAssignableTo( typeof(Interfaces.IDataAccessObject)))
            {
                typeToCreate = t;
                break;
            }
        }

        Interfaces.IDataAccessObject dao = (Interfaces.IDataAccessObject) Activator.CreateInstance(typeToCreate);

        #region car service
        foreach (Interfaces.IProducer p in dao.GetAllProducers())
        {
            Console.WriteLine( $"{p.ID}: {p.Name}");
        }
        #endregion

        #region producer service
        foreach (Interfaces.ICar c in dao.GetAllCars())
        {
            Console.WriteLine( $"{c.ID}: {c.Producer.Name}, {c.Name}, {c.TransmissionType}");
        }
        #endregion

    }
}
