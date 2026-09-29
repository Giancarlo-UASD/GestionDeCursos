public class Estudiante
{
    // Variable estática para llevar el conteo global de estudiantes
    private static int contador = 0;

    // Atributos privados (Encapsulación)
    private string idEstudiante;
    private string nombre;

    public string IdEstudiante 
    { 
        get { return idEstudiante; } 
        private set { idEstudiante = value; } 
    }

    public string Nombre 
    { 
        get { return nombre; } 
        private set { nombre = value; } 
    }

    // Constructor que genera automáticamente el ID (Ej: E001, E002...)
    public Estudiante(string nombreEstudiante)
    {
        contador++;
        this.idEstudiante = $"E{contador:D3}"; // :D3 asegura formato con ceros a la izquierda (001, 002...)
        this.nombre = nombreEstudiante;
    }

    // Constructor alternativo por si se requiere inicializar con un ID específico (útil para datos precargados)
    public Estudiante(string idPersonalizado, string nombreEstudiante, bool reiniciarContador = false)
    {
        this.idEstudiante = idPersonalizado;
        this.nombre = nombreEstudiante;
    }
}