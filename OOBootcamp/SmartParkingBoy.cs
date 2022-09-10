namespace OOBootcamp;

public class SmartParkingBoy
{
    private readonly List<ParkingLot> _parkingLots;
    private readonly Dictionary<Vehicle, int> _vehicleLocation;

    public SmartParkingBoy(List<ParkingLot> parkingLots, Dictionary<Vehicle, int> vehicleLocation)
    {
        _parkingLots = parkingLots;
        _vehicleLocation = new Dictionary<Vehicle, int>(50);
    }

    public ParkingLot Park(Vehicle vehicle)
    {
        var maxAvailableCount = _parkingLots.Max(p => p.AvailableCount);
        var parkingLotsDictionary = new Dictionary<ParkingLot, int>();
        for (int i = 0; i < _parkingLots.Count; i++)
        {
            if (_parkingLots[i].AvailableCount == maxAvailableCount)
            {
                parkingLotsDictionary.Add(_parkingLots[i], i);
            }
        }

        var parkingLotWithMaxCount = parkingLotsDictionary.MaxBy(p => p.Key.AvailableCount / p.Key.MaxCapacity);

        if (!parkingLotWithMaxCount.Key!.ParkVehicle(vehicle))
        {
            throw new NoParkingSlotAvailableException();
        }

        _vehicleLocation.Add(vehicle, parkingLotWithMaxCount.Value);

        return parkingLotWithMaxCount.Key;
    }

    public double Retrieve(Vehicle vehicle)
    {
        if (_vehicleLocation.ContainsKey(vehicle))
        {
            return _parkingLots[_vehicleLocation[vehicle]].RetrieveVehicle(vehicle);
        }

        throw new VehicleNotFoundException(vehicle);
    }
}