using API_Stefanini.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API_Stefanini.Conexão_com_o_banco;

// Este arquivo está sendo responsável pela conexão com o banco de dados feito no Postgres.

public class ContextoConexao : DbContext
{
    public DbSet<Tarefa> Tarefa { get; set; } 
    
    // Aqui está contida a string de conexão com o banco.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Server=localhost;" +
            "Port=5432;Database=postgres;" +
            "User Id=postgres;" +
            "Password=180223;");
}