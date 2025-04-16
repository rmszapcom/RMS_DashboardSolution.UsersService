namespace RMS_Dashboard.Core.DTO;

public record RegisterRequest(
    string? Email,
    string? Password,
    string? PersonName,
    GenderOptions Gender);