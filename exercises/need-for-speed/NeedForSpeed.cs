using System;

class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class

    private int Speed;
    private int Drain;
    private int Battery;
    private int Driven;
    public RemoteControlCar(int speed, int batteryDrained)
    {
        Speed = speed;
        Drain = batteryDrained;
        Battery = 100;
        Driven = 0;
    }

    public bool BatteryDrained()
    {
        return Battery < Drain;
    }

    public int DistanceDriven()
    {
        return Driven;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            Driven += Speed;
            Battery -= Drain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    // TODO: define the constructor for the 'RaceTrack' class
    private int Distance;

    public RaceTrack(int distance)
    {
        Distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();
        }
        return car.DistanceDriven() >= Distance;
    }
}
