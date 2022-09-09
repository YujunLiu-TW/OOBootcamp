namespace OOBootcamp;

public class SmartParkingBoy
{
    private readonly List<ParkingLot> _parkingLots;

    public SmartParkingBoy(List<ParkingLot> parkingLots)
    {
        _parkingLots = parkingLots;
    }

    public ParkingLot Park(Vehicle vehicle)
    {
        ParkingLot? parkingLotWithMaxCount = null;
        var maxAvailableCount = 0;
        _parkingLots.ForEach(p =>
        {
            if (p.AvailableCount >= maxAvailableCount)
            {
                maxAvailableCount = p.AvailableCount;
                parkingLotWithMaxCount = p;
            }
        });
        if (!parkingLotWithMaxCount!.ParkVehicle(vehicle))
        {
            throw new Exception("all parking lots are full");
        }

        return parkingLotWithMaxCount;
    }
}