public class Estudiante
{
    // Variable estática para llevar el conteo global de estudiantes
    private static int contador = 0;

    // Atributos privados 
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

    // Constructor que genera automáticamente el ID (Ej: E00001, E00002...)
    public Estudiante(string nombreEstudiante)
    {
        contador++;
        IdEstudiante = $"E{contador:D5}"; // :D5 asegura formato con ceros a la izquierda 
        Nombre = nombreEstudiante;
    }

    // Constructor alternativo por si se requiere inicializar con un ID específico 
    // Sería útil si alguna vez se decide construir encima de este programa y expandirlo.
    public Estudiante(string idPersonalizado, string nombreEstudiante)
    {
        IdEstudiante = idPersonalizado;
        Nombre = nombreEstudiante;
    }

    public void MostrarInformacion(){
        Console.WriteLine($"- ID: {IdEstudiante} | Nombre: {Nombre}");
    }
}