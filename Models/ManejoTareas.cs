namespace EspacioTarea;

public class ManejoTarea {
    private AccesoADatos accesoADatos;
    public ManejoTarea(AccesoADatos accesoADatos) {
        this.accesoADatos = accesoADatos;
    }
    public Tarea CrearTarea(Tarea tarea) {
        var tareas = accesoADatos.Obtener();
        tarea.Id = tareas.Count()+1;
        tareas.Add(tarea);
        accesoADatos.Guardar(tareas);
        return tarea;
    }
    public Tarea GetTareaID(int id) {
        var tarea = accesoADatos.Obtener().FirstOrDefault(tarea => tarea.Id == id);
        return tarea;
    }
    public Tarea ActualizarTarea(int id, EstadoTarea estadoTarea) {
        var tareas = accesoADatos.Obtener();
        var tarea = tareas.FirstOrDefault(tar => tar.Id == id);
        if (tarea != null) {
            tarea.Estado = estadoTarea;
            accesoADatos.Guardar(tareas);
        }
        return tarea;
    }
    public bool EliminarTarea(int id) {
        var tareas = accesoADatos.Obtener();
        var tarea = tareas.FirstOrDefault(t => t.Id == id);
        if (tarea != null) {
            tareas.Remove(tarea);
            accesoADatos.Guardar(tareas);
            return true;
        }
        return false;
    }
    public List<Tarea> GetTareas() {
        return accesoADatos.Obtener();
    }
    public List<Tarea> GetTareasCompletadas() {
        return accesoADatos.Obtener().FindAll(tarea => tarea.Estado == EstadoTarea.Completada);
    }
}