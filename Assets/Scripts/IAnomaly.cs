public interface IAnomaly
{
    bool IsActive { get; }
    void Activate();
    void Deactivate();
    void Resolve();
}