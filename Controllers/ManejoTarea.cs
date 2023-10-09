using EspacioTarea;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp07_2023_josepro752.Controllers;

[ApiController]
[Route("[controller]")]
public class ManejoTareaController : ControllerBase
{
    private readonly ILogger<ManejoTareaController> _logger;
    private ManejoTarea manejoTarea;
    public ManejoTareaController(ILogger<ManejoTareaController> logger)
    {
        _logger = logger;
        AccesoADatos accesoADatos = new AccesoADatos();
        manejoTarea = new ManejoTarea(accesoADatos);
    }

// ● Crear una nueva tarea.
// ● Obtener una tarea por id.
// ● Actualizar una tarea.
// ● Eliminar una tarea.
// ● Listar todas las tareas.
// ● Listar todas las tareas completadas.

    [HttpPost(Name = "CrearTarea")]
    public ActionResult<Tarea> CrearTarea(Tarea tarea) {
        var t = manejoTarea.CrearTarea(tarea);
        if (t != null) {
            return Ok(t);
        }
        return BadRequest(t);
    }

    [HttpGet(Name = "GetTareaID")]
    public ActionResult<Tarea> GetTareaID(int id) {
        var t = manejoTarea.GetTareaID(id);
        if (t != null) {
            return Ok(t);
        }
        return BadRequest(t);
    }
    [HttpPut(Name = "ActualizarTarea")]
    public ActionResult<Tarea> ActualizarTarea(int id, EstadoTarea estadoTarea) {
        var t = manejoTarea.ActualizarTarea(id,estadoTarea);
        if (t != null) {
            return Ok(t);
        }
        return BadRequest(t);
    }
    [HttpDelete(Name = "EliminarTarea")]
    public ActionResult<Tarea> EliminarTarea(int id) {
        var t = manejoTarea.EliminarTarea(id);
        if (t) {
            return Ok();
        }
        return BadRequest();
    }
    [HttpGet(Name = "GetTareas")]
    public ActionResult<Tarea> GetTareas() {
        var t = manejoTarea.GetTareas();
        if (t != null) {
            return Ok(t);
        }
        return BadRequest(t);
    }
    [HttpGet(Name = "GetTareasCompletadas")]
    public ActionResult<Tarea> GetTareasCompletadas() {
        var t = manejoTarea.GetTareasCompletadas();
        if (t != null) {
            return Ok(t);
        }
        return BadRequest(t);
    }
}
