namespace ElevatorControl;
public class ControlCenter
{
    private readonly List<Elevator> _availableElevators = [];

    /// <summary>
    /// Initialize control center with all elevators at 1st floor
    /// </summary>
    /// <param name="nrOfElevators"> Number of elevators in the system </param>
    public ControlCenter(int nrOfElevators)
    {
        for (int i = 0; i < nrOfElevators; i++)
            _availableElevators.Add(new());
    }

    /// <summary>
    /// Summons an elevator to the current floor. 
    /// </summary>
    /// <param name="calledFromFloor"> Floor which the elevator is being called to </param>
    /// <returns> The first available elevator, or null if none are available </returns>
    public Elevator? CallElevator(int calledFromFloor)
    {
        if (_availableElevators.Count > 0)
        {
            var elevator = _availableElevators.First();
            _availableElevators.Remove(elevator);

            if (elevator.CurrentFloor != calledFromFloor)
            {
                elevator.AddStop(calledFromFloor);
                MoveElevator(elevator);
            }

            return elevator;
        }

        return null;
    }

    /// <summary>
    /// Moves a given elevator according to its planned stops.
    /// </summary>
    /// <param name="elevator"> Elevator that will move </param>
    public void MoveElevator(Elevator elevator)
    {
        CancellationTokenSource cts = new();

        Console.WriteLine("Press 'enter' for emergency stop");
        Task.Run(() => elevator.Execute(cts.Token), cts.Token);

        if(Console.ReadKey(true).Key == ConsoleKey.Enter)
            cts.Cancel();

        _availableElevators.Add(elevator);
        cts.Dispose();
    }
}
