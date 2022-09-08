namespace OOBootcamp;

public class GraduateParkingBoy
{
    // Write your logic here
    private readonly List<ParkingLot> _parkingLots;

    public GraduateParkingBoy(List<ParkingLot> parkingLots)
    {
        _parkingLots = parkingLots;
    }

    public ParkingLot Park(Vehicle vehicle)
    {
        ParkingLot? parkedLot = null;
        foreach (var parkingLot in _parkingLots)
        {
            if (parkingLot.ParkVehicle(vehicle))
            {
                parkedLot = parkingLot;
                break;
            }
        }

        if (parkedLot != null)
        {
            _parkingLots.Add(_parkingLots[0]);
            _parkingLots.Remove(_parkingLots[0]);
            return parkedLot;
        }

        throw new Exception("all parking lots are full");
    }

    public double Retrieve(Vehicle vehicle)
    {
        var price = 0d;
        var exceptionNumber = 0;
        _parkingLots.ForEach(p =>
        {
            try
            {
                price = p.RetrieveVehicle(vehicle);
            }
            catch (Exception)
            {
                exceptionNumber++;
            }
        });
        if (exceptionNumber == _parkingLots.Count)
        {
            throw new Exception("cannot find this vehicle");
        }

        return price;
    }
}