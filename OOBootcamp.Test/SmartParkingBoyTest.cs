using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OOBootcamp.Test;

public class SmartParkingBoyTest
{
    private SmartParkingBoy _smartParkingBoy = null!;
    private List<ParkingLot> _parkingLots = null!;

    [Test]
    public void should_park_in_A_when_parking_one_car_given_A_has_two_counts_and_B_has_one_count()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(2, 5, "A"),
            new(1, 5, "B")
        };
        _smartParkingBoy = new SmartParkingBoy(_parkingLots);
        var vehicle = new Vehicle("123");

        var parkingLot = _smartParkingBoy.Park(vehicle);

        Assert.AreEqual("A", parkingLot.Name);
    }

    [Test]
    public void should_park_in_A_And_A_when_parking_one_car_given_A_has_three_counts_and_B_has_one_count()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(3, 5, "A"),
            new(1, 5, "B")
        };
        _smartParkingBoy = new SmartParkingBoy(_parkingLots);
        var vehicle1 = new Vehicle("123");
        var vehicle2 = new Vehicle("456");

        var parkingLot1 = _smartParkingBoy.Park(vehicle1);
        var parkingLot2 = _smartParkingBoy.Park(vehicle2);

        Assert.AreEqual("A", parkingLot1.Name);
        Assert.AreEqual("A", parkingLot2.Name);
    }

    [Test]
    public void should_throw_exception_when_parking_one_car_given_A_and_B_all_full()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(0, 5, "A"),
            new(0, 5, "B")
        };
        _smartParkingBoy = new SmartParkingBoy(_parkingLots);
        var vehicle = new Vehicle("123");

        var exception = Assert.Throws<Exception>(() => _smartParkingBoy.Park(vehicle));
        Assert.AreEqual("all parking lots are full", exception!.Message);
    }
}