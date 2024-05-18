using API_Stefanini.Conexão_com_o_banco;
using API_Stefanini.Modelos;


var builder = WebApplication.CreateBuilder(args);

// Configuração do serviço de controladores para lidar com solicitações HTTP
builder.Services.AddControllers();

// Adição de um serviço transient de InterfaceTarefaRepository com a implementação TarefaRepository
builder.Services.AddTransient<InterfaceTarefaRepository, TarefaRepository>();

// Construção da aplicação Web com base na configuração feita anteriormente
var app = builder.Build();

// Configuração do CORS para permitir solicitações de qualquer origem, método e cabeçalho
app.UseCors(options =>
{
    options.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

// Adiciona o middleware de autorização à pipeline de execução da aplicação
app.UseAuthorization();

// Mapeia os controladores para as rotas da API
app.MapControllers();

// Inicia a execução da aplicação
app.Run();