static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0M)
            return 3.213F;
        if (balance >= 0M && balance < 1000M)
            return 0.5F;
        if (balance >= 1000M && balance < 5000M)
            return 1.621F;
        return 2.475F;
    }

    public static decimal Interest(decimal balance)
    {
        float rate = InterestRate(balance);
        decimal interest = balance * ((decimal)rate/100);
        return interest;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int yearsToTarget = 0;
        while (balance < targetBalance)
        {
            yearsToTarget++;
            balance = AnnualBalanceUpdate(balance);
        }
        return yearsToTarget;
    }
}
