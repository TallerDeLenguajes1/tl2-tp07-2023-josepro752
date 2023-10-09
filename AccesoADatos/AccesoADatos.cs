namespace EspacioTarea;
using System.Text.Json;

public class AccesoADatos {
    public List<Tarea> Obtener() {
        var tareas = new List<Tarea>();
        if (File.Exists("Tarea.json")) {
            var json = File.ReadAllText("Tarea.json");
            tareas = JsonSerializer.Deserialize<List<Tarea>>(json);
        }
        return tareas;
    }
    public void Guardar(List<Tarea> tareas) {
        var json = JsonSerializer.Serialize(tareas);
        File.WriteAllText("Tarea.json",json);
    }
}