using System.Data.Common;
using Interfaces;

namespace DAOMock1;

public class Cars : Interfaces.ICar
{
    public int ID { get; set; }
    public IProducer Producer { get; set; }
    public string Name { get; set; }
    public TimeSpan ProductionYear { get; set; }
    public Transmission TransmissionType { get; set; }
}

public class Producer : Interfaces.IProducer
{
    public int ID { get; set; }
    public string Name { get; set; }
}

public class DAOMock1 : Interfaces.IDataAccessObject
{
    private List<IProducer> producerList;
    private List<ICar> carList;
    public DAOMock1()
    {
        producerList = new List<IProducer> {
            new Producer() {ID = 1, Name="W"},
            new Producer() {ID = 2, Name="opel"}
        };

        carList = new List<ICar> {
            new Cars() {ID=1, Producer=producerList[0], Name="Passat", TransmissionType=Transmission.Gearbox},
            new Cars() {ID=2, Producer=producerList[0], Name="Golf", TransmissionType=Transmission.Clutch},
            new Cars() {ID=3, Producer=producerList[0], Name="Polowka", TransmissionType=Transmission.CVT}
        };
    }
    public ICar CreateNewCar()
    {
        throw new NotImplementedException();
    }

    public IProducer CreateNewProducer()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ICar> GetAllCars()
    {
        return carList;
    }

    public IEnumerable<IProducer> GetAllProducers()
    {
        return producerList;
    }
}