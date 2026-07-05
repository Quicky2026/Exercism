class Lasagna
{
    int totalCookTime = 40;
    int preperationTime;
    int ovenTime;
    int total;
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven()
    {
        return totalCookTime;
    }

    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int minutes)
    {
        minutes = totalCookTime - minutes;
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
