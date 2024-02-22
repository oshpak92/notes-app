namespace Common.System
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow() => DateTime.UtcNow;
        DateTime Now() => DateTime.Now;
    }
}
