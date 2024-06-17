namespace SGE.UI;

public class GeneradorUsuarios
{
    private int _idCounter = 1;
    private Random _random = new Random();
    private List<string> _nombres = new List<string> { "Juan", "Maria", "Pedro", "Ana", "Luis", "Luisa" };
    private List<string> _apellidos = new List<string> { "Perez", "Gomez", "Lopez", "Martinez", "Garcia", "Fernandez" };

    public Usuario? GenerarUsuario()
    {
        var nombre = _nombres[_random.Next(_nombres.Count)];
        var apellido = _apellidos[_random.Next(_apellidos.Count)];
        var email = GenerarEmail(nombre, apellido);
        var contraseña = GenerarContraseña();
        var permisos = GenerarPermisos();

        var usuario = new Usuario
        {
            Id = _idCounter++.ToString(),
            Nombre = nombre,
            Apellido = apellido,
            Email = email,
            Contraseña = contraseña,
            Permisos = permisos,
        };

        return usuario;
    }

    private string GenerarEmail(string nombre, string apellido)
    {
        var dominio = "example.com";
        return $"{nombre.ToLower()}.{apellido.ToLower()}@{dominio}";
    }

    private string GenerarContraseña()
    {
        var caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        var contraseña = new char[8];

        for (int i = 0; i < contraseña.Length; i++)
        {
            contraseña[i] = caracteres[_random.Next(caracteres.Length)];
        }

        return new string(contraseña);
    }

    private List<bool> GenerarPermisos()
    {
        // Generar una lista de 5 permisos aleatorios
        return Enumerable.Range(0, 5).Select(x => _random.Next(2) == 0).ToList();
    }
}