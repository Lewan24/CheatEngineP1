using CheatEngineP1.Entities;

namespace CheatAppSample.Data.Static;

public static class GamePointers
{
    private const long PlayerStatsBaseGameAddress = 0x08EAE620;
    private static readonly int[] PlayerStatsBaseOffsets = [0x58, 0x20, 0x20, 0x20, 0x568];

    private const long TechnologyTreeBaseGameAddress = 0x08C823C8;
    private static readonly int[] TechnologyTreeBaseOffsets = [0x58, 0x20, 0x20, 0x20, 0x568];

    public static readonly ProcessMemoryPointerPath CurrentHunger = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x3FC]).ToArray());
    public static readonly ProcessMemoryPointerPath CurrentHealth = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x3F0]).ToArray());
    public static readonly ProcessMemoryPointerPath CurrentWorkSpeed = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x464]).ToArray());
    public static readonly ProcessMemoryPointerPath CurrentShield = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x478]).ToArray());
    public static readonly ProcessMemoryPointerPath CurrentStamina = new(0x08EBB3E0, [0x8, 0x8, 0x8B0, 0x6A0, 0x320]);
    
    public static readonly ProcessMemoryPointerPath SkillPoints = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x4E4]).ToArray());
    public static readonly ProcessMemoryPointerPath HealthSkillPoints = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x4E8, 0x8]).ToArray());
    public static readonly ProcessMemoryPointerPath StaminaSkillPoints = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x4E8, 0x14]).ToArray());
    public static readonly ProcessMemoryPointerPath AttackSkillPoints = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x4E8, 0x20]).ToArray());
    public static readonly ProcessMemoryPointerPath WorkSpeedSkillPoints = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x4E8, 0x44]).ToArray());
    
    public static readonly ProcessMemoryPointerPath TechnologyPoints = new(TechnologyTreeBaseGameAddress, TechnologyTreeBaseOffsets.Concat([0x150]).ToArray());
    public static readonly ProcessMemoryPointerPath SpecialTechnologyPoints = new(TechnologyTreeBaseGameAddress, TechnologyTreeBaseOffsets.Concat([0x154]).ToArray());
    
    public static readonly ProcessMemoryPointerPath FirstEqSlot = new(0x08C29800, [0x178, 0x200, 0xB0, 0x30, 0x70, 0x0, 0x154]);
}