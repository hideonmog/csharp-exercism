using System;

class RemoteControlCar
{
    private int batteryLevel = 100;
    private int distanceDriven = 0;
    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {distanceDriven} meters";

    public string BatteryDisplay()
    {
        if (batteryLevel == 0)
        {
            return $"Battery empty";
        }
        else
        {
            return $"Battery at {batteryLevel}%";
        }
    }
    public void Drive()
    {
        if (batteryLevel > 0)
        {
            distanceDriven += 20;
            batteryLevel -= 1;
        }
    }
}
