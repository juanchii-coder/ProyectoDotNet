using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios.Configuracion;
public class InicializadorPermisos {
    public void Inicializar() {
        using var context = new GestionExpedienteContext();
        if(context.Database.EnsureCreated()) {
            Console.WriteLine("Se crea la base de datos con la información de permisos");
            context.Add(new Permiso(){Nombre = "CAMBIO_DE_PERMISOS"});
            context.Add(new Permiso(){Nombre = "MODIFICAR_USUARIO"});
            context.Add(new Permiso(){Nombre = "OBTENER_LISTA_USUARIOS"});
            context.Add(new Permiso(){Nombre = "EXPEDIENTE_ALTA"});
            context.Add(new Permiso(){Nombre = "EXPEDIENTE_BAJA"});
            context.Add(new Permiso(){Nombre = "EXPEDIENTE_MODIFICACION"});
            context.Add(new Permiso(){Nombre = "EXPEDIENTE_LECTURA"});
            context.Add(new Permiso(){Nombre = "TRAMITE_ALTA"});
            context.Add(new Permiso(){Nombre = "TRAMITE_BAJA"});
            context.Add(new Permiso(){Nombre = "TRAMITE_MODIFICACION"});
            context.Add(new Permiso(){Nombre = "TRAMITE_LECTURA"});
            context.SaveChanges();
        }
        using var connection = context.Database.GetDbConnection();//GetDbConnection();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "PRAGMA journal_mode=DELETE;";
        command.ExecuteNonQuery();
    }
}