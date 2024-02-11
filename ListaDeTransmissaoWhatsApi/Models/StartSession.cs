namespace ListaDeTransmissaoWhatsApi.Models
{
    internal class StartSession
    {
        public bool Success { get; set; }
        public string? State { get; set; }
        public string? Message { get; set; }
        public string? Error { get; set; }
    }
}
