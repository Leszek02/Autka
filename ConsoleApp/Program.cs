namespace ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Interfaces.IDataAccessObject dao = new DAOMock2.DAOMock2();

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
