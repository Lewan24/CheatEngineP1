using CheatEngineP1.Interfaces;
using CheatEngineP1.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CheatEngineP1.Api;

public static class Extensions
{
    public static IServiceCollection AddCheatEngineP1(this IServiceCollection services)
    {
        services.AddSingleton<IProcessMemoryReader, ProcessCheat>();
        services.AddSingleton<IProcessMemoryWriter, ProcessCheat>();
        
        return services;
    }
}