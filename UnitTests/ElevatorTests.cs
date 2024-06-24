using ElevatorControl;

namespace UnitTests;

public class ElevatorTests
{
    [Fact]
    public void AddStop_SingleStop_AddsStopToExecution()
    {
        Elevator elevator = new();

        var stops = elevator.AddStop(3);

        Assert.Single(stops);
        Assert.Equal(3, stops.First());
    }

    [Fact]
    public void AddStop_MultipleStops_AddsStopsInCorrectOrder()
    {
        List<int> testStops = [2, 5, 4];
        Elevator elevator = new();

        List<int> stops = [];
        foreach (int stop in testStops)
            stops = elevator.AddStop(stop);

        Assert.Equal(3, stops.Count);
        Assert.Equal([2, 4, 5], stops);
    }

    [Fact]
    public void GetWaitTime_WithOneStop_Returns5Seconds()
    {
        Elevator elevator = new();
        elevator.AddStop(3);

        var secondsToWait = elevator.GetWaitTime(5);

        Assert.Equal(5, secondsToWait);
    }
}