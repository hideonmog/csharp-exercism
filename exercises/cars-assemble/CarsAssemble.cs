using System;

static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        double success = 0;
        if (speed == 0)
        {
            success = 0.00;
        }
        else if (speed >= 1 && speed <= 4)
        {
            success = 1.00;
        }
        else if (speed >= 4 && speed <= 8)
        {
            success = 0.90;
        }
        else if (speed == 9)
        {
            success = 0.80;
        }
        else
        {
            success = 0.77;
        }
        return success;
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        double rate = 221 * speed * SuccessRate(speed);
        return rate;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        int items = (int)ProductionRatePerHour(speed)/60;
        return items;
    }
}