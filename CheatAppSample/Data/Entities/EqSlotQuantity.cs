using CheatEngineP1.Entities;

namespace CheatAppSample.Data.Entities;

public record EqSlotQuantity(string EqSlotDisplayName, int Quantity = 0)
{
    public int Quantity { get; set; } = Quantity;
}