namespace CheatAppSample.Data.Services;

public sealed class ServiceDataUpdater
{
    public bool IsServiceStarted { get; set; }
    public Action? OnUpdate { get; set; }

    public void TriggerUpdate()
        => OnUpdate?.Invoke();
}