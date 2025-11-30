namespace AgentMicrosoftIntro.Components;

public class Room
{
    public int Id { get; set; } = 0;
    public string? Numero { get; } = null; 
    public string Descricao { get; set; }
    public bool IsDisponivel { get; set; }

    public Room(int id, string? numero, string descricao, bool isDisponivel)
    {
        Id = id;
        Numero = numero;
        Descricao = descricao;
        IsDisponivel = isDisponivel;
    }
}