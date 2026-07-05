class Lasagna
{
    int preperationTime;
    int ovenTime;
    int total;
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven() => 40;

    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int minutes)
    {
        minutes = ExpectedMinutesInOven() - minutes;
            return minutes;
    }

    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int layers)
    {
        preperationTime = layers * 2;
            return preperationTime;
    }

    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int layers, int minutesInOven)
    {
        total = PreparationTimeInMinutes(layers) + minutesInOven;
            return total;
    }
}
