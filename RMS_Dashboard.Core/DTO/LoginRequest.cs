namespace RMS_Dashboard.Core.DTO;

public record LoginRequest(
    string? Email,
    string? Password);