using ElevatorControl;


// Case 1: Go from 1st floor to 4th 
ControlCenter control1 = new(1);
Elevator elevator1 = control1.CallElevator(1)!;
elevator1.AddStop(4);
control1.MoveElevator(elevator1);
Console.WriteLine("Case 1 complete \n");


// Case 2: Go from 4th floor to 1st
ControlCenter control2 = new(1);
Elevator elevator2 = control2.CallElevator(4)!; //Elevator will first go up to 4th floor 
elevator2!.AddStop(1);
control2.MoveElevator(elevator2);
Console.WriteLine("Case 2 complete \n");

// Case 3: Multiple stops in ascending order
ControlCenter control3 = new(1);
Elevator elevator3 = control3.CallElevator(1)!;
elevator3.AddStop(3);
elevator3.AddStop(7);
elevator3.AddStop(4);
control3.MoveElevator(elevator3);
Console.WriteLine("Case 3 complete \n");

// Case 4: Multiple stops in descending order
ControlCenter control4 = new(1);
Elevator elevator4 = control4.CallElevator(9)!;
elevator4.AddStop(3);
elevator4.AddStop(7);
elevator4.AddStop(4);
control4.MoveElevator(elevator4);
Console.WriteLine("Case 4 complete \n");