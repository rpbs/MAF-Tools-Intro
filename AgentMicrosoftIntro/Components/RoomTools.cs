using System.ComponentModel;

namespace AgentMicrosoftIntro.Components;

public static class RoomTools
{
    private static List<Room> quartos = [
        new (1, "101", "Com ar condicionado e sol da tarde", true),
        new (2, "102", "Com vista pro mar e sol da manhã", true),
        new (3, "103", "Cama para solteiro e frigobar", true),
        new (4, "104", "Quarto para casal com uma suite", true)];
    
    [Description("Exibir todos os quartos")]
    public static IEnumerable<Room> MostrarTodosQuartos() => quartos;
    
    [Description("Exibir todos os quartos disponíveis")]
    public static IEnumerable<Room> MostrarTodosQuartosDisponiveis() => 
        quartos.Where(x => x.IsDisponivel);

    [Description("Reservar um quarto")]
    public static void Rerservar([Description("Número do quarto para reserva")] string numero)
    {
        quartos.FirstOrDefault(x => x.Numero == numero)!.IsDisponivel = false;
    } 
    
    [Description("Cancelar reserva de um quarto")]
    public static void Cancelar([Description("Número do quarto para cancelar")] string numero)
    {
        quartos.FirstOrDefault(x => x.Numero == numero)!.IsDisponivel = true;
    }  
}