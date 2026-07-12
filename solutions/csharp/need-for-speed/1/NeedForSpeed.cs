class RemoteControlCar
{
    int batteryPercentage = 100;
    int distanceDriven = 0;
    int speed;
    int batteryDrain;
    
    // TODO: define the constructor for the 'RemoteControlCar' class
    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        if (this.batteryPercentage < this.batteryDrain)
        {
            return true;
        }
        if (batteryPercentage == 0)
        {
            return true;
        }
        return false;
    }

    public int DistanceDriven() => distanceDriven;

    public void Drive()
    {
        if (!BatteryDrained())
        {
            distanceDriven += this.speed;
            batteryPercentage = this.batteryPercentage - this.batteryDrain;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    int distance;
    
    // TODO: define the constructor for the 'RaceTrack' class
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();
        }
    
        return car.DistanceDriven() >= distance;
    }
}
