using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OOBootcamp.Test;

public class GraduateBoyTest
{
    private GraduateParkingBoy _graduateParkingBoy = null!;
    private List<ParkingLot> _parkingLots = null!;
    

    [Test]
    public void should_park_in_A_when_parking_one_car()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(2, 5, "A"),
            new(2, 5, "B")
        };
        _graduateParkingBoy = new GraduateParkingBoy(_parkingLots);
        var vehicle = new Vehicle("123");
        var parkingLot = _graduateParkingBoy.Park(vehicle);
        Assert.AreEqual("A",parkingLot.Name);
    }
    

    [Test]
    public void should_park_in_A_and_B_when_parking_two_cars()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(2, 5, "A"),
            new(2, 5, "B")
        };
        _graduateParkingBoy = new GraduateParkingBoy(_parkingLots);
        var vehicle1 = new Vehicle("123");
        var vehicle2 = new Vehicle("456");
        var parkingLot1 = _graduateParkingBoy.Park(vehicle1);
        var parkingLot2 = _graduateParkingBoy.Park(vehicle2);
        Assert.AreEqual("A",parkingLot1.Name);
        Assert.AreEqual("B",parkingLot2.Name);
    }


    [Test]
    public void should_park_in_A_and_B_and_A_when_parking_three_cars()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(2, 5, "A"),
            new(2, 5, "B")
        };
        _graduateParkingBoy = new GraduateParkingBoy(_parkingLots);
        var vehicle1 = new Vehicle("123");
        var vehicle2 = new Vehicle("456");
        var vehicle3 = new Vehicle("789");
        var parkingLot1 = _graduateParkingBoy.Park(vehicle1);
        var parkingLot2 = _graduateParkingBoy.Park(vehicle2);
        var parkingLot3 = _graduateParkingBoy.Park(vehicle3);
        Assert.AreEqual("A",parkingLot1.Name);
        Assert.AreEqual("B",parkingLot2.Name);
        Assert.AreEqual("A",parkingLot3.Name);
    }

    [Test]
    public void should_park_in_A_and_B_and_B_when_parking_lot_A_is_full()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(1, 5, "A"),
            new(2, 5, "B")
        };
        _graduateParkingBoy = new GraduateParkingBoy(_parkingLots);
        var vehicle1 = new Vehicle("123");
        var vehicle2 = new Vehicle("456");
        var vehicle3 = new Vehicle("789");
        var parkingLot1 = _graduateParkingBoy.Park(vehicle1);
        var parkingLot2 = _graduateParkingBoy.Park(vehicle2);
        var parkingLot3 = _graduateParkingBoy.Park(vehicle3);
        Assert.AreEqual("A",parkingLot1.Name);
        Assert.AreEqual("B",parkingLot2.Name);
        Assert.AreEqual("B",parkingLot3.Name);
    }
    
    [Test]
    public void should_throw_exception_when_all_parking_lots_are_full()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(1, 5, "A"),
            new(1, 5, "B")
        };
        _graduateParkingBoy = new GraduateParkingBoy(_parkingLots);
        var vehicle1 = new Vehicle("123");
        var vehicle2 = new Vehicle("456");
        var vehicle3 = new Vehicle("789");
        var parkingLot1 = _graduateParkingBoy.Park(vehicle1);
        var parkingLot2 = _graduateParkingBoy.Park(vehicle2);
        Assert.AreEqual("A",parkingLot1.Name);
        Assert.AreEqual("B",parkingLot2.Name);
        var exception = Assert.Throws<Exception>(() => _graduateParkingBoy.Park(vehicle3));
        Assert.AreEqual("all parking lots are full", exception!.Message);
    }

    [Test]
    public void should_return_5_when_car_123_was_retrieved_from_parking_lot_A()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(1, 5, "A")
        };
        _graduateParkingBoy = new GraduateParkingBoy(_parkingLots);
        var vehicle = new Vehicle("123");
        _graduateParkingBoy.Park(vehicle);
        var price = _graduateParkingBoy.Retrieve(vehicle);
        Assert.IsInstanceOf<double>(price);
        Assert.AreEqual(5.0d,price);
    }
    
    [Test]
    public void should_throw_exception_when_cannot_find_the_car()
    {
        _parkingLots = new List<ParkingLot>
        {
            new(1, 5, "A"),
            new(1,5,"B")
        };
        _graduateParkingBoy = new GraduateParkingBoy(_parkingLots);
        var vehicle = new Vehicle("123");
        var exception = Assert.Throws<Exception>(()=>_graduateParkingBoy.Retrieve(vehicle));
        Assert.AreEqual("cannot find this vehicle",exception!.Message);
    }
}