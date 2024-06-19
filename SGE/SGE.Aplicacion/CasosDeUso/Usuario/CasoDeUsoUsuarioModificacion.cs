namespace SGE.Aplicacion.CasosDeUso.Usuario;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Exepciones;
public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repositorio, IServicioPermiso autorizacion):CasoDeUsoUsuario(repositorio) {
    private const string PERMISO_ADMIN = "MODIFICAR_USUARIO";
    private const string ERROR_MESSAGE="Error al modificar usuario - ";
    
    // idUsuario => id actual (Normal o Admin), Usuario usuario => usuario buscado y campos modificados
    // Si idUsuario == usuario.Id => significa que el usuario está modificando su propia info
    // Sino debe ser el Admin modificando info de otro usuario
    public void Ejecutar(int idUsuario, Usuario usuario) {
        Usuario? usuarioDb = Repositorio.ObtenerUsuarioPorId(usuario.Id);
        if(usuarioDb != null) {
            // distinto ID entre el buscado y el que se
            if((usuarioDb.Id != idUsuario) && (!autorizacion.UsuarioTienePermiso(idUsuario, PERMISO_ADMIN)))
                throw new AutorizacionException(ERROR_MESSAGE + "Se necesita permiso de administrador para realizar el cambio");
        }
        Repositorio.UsuarioModificacion(usuario.Id, usuario);
    }
}