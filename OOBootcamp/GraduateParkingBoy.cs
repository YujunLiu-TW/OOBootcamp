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
        var index = 0;
        for (int i = 0; i < _parkingLots.Count; i++)
        {
            if (_parkingLots[i].ParkVehicle(vehicle))
            {
                parkedLot = _parkingLots[i];
                index = i;
                break;
            }
        }

        if (parkedLot != null)
        {
            _parkingLots.AddRange(_parkingLots.Take(index + 1));
            _parkingLots.RemoveRange(0, index + 1);
            return parkedLot;
        }

        throw new Exception("all parking lots are full");
    }

    public ParkingLot Retrieve(Vehicle vehicle)
    {
        ParkingLot? parkedLot = null;
        for (int i = 0; i < _parkingLots.Count; i++)
        {
            try
            {
                _parkingLots[i].RetrieveVehicle(vehicle);
                parkedLot = _parkingLots[i];
            }
            catch (Exception)
            {
                // ignored
            }

            if (parkedLot != null)
            {
                break;
            }
        }

        return parkedLot ?? throw new Exception("cannot find this vehicle");
    }
}