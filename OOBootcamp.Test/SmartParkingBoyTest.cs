using System.Collections.Generic;
using NUnit.Framework;

namespace OOBootcamp.Test;

public class SmartParkingBoyTest
{
    private SmartParkingBoy _smartParkingBoy = null!;
    private List<ParkingLot> _parkingLots = null!;
    private readonly Dictionary<Vehicle, int> _vehicleLocation = null!;

    [Test]
    public void should_park_in_A_when_parking_one_car_given_A_has_two_counts_and_B_has_one_count()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(2, 5, "A"),
            new(1, 5, "B")
        };
        _smartParkingBoy = new SmartParkingBoy(_parkingLots, _vehicleLocation);
        var vehicle = new Vehicle("123");

        var parkingLot = _smartParkingBoy.Park(vehicle);

        Assert.AreEqual("A", parkingLot.Name);
    }

    [Test]
    public void should_park_in_A_And_B_when_parking_one_car_given_B_has_highest_vacancy_rate()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(2, 5, "A"),
            new(1, 5, "B")
        };
        _smartParkingBoy = new SmartParkingBoy(_parkingLots, _vehicleLocation);
        var vehicle1 = new Vehicle("123");
        var vehicle2 = new Vehicle("456");

        var parkingLot1 = _smartParkingBoy.Park(vehicle1);
        var parkingLot2 = _smartParkingBoy.Park(vehicle2);

        Assert.AreEqual("A", parkingLot1.Name);
        Assert.AreEqual("B", parkingLot2.Name);
    }

    [Test]
    public void should_throw_exception_when_parking_one_car_given_A_and_B_all_full()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(1, 5, "A"),
            new(1, 5, "B")
        };
        _smartParkingBoy = new SmartParkingBoy(_parkingLots, _vehicleLocation);
        var vehicle1 = new Vehicle("123");
        var vehicle2 = new Vehicle("456");
        var vehicle3 = new Vehicle("789");
        _smartParkingBoy.Park(vehicle1);
        _smartParkingBoy.Park(vehicle2);

        Assert.Throws<NoParkingSlotAvailableException>(() => _smartParkingBoy.Park(vehicle3));
    }

    [Test]
    public void should_return_A_when_car_123_was_retrieved_from_parking_lot_A()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(1, 5, "A"),
            new(1, 5, "B")
        };
        _smartParkingBoy = new SmartParkingBoy(_parkingLots, _vehicleLocation);
        var vehicle = new Vehicle("123");
        _smartParkingBoy.Park(vehicle);

        var price = _smartParkingBoy.Retrieve(vehicle);

        Assert.AreEqual(5, price);
    }

    [Test]
    public void should_throw_exception_when_cannot_find_the_car()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(1, 5, "A"),
            new(1, 5, "B")
        };
        _smartParkingBoy = new SmartParkingBoy(_parkingLots, _vehicleLocation);
        var vehicle = new Vehicle("123");

        Assert.Throws<VehicleNotFoundException>(() => _smartParkingBoy.Retrieve(vehicle));
    }
}