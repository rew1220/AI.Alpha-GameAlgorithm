
class DamageCalculator
{
    private static double DamageCompute(double AttackDamage, double DamageMultiply, double Expectation)
    {
        return Math.Sqrt(AttackDamage * DamageMultiply * Expectation)*2;
    }//첫 데미지 계산
    private static double ShieldCompute(double EnemyShield, double EnemyShieldMultiply)
    {
        return EnemyShield * EnemyShieldMultiply;
    }//상대 방어력 계산
    public static double TotalDamageCompute(double AD, double DM, double Ex, double ES, double ESM, double FixedDamage)
    {
        double FirstDamage = DamageCompute(AD, DM, Ex);
        double EnemyShield = ShieldCompute(ES, ESM);
        if (FirstDamage <= EnemyShield) return FixedDamage;
        return Math.Round(FirstDamage - EnemyShield + FixedDamage,1);
        
    }//총 데미지 계산
}
class InGameClass
{
    static void Main(string[] args)
    {
        string? input = Console.ReadLine();
        string[] splinput = input.Split(' ');//순서대로 공격력, 공격력배수, 기댓값, 고정데미지, 상대방어력, 방어력배수
        double AD = double.Parse(splinput[0]);
        double DM = double.Parse(splinput[1]);
        double Ex = double.Parse(splinput[2]);
        double FD = double.Parse(splinput[3]);
        double ES = double.Parse(splinput[4]);
        double ESM = double.Parse(splinput[5]);

        double TotalDamage = DamageCalculator.TotalDamageCompute(AD, DM, Ex, ES, ESM, FD);
        Console.WriteLine(TotalDamage);
    }
}