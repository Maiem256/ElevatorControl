using ElevatorControl;


// Case 1: Go from 1st floor to 4th 
ControlCenter control1 = new(1);
Elevator elevator1 = control1.CallElevator(1)!;
elevator1.AddStop(4);
ControlCenter.MoveElevator(elevator1);
Console.WriteLine("Case 1 complete \n");


// Case 2: Go from 4th floor to 1st
ControlCenter control2 = new(1);
Elevator elevator2 = control2.CallElevator(4)!; //Elevator will first go up to 4th floor 
elevator2!.AddStop(1);
ControlCenter.MoveElevator(elevator2);
Console.WriteLine("Case 2 complete \n");

