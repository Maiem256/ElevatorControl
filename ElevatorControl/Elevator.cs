namespace ElevatorControl;

public class Elevator(int initialFloor = 1)
{
    private List<int> _stops = [];
    private int _currentFloor = initialFloor;

    public int CurrentFloor { get { return _currentFloor; } }

    public bool GoingUp =>
        _stops.Count > 0
        && _stops.First() > _currentFloor;

    /// <summary>
    /// Calculate how much time the elevator will take to get to a specific 
    /// floor, assuming each floor takes 1 sec to pass and each stop along 
    /// the way takes 3 sec before resuming.
    /// </summary>
    /// <param name="destinationFloor"> Floor which travel time is calculated for </param>
    /// <returns></returns>
    public int GetWaitTime(int destinationFloor)
    {
        int travelTime = 0;
        if (GoingUp)
        {
            travelTime = destinationFloor - _currentFloor - 1; // Exclude current floor
            var stopsUntilDest = _stops.Where(x => x < destinationFloor);
            travelTime += stopsUntilDest.Count() * 2; // Add additional 2s per stop
        }
        else
        {
            travelTime = _currentFloor - destinationFloor - 1;
            var stopsUntilDest = _stops.Where(x => x > destinationFloor);
            travelTime += stopsUntilDest.Count() * 2; // Add additional 2s per stop
        }
        return travelTime;
    }

    /// <summary>
    /// Adds a floor as a stop on the elevators execution plan and sorts the 
    /// stops in ascending order, or descending if going down.
    /// </summary>
    /// <param name="destinationFloor"> Destination floor to add to execution plan </param>
    /// <returns> Execution plan with the added stop </returns>
    public List<int> AddStop(int destinationFloor)
    {
        _stops.Add(destinationFloor);
        _stops.Sort();
        if (!GoingUp)
            _stops.Reverse();
        return _stops;
    }

    /// <summary>
    /// Executes the planned stops 
    /// </summary>
    /// <returns> The last stop in the execution plan </returns>
    public int Execute(CancellationToken token)
    {
        do
        {
            Console.WriteLine($"Lift going {(GoingUp ? "up" : "down")}");

            int nextStop = _stops.First();
            for (int i = _currentFloor; i < nextStop; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine($"Emergency stop pressed! Stopping at {i}");
                    break;
                }
                Console.WriteLine($"Current floor: {i}");
                Thread.Sleep(1000);
            }

            _currentFloor = nextStop;
            _stops.Remove(_currentFloor);

            Console.WriteLine($"\nArrived at floor {_currentFloor}");
        } while (_stops.Count > 0);


        return _currentFloor;
    }
}
