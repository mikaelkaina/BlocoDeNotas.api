﻿namespace BlocoDeNotas.api.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}
