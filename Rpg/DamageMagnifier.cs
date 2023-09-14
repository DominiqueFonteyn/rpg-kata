namespace Rpg;

public class DamageMagnifier
{
    private readonly decimal _factor;
    private readonly ModifyOperation _modifyOperation;

    private DamageMagnifier(ModifyOperation modifyOperation, decimal factor)
    {
        _modifyOperation = modifyOperation;
        _factor = factor;
    }

    public static DamageMagnifier None => new DamageMagnifier(ModifyOperation.Increase, 0);
    public static DamageMagnifier ReduceBy(decimal factor) => new DamageMagnifier(ModifyOperation.Reduce, factor);
    public static DamageMagnifier IncreaseBy(decimal factor) => new DamageMagnifier(ModifyOperation.Increase, factor);

    public decimal Apply(int currentHealth)
    {
        if (_modifyOperation == ModifyOperation.Increase)
        {
            return currentHealth * (1 + _factor);
        }

        return currentHealth * (1 - _factor);
    }

    private enum ModifyOperation
    {
        Increase,
        Reduce
    }
}
