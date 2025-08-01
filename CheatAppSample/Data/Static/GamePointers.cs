using CheatEngineP1.Entities;

namespace CheatAppSample.Data.Static;

public static class GamePointers
{
    private const long PlayerStatsBaseGameAddress = 0x08E9DED0;
    private static readonly int[] PlayerStatsBaseOffsets = [0x30, 0x2D0, 0x210, 0x40, 0x128];

    private const long StaminaBaseGameAddress = 0x08E9DED0;
    private static readonly int[] StaminaBaseOffsets = [0x30, 0xEC0, 0xC50];
    
    private const long TechnologyTreeBaseGameAddress = 0x08E9DED0;
    private static readonly int[] TechnologyTreeBaseOffsets = [0x30, 0x298, 0x5C8];
    
    private const long EqBaseGameAddress = 0x08D51D10;
    private static readonly int[] EqBaseOffsets = [0x50, 0x68, 0x1E0, 0x2A0, 0x4F0, 0x0];

    public static readonly ProcessMemoryPointerPath CurrentHunger = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x3FC]).ToArray());
    public static readonly ProcessMemoryPointerPath CurrentHealth = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x3F0]).ToArray());
    public static readonly ProcessMemoryPointerPath CurrentWorkSpeed = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x464]).ToArray());
    public static readonly ProcessMemoryPointerPath CurrentShield = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x478]).ToArray());
    public static readonly ProcessMemoryPointerPath CurrentStamina = new(StaminaBaseGameAddress, StaminaBaseOffsets.Concat([0x320]).ToArray());
    
    public static readonly ProcessMemoryPointerPath SkillPoints = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x4E4]).ToArray());
    public static readonly ProcessMemoryPointerPath HealthSkillPoints = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x4E8, 0x8]).ToArray());
    public static readonly ProcessMemoryPointerPath StaminaSkillPoints = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x4E8, 0x14]).ToArray());
    public static readonly ProcessMemoryPointerPath AttackSkillPoints = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x4E8, 0x20]).ToArray());
    public static readonly ProcessMemoryPointerPath WorkSpeedSkillPoints = new(PlayerStatsBaseGameAddress, PlayerStatsBaseOffsets.Concat([0x4E8, 0x44]).ToArray());
    
    public static readonly ProcessMemoryPointerPath TechnologyPoints = new(TechnologyTreeBaseGameAddress, TechnologyTreeBaseOffsets.Concat([0x150]).ToArray());
    public static readonly ProcessMemoryPointerPath SpecialTechnologyPoints = new(TechnologyTreeBaseGameAddress, TechnologyTreeBaseOffsets.Concat([0x154]).ToArray());
    
    public static readonly ProcessMemoryPointerPath FirstEqSlot = new(EqBaseGameAddress, EqBaseOffsets.Concat([0x154]).ToArray());
}