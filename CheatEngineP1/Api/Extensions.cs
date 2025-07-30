using CheatEngineP1.Interfaces;
using CheatEngineP1.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CheatEngineP1.Api;

public static class Extensions
{
    public static IServiceCollection AddCheatEngineP1(this IServiceCollection services)
    {
        services.AddSingleton<ProcessCheat>();
        services.AddSingleton<IProcessMemoryReader>(s => s.GetRequiredService<ProcessCheat>());
        services.AddSingleton<IProcessMemoryWriter>(s => s.GetRequiredService<ProcessCheat>());
        
        return services;
    }
}