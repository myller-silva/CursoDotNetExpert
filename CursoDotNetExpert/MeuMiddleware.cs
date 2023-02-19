namespace CursoDotNetExpert;

public class MeuMiddleware
{
    // Responsavel por chamar o proximo middleware
    private readonly RequestDelegate _next;

    public MeuMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    
    // metodo executado toda vez que o middleware for chamado
    public async Task InvokeAsync(
        HttpContext context // instancia do contexto http que está rodando no momento da requisição, serve para repassar a chamada para o proximo middleware 
        )
    {
        Console.WriteLine("\n\r----------- Antes -----------\n\r");
        await _next(context);
        Console.WriteLine("\n\r----------- Depois -----------\n\r");
        
    }
}

public static class MeuMiddlewareExtesion
{
    
    // pesquisar sobre Extesion Metodes
    public static IApplicationBuilder UseMeuMiddleware(
        this IApplicationBuilder builder // o "this" significa que está criando um metodo de extensão da interface indicada
        )
    {
        return builder.UseMiddleware<MeuMiddleware>();
    }
}