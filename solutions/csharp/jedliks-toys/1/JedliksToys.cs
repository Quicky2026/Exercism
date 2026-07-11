class RemoteControlCar
{
    int distance = 0;
    int batteryLife = 100;
    
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {distance} meters";
    }

    public string BatteryDisplay()
    {
        if (batteryLife > 0)
            return $"Battery at {batteryLife}%";
        else
            return "Battery empty";
    }

    public void Drive()
    {        
        if (batteryLife > 0)
        {
            distance += 20;
            batteryLife -= 1;
        }
    }
}
