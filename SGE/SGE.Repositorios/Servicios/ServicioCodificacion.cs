namespace SGE.Repositorios.Servicios;
using System.Security.Cryptography;
using System.Text;
using SGE.Aplicacion.Interfaces;

public class ServicioCodificacion : IServicioCodificacion {
    public string codificarContrasenia(string contrasenia) {
        using var codificador = SHA256.Create();
        var contraseniaCodificada = codificador.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));
        return Convert.ToBase64String(contraseniaCodificada);
    }
}