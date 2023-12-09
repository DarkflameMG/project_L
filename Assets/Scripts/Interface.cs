public interface IPowerLine
{
    public bool GetCurrentState();
    public void SetState(bool state);
    public void RunLine();
    public void StopLine();
}
