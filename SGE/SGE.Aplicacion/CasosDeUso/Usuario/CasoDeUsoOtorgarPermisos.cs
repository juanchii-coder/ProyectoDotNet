using SGE.Aplicacion;

public class CasoDeUsoOtorgarPermisos(IUsuarioRepositorio repositorio, IServicioAutorizacion autorizacion):CasoDeUsoUsuario(repositorio) {
    private const string PERMISO_ADMIN = "CAMBIO_DE_PERMISOS";
    public void Ejecutar(int idAdmin, int idUsuario, List<Permiso> permisos) {
        // Corroborar que el usuario es el ADMIN
        // TO-DO: implementar entidad Permiso y usar constante
        if(autorizacion.PoseeElPermiso(idAdmin, Permiso.CambioDePermisos))
            Repositorio.CambiarPermisosDeUsuario(idUsuario, permisos);
    }
}