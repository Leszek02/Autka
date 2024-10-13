namespace Interfaces;
 
public enum Transmission {
    CVT,
    Clutch,
    Gearbox
}

public interface IProducer
{
    int ID { get; set; }
    string Name { get; set; }
}

public interface ICar
{
    int ID { get; set; }
    IProducer Producer { get; set; }
    string Name { get; set; }
    TimeSpan ProductionYear { get; set; }
    Transmission TransmissionType { get; set; }
}

public interface IDataAccessObject
{
    IEnumerable<IProducer> GetAllProducers();
    IEnumerable<ICar> GetAllCars();
    IProducer CreateNewProducer();
    ICar CreateNewCar();
}